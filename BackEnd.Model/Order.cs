using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Model
{
    public class Order :Product
    {
        public Guid OrderId { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public int OrderBy { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime ShippedOn { get; set; }
    }
}
