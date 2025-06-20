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
        if (sender is Button button && button.BindingContext is Order order)
        {

            await DisplayAlert("Route", $"Toon route voor bestelling: {order.OrderId}", "OK");
        }
    }
}

