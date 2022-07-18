using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Model
{
    public class Product: Supplier
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
