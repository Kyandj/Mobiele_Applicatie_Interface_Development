using Microsoft.Maui.Controls;
using Mobiele_Applicatie_Interface_Studio.Pages;

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

    private async void OnBestellingDetailsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BestellingDetails());
    }

    private async void OnRoutePaginaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoutePagina());
    }
}

