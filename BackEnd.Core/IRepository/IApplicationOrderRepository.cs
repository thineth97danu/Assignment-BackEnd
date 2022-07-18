using BackEnd.Dto.ResponseDto;
using BackEnd.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Core.IRepository
{
    public interface IApplicationOrderRepository
    {
        Task<IEnumerable<Order>> OrderDetails(string UserId);
    }
}
