using Mobiele_Applicatie_Interface_Studio.Models;

namespace Mobiele_Applicatie_Interface_Studio.Pages;

public partial class BestellingDetails : ContentPage
{
    private readonly LocationService _locationService = new();
    private Order _order;

    public BestellingDetails(int orderId)
    {
        InitializeComponent();
    }

    public BestellingDetails(Order order)
    {
        InitializeComponent();
        _order = order;
        BindingContext = _order;
        // Laad details op basis van orderId
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
}
