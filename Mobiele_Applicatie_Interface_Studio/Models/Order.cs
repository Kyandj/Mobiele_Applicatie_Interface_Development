using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiele_Applicatie_Interface_Studio.Models;

public class Order
{
    public string OrderId { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string TimeWindow { get; set; } = string.Empty;
}
