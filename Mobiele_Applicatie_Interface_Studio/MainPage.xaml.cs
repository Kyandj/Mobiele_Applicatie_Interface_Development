namespace Mobiele_Applicatie_Interface_Studio;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnRouteClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Routepage");
    }
}
