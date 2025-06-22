using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Mobiele_Applicatie_Interface_Studio.Models;

namespace Mobiele_Applicatie_Interface_Studio.ViewModels;

public class MainPageViewModel
{
    public ObservableCollection<Order> OnderwegOrders { get; set; }
    public ObservableCollection<Order> NietBezorgdOrders { get; set; }
    public ObservableCollection<Order> BezorgdOrders { get; set; }

    public MainPageViewModel()
    {
        OnderwegOrders = new ObservableCollection<Order>
        {
            new Order { OrderId = "#98361538014", Address = "Drievogelstraat 128\n6466KW", TimeWindow = "12:00 - 14:00" },
            new Order { OrderId = "#98361538015", Address = "Kerkstraat 22\n6467AB", TimeWindow = "09:00 - 11:00" },
            new Order { OrderId = "#98361538016", Address = "Stationsweg 5\n6468CD", TimeWindow = "14:00 - 16:00" },
            new Order { OrderId = "#98361538017", Address = "Marktplein 1\n6469EF", TimeWindow = "16:00 - 18:00" }
        };

        NietBezorgdOrders = new ObservableCollection<Order>
        {
            new Order { OrderId = "#98361538018", Address = "Willembeekmanstraat 6\n6271CZ", TimeWindow = "18:00 - 20:00" },
            new Order { OrderId = "#98361538019", Address = "Bergweg 10\n6272GH", TimeWindow = "10:00 - 12:00" }
        };

        BezorgdOrders = new ObservableCollection<Order>
        {
            new Order { OrderId = "#98361538020", Address = "Dorpsstraat 77\n6273IJ", TimeWindow = "08:00 - 09:00" },
            new Order { OrderId = "#98361538021", Address = "Schoollaan 3\n6274KL", TimeWindow = "11:00 - 12:00" },
            new Order { OrderId = "#98361538022", Address = "Parklaan 8\n6275MN", TimeWindow = "13:00 - 14:00" }
        };
    }
}