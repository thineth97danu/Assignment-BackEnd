using BackEnd.Core.IService;
using BackEnd.Dto.ResponseDto;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private IOrder OrderService;
        public OrderController(IOrder ApplicationOrderServices)
        {
            OrderService = ApplicationOrderServices;
        }

        [HttpGet("{UserId}")]
        public async Task<OrderResponse> GetCustomerOrder(string UserId)
        {

            OrderResponse orderResponse = new OrderResponse();
            IEnumerable<Order> order;
            try
            {
                order = await OrderService.OrderDetails(UserId);
                orderResponse.orderDetails = order;
                orderResponse.IsSuccess = true;
                orderResponse.Message = "Retrieved Successfully";
                orderResponse.StatusCode = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                orderResponse.IsSuccess = false;
                orderResponse.Message = ex.Message;
                orderResponse.StatusCode = HttpStatusCode.InternalServerError;


            }

            return orderResponse;
        }
    }
}
