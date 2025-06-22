using Microsoft.Maui.Controls;
using Mobiele_Applicatie_Interface_Studio.ViewModels;
using Mobiele_Applicatie_Interface_Studio.Models;

namespace Mobiele_Applicatie_Interface_Studio.Pages;

public partial class MainPage : ContentPage
{
    private readonly LocationService _locationService = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
        _ = _locationService.StartLiveTrackingAsync();
    }

    private async void OnRouteClicked(object sender, EventArgs e)
    {
        // Haal het order-object op uit de BindingContext van de knop
        var button = sender as Button;
        if (button?.BindingContext is not null)
        {
            // Probeer het adres op te halen uit het order-object
            var order = button.BindingContext;
            var addressProperty = order.GetType().GetProperty("Address");
            if (addressProperty != null)
            {
                var address = addressProperty.GetValue(order)?.ToString();
                if (!string.IsNullOrWhiteSpace(address))
                {
                    var url = $"https://www.google.com/maps/search/?api=1&query={Uri.EscapeDataString(address)}";
                    await Launcher.Default.OpenAsync(url);
                }
            }
        }
    }
    private async void OnOrderIdClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Order selectedOrder)
        {
            // Navigeer naar de details pagina en geef het OrderId mee
            await Navigation.PushAsync(new BestellingDetails(selectedOrder));
        }
    }
}
