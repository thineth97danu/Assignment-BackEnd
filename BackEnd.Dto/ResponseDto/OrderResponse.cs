using BackEnd.Model;
using System.Collections.Generic;


namespace BackEnd.Dto.ResponseDto
{

    public class OrderResponse:BaseResponce 
    {
        public IEnumerable<Order> orderDetails { get; set; }
    }
}
