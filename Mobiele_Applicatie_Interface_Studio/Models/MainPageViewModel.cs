using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mobiele_Applicatie_Interface_Studio.Models;

namespace Mobiele_Applicatie_Interface_Studio.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Order> Orders { get; set; }

    public IEnumerable<Order> InBehandelingOrders => Orders.Where(o => o.BezorgingStatus == "Onderweg");
    public IEnumerable<Order> BezorgdOrders => Orders.Where(o => o.BezorgingStatus == "Bezorgd");
    public IEnumerable<Order> OverigOrders => Orders.Where(o => o.BezorgingStatus == "Overig");

    public MainPageViewModel()
    {
        Orders = new ObservableCollection<Order>
        {

            //Order worden weergeven zoals ze hier onder elkaar staan

            new Order { OrderId = 607857972 , Address = "Drievogelstraat 128\n6466KW", TimeWindow = "10:00 - 12:00" ,BezorgingStatus = "Onderweg", OrderKleur = Colors.Yellow},
            new Order { OrderId = 256237835, Address = "Kerkstraat 22\n6467AB", TimeWindow = "12:00 - 14:00" ,BezorgingStatus = "Onderweg", OrderKleur = Colors.Yellow},
            new Order { OrderId = 372226621, Address = "Stationsweg 5\n6468CD", TimeWindow = "14:00 - 16:00" , BezorgingStatus = "Onderweg", OrderKleur = Colors.Yellow},
            new Order { OrderId = 089808658, Address = "Marktplein 1\n6469EF", TimeWindow = "16:00 - 18:00" , BezorgingStatus = "Onderweg", OrderKleur = Colors.Yellow},

            new Order { OrderId = 497363565, Address = "Willembeekmanstraat 6\n6271CZ", TimeWindow = "10:00 - 14:00" , BezorgingStatus = "Niet Thuis", OrderKleur = Colors.Red},
            new Order { OrderId = 948095675, Address = "Bergweg 10\n6272GH", TimeWindow = "14:00 - 12:00" , BezorgingStatus = "Niet Thuis", OrderKleur = Colors.Red},

            new Order { OrderId = 590614625, Address = "Dorpsstraat 77\n6273IJ", TimeWindow = "08:00 - 09:00" , BezorgingStatus = "Bezorgd", OrderKleur = Colors.Green},
            new Order { OrderId = 750145170, Address = "Schoollaan 3\n6274KL", TimeWindow = "11:00 - 12:00" , BezorgingStatus = "Bezorgd", OrderKleur = Colors.Green},
            new Order { OrderId = 345489437, Address = "Parklaan 8\n6275MN", TimeWindow = "13:00 - 14:00" , BezorgingStatus = "Bezorgd", OrderKleur = Colors.Green},

            new Order { OrderId = 881916491, Address = "Willembeekmanstraat 6\n6271CZ", TimeWindow = "9:00 - 11:00" , BezorgingStatus = "Overig", OrderKleur = Colors.Cyan},
            new Order { OrderId = 112381910, Address = "Bergweg 10\n6272GH", TimeWindow = "12:00 - 16:00" , BezorgingStatus = "Overig", OrderKleur = Colors.Cyan},

        };

        Orders.CollectionChanged += (s, e) =>
        {
            if (e.NewItems != null)
                foreach (Order order in e.NewItems)
                    order.PropertyChanged += Order_PropertyChanged;
            if (e.OldItems != null)
                foreach (Order order in e.OldItems)
                    order.PropertyChanged -= Order_PropertyChanged;

            OnPropertyChanged(nameof(InBehandelingOrders));
            OnPropertyChanged(nameof(BezorgdOrders));
            OnPropertyChanged(nameof(OverigOrders));
        };

        // Abonneer op bestaande orders
        foreach (var order in Orders)
            order.PropertyChanged += Order_PropertyChanged;
    }

    private void Order_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Order.BezorgingStatus))
        {
            OnPropertyChanged(nameof(InBehandelingOrders));
            OnPropertyChanged(nameof(BezorgdOrders));
            OnPropertyChanged(nameof(OverigOrders));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}