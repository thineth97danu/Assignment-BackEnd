using BackEnd.Core.IService;
using BackEnd.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace BackEnd.Services.Order
{
    public class OrderService : IOrder
    {
        IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Model.Order>> OrderDetails(string UserId)
        {
         
            IEnumerable<Model.Order> OrderDetails;

            using (_unitOfWork)
            {
                try
                {
                    OrderDetails = await _unitOfWork.ApplicationOrderRepository.OrderDetails(UserId.Trim());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return OrderDetails;
        }

    }
}
