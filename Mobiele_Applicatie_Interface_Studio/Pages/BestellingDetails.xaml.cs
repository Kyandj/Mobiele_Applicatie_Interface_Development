using Mobiele_Applicatie_Interface_Studio.Models;
using System.IO;

namespace Mobiele_Applicatie_Interface_Studio.Pages;

public partial class BestellingDetails : ContentPage
{
    private readonly LocationService _locationService = new();
    private Order _order;

    public BestellingDetails()
    {
        InitializeComponent();
        graphicsView.Drawable = new SimpleDrawable();
    }

    public BestellingDetails(int orderId)
    {
        InitializeComponent();
        graphicsView.Drawable = new SimpleDrawable();
        // Hier kun je eventueel order ophalen op basis van orderId
    }

    public BestellingDetails(Order order)
    {
        InitializeComponent();
        _order = order;
        BindingContext = _order;
        graphicsView.Drawable = new SimpleDrawable();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _locationService.StartLiveTrackingAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _locationService.StopLiveTracking();
    }

    private async void OnSaveSignatureClicked(object sender, EventArgs e)
    {
        var imageStream = await signatureView.GetImageStream(200, 200);
        if (imageStream != null)
        {
            // Voorbeeld: opslaan als PNG op het apparaat
            var filePath = Path.Combine(FileSystem.CacheDirectory, "handtekening.png");
            using (var fileStream = File.OpenWrite(filePath))
            {
                await imageStream.CopyToAsync(fileStream);
            }
            await DisplayAlert("Opgeslagen", $"Handtekening opgeslagen als {filePath}", "OK");
        }
    }
}