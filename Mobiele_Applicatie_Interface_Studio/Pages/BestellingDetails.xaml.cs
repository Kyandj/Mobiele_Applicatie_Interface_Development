//using Android.Graphics.Drawables;
using Mobiele_Applicatie_Interface_Studio.Models;

namespace Mobiele_Applicatie_Interface_Studio.Pages;

public partial class BestellingDetails : ContentPage
{
    private readonly LocationService _locationService = new();
    private Order _order;

    public BestellingDetails()
    {
        InitializeComponent();
        graphicsView.Drawable = new SimpleDrawable();
    }

    public BestellingDetails(int orderId)
    {
        InitializeComponent();
        graphicsView.Drawable = new SimpleDrawable();
    }

    public BestellingDetails(Order order)
    {
        InitializeComponent();
        _order = order;
        BindingContext = _order;
        graphicsView.Drawable = new SimpleDrawable();
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

    private async void OnSaveSignatureClicked(object sender, EventArgs e)
    {
        if (signatureView.Drawable != null)
        {
            var imageStream = await signatureView.GetImageStream(200, 200);
        }
    }
}
