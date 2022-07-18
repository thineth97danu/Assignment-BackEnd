using BackEnd.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Core.IService
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> OrderDetails(string UserId);
    }
}
