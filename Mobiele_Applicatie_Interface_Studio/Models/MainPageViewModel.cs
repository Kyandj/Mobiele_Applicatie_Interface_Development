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
    public ObservableCollection<Order> InBehandelingOrders { get; set; }
    public ObservableCollection<Order> NietBezorgdOrders { get; set; }
    public ObservableCollection<Order> BezorgdOrders { get; set; }

    public MainPageViewModel()
    {
        InBehandelingOrders = new ObservableCollection<Order>
        {
            new Order { OrderId = 607857972 , Address = "Drievogelstraat 128\n6466KW", TimeWindow = "12:00 - 14:00" },
            new Order { OrderId = 256237835, Address = "Kerkstraat 22\n6467AB", TimeWindow = "09:00 - 11:00" },
            new Order { OrderId = 372226621, Address = "Stationsweg 5\n6468CD", TimeWindow = "14:00 - 16:00" },
            new Order { OrderId = 089808658, Address = "Marktplein 1\n6469EF", TimeWindow = "16:00 - 18:00" }
        };

        NietBezorgdOrders = new ObservableCollection<Order>
        {
            new Order { OrderId = 497363565, Address = "Willembeekmanstraat 6\n6271CZ", TimeWindow = "18:00 - 20:00" },
            new Order { OrderId = 948095675, Address = "Bergweg 10\n6272GH", TimeWindow = "10:00 - 12:00" }
        };

        BezorgdOrders = new ObservableCollection<Order>
        {
            new Order { OrderId = 590614625, Address = "Dorpsstraat 77\n6273IJ", TimeWindow = "08:00 - 09:00" },
            new Order { OrderId = 750145170, Address = "Schoollaan 3\n6274KL", TimeWindow = "11:00 - 12:00" },
            new Order { OrderId = 345489437, Address = "Parklaan 8\n6275MN", TimeWindow = "13:00 - 14:00" }
        };
    }
}