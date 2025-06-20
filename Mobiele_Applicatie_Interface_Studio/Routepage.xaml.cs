namespace Mobiele_Applicatie_Interface_Studio;

public partial class Routepage : ContentPage
{
    // Bestemmingsadres (kan je eventueel dynamisch maken)
    private const string Bestemming = "Drievogelstraat 128, Maastricht";

    public Routepage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // Terug naar vorige pagina
    }

    private async void OnStartRouteClicked(object sender, EventArgs e)
    {
        string bestemmingEncoded = Uri.EscapeDataString(Bestemming);
        string url = $"https://www.google.com/maps/dir/?api=1&destination={bestemmingEncoded}";

        try
        {
            await Launcher.Default.OpenAsync(url);
        }
        catch (Exception)
        {
            await DisplayAlert("Fout", "Kan Google Maps niet openen.", "OK");
        }
    }
}
