using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Model
{
    public class Supplier:Active
    {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
