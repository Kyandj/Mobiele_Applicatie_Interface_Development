using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiele_Applicatie_Interface_Studio.Models;

public class Order
{
    public int OrderId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string TimeWindow { get; set; } = string.Empty;
}
