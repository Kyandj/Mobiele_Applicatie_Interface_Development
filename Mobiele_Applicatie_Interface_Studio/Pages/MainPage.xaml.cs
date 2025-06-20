using Microsoft.Maui.Controls;
namespace Mobiele_Applicatie_Interface_Studio.Pages;

public partial class MainPage : ContentPage
{
    int count = 0;
    private readonly LocationService _locationService = new(); 

    public MainPage()
    {
        InitializeComponent();
        _ = _locationService.StartLiveTrackingAsync();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void OnOpenGoogleMapsClicked(object sender, EventArgs e)
    {
        var url = "https://www.google.com/maps";
        await Launcher.Default.OpenAsync(url);
    }
}

