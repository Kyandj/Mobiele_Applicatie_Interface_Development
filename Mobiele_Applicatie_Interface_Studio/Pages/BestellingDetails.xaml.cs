namespace Mobiele_Applicatie_Interface_Studio.Pages;

public partial class BestellingDetails : ContentPage
{
	public BestellingDetails()
	{
		InitializeComponent();
	}

    private readonly LocationService _locationService = new();

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
