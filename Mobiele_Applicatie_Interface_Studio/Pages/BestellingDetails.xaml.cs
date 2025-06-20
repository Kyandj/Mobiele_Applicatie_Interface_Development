using Mobiele_Applicatie_Interface_Studio.Services;
using Mobiele_Applicatie_Interface_Studio.ViewModels;

namespace Mobiele_Applicatie_Interface_Studio.Pages;

public partial class BestellingDetails : ContentPage
{
    private BestellingDetailsViewModel _viewModel;
    private readonly LocationService _locationService = new();

    public BestellingDetails()
    {
        InitializeComponent();
        var service = new BestellingService(new HttpClient());
        _viewModel = new BestellingDetailsViewModel(service);
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _locationService.StartLiveTrackingAsync();
        await _viewModel.LoadBestellingAsync("98361538014"); // Replace with actual ID
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _locationService.StopLiveTracking();
    }
}
