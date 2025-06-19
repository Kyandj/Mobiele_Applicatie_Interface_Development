using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.ApplicationModel;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Refit;

public partial class LocationService : ObservableObject, IDisposable
{
    private readonly ILocationWebhookApi _webhookApi;
    private CancellationTokenSource? _cts;
    private IDisposable? _locationSubscription;

    [ObservableProperty]
    private Location? currentLocation;

    private const string ApiUrl = "https://webhook.site/4665b091-7652-4dbd-9f44-98109ae6cbfb";

    public LocationService()
    {
        _webhookApi = RestService.For<ILocationWebhookApi>(ApiUrl);
    }

    public async Task StartLiveTrackingAsync()
    {
        var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        if (status != PermissionStatus.Granted)
        {
            Debug.WriteLine("Locatiepermissie geweigerd.");
            return;
        }

        _cts = new CancellationTokenSource();

        // Start live tracking met een observable
        _locationSubscription = Observable
            .Interval(TimeSpan.FromSeconds(1))
            .SelectMany(async _ =>
            {
                try
                {
                    var location = await Geolocation.GetLocationAsync(
                        new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10)),
                        _cts.Token);

                    return location;
                }
                catch
                {
                    return null;
                }
            })
            .Where(loc => loc != null)
            .Subscribe(loc =>
            {
                CurrentLocation = loc;
                _ = SendLocationToWebhookAsync(loc!);
            });
    }

    public void StopLiveTracking()
    {
        _cts?.Cancel();
        _locationSubscription?.Dispose();
        Debug.WriteLine("Live tracking gestopt.");
    }

    private async Task SendLocationToWebhookAsync(Location location)
    {
        try
        {
            var payload = new
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Timestamp = DateTime.UtcNow
            };

            await _webhookApi.SendLocationAsync(payload);
            Debug.WriteLine($"Locatie verzonden: {payload.Latitude}, {payload.Longitude} om {payload.Timestamp}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Fout bij verzenden locatie: {ex.Message}");
        }
    }

    public void Dispose()
    {
        StopLiveTracking();
    }
}
