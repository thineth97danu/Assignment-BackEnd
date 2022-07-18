using BackEnd.Dto.RequestDto;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.IService
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<IEnumerable<BackEnd.Model.Customer>> CreateCustomer(CustomerRequest obreq);
        Task<IEnumerable<BackEnd.Model.Customer>> UpdateCustomer(CustomerRequest obreq, string UserId);
        Task<IEnumerable<BackEnd.Model.Customer>> DeleteCustomer(string UserId);
    }
}
