using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Dto
{
    public class CustomerResponce: BaseResponce
    {
        public IEnumerable<Customer> Customer { get; set; }
     
    }


}
