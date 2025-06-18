using System.Net.Http.Json;
using Microsoft.Maui.ApplicationModel;
using System.Diagnostics;

public class LocationService : IDisposable
{
    private readonly HttpClient _httpClient = new();
    private readonly System.Timers.Timer _timer;
    private bool _isSending;

    private const string ApiUrl = "https://webhook.site/4665b091-7652-4dbd-9f44-98109ae6cbfb";

    public LocationService()
    {
        _timer = new System.Timers.Timer(TimeSpan.FromMinutes(10).TotalMilliseconds);
        _timer.Elapsed += async (s, e) => await TimerElapsedAsync();
        _timer.AutoReset = true;
    }

    public void Start()
    {
        _timer.Start();
        Debug.WriteLine("LocationService started.");
    }

    public void Stop()
    {
        _timer.Stop();
        Debug.WriteLine("LocationService stopped.");
    }

    private async Task TimerElapsedAsync()
    {
        if (_isSending) return;
        _isSending = true;
        try
        {
            await SendLocationAsync();
        }
        finally
        {
            _isSending = false;
        }
    }

    public async Task SendLocationAsync()
    {
        var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        if (status != PermissionStatus.Granted)
        {
            Debug.WriteLine("Location permission denied.");
            return;
        }

        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync()
                ?? await Geolocation.GetLocationAsync();

            if (location != null)
            {
                var payload = new
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Timestamp = DateTime.UtcNow
                };

                await _httpClient.PostAsJsonAsync(ApiUrl, payload);
                Debug.WriteLine($"Location sent: {payload.Latitude}, {payload.Longitude} at {payload.Timestamp}");
            }
            else
            {
                Debug.WriteLine("Location not available.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error sending location: {ex.Message}");
        }
    }

    public void Dispose()
    {
        _timer?.Dispose();
        _httpClient?.Dispose();
    }
}
