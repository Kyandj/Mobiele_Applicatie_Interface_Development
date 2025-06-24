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
    }

    public BestellingDetails(int orderId)
    {
        InitializeComponent();
        // Hier kun je eventueel order ophalen op basis van orderId
    }

    public BestellingDetails(Order order)
    {
        InitializeComponent();
        _order = order;
        BindingContext = _order;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _locationService.StartLiveTrackingAsync();

        // Laad de handtekening als deze bestaat
        var filePath = Path.Combine(FileSystem.AppDataDirectory, $"signature_{_order.OrderId}.png");
        if (File.Exists(filePath))
        {
            signatureImage.Source = ImageSource.FromFile(filePath);
        }
        else
        {
            signatureImage.Source = null; // Of een placeholder
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _locationService.StopLiveTracking();
    }

    private async void OnSaveSignatureClicked(object sender, EventArgs e)
    {
        if (signatureView.Lines?.Any() != true)
        {
            await DisplayAlert("Error", "Please provide a signature before saving.", "OK");
            return;
        }

        var imageStream = await signatureView.GetImageStream(200, 200);

        if (imageStream != null)
        {
            // Kies een pad om het bestand op te slaan
            var filePath = Path.Combine(FileSystem.AppDataDirectory, $"signature_{_order.OrderId}.png");

            using (var fileStream = File.Create(filePath))
            {
                await imageStream.CopyToAsync(fileStream);
            }

            await DisplayAlert("Success", $"Handtekening opgeslagen op: {filePath}", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Kon de handtekening niet opslaan.", "OK");
        }
    }

    private void OnStatusOnderwegClicked(object sender, EventArgs e)
    {
        if (BindingContext is Order order)
        {
            order.BezorgingStatus = "Onderweg";
            order.OrderKleur = Colors.Yellow;
        }
    }

    private void OnStatusBezorgdClicked(object sender, EventArgs e)
    {
        if (BindingContext is Order order)
        {
            order.BezorgingStatus = "Bezorgd";
            order.OrderKleur = Colors.Green;
        }
    }

    private void OnStatusOverigClicked(object sender, EventArgs e)
    {
        if (BindingContext is Order order)
        {
            order.BezorgingStatus = "Overig";
            order.OrderKleur = Colors.Red;
        }
    }
}