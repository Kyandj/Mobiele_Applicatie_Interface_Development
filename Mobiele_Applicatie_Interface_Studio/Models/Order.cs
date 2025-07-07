using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mobiele_Applicatie_Interface_Studio.Models;

public class Order : INotifyPropertyChanged
{
    public int OrderId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string TimeWindow { get; set; } = string.Empty;

    private string bezorgingStatus;
    public string BezorgingStatus
    {
        get => bezorgingStatus;
        set
        {
            if (bezorgingStatus != value)
            {
                bezorgingStatus = value;
                OnPropertyChanged();
            }
        }
    }

    private Color orderKleur;
    public Color OrderKleur
    {
        get => orderKleur;
        set
        {
            if (orderKleur != value)
            {
                orderKleur = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
