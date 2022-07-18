using BackEnd.Core.IService;
using BackEnd.Dto;
using BackEnd.Dto.RequestDto;
using BackEnd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    
    public class CustomerController : ControllerBase
    {
        private ICustomer _CustomerServices;
        public CustomerController(ICustomer ApplicationUserServices)
        {
            _CustomerServices = ApplicationUserServices;
        }
        
        [HttpGet]
        public async Task<CustomerResponce> GetAllCustomer()
        {

            CustomerResponce customerResponse = new CustomerResponce();
            IEnumerable<Customer> customer;
            try
            {
                customer = await _CustomerServices.GetAllCustomer();
                customerResponse.Customer = customer;
                customerResponse.IsSuccess = true;
                customerResponse.Message = "Retrieved Successfully";
                customerResponse.StatusCode = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                customerResponse.IsSuccess = false;
                customerResponse.Message = ex.Message;
                customerResponse.StatusCode = HttpStatusCode.InternalServerError;


            }

            return customerResponse;
        }

        [HttpPost]
        public async Task<CustomerResponce> CreateCustomer([FromBody] CustomerRequest request)
        {

            CustomerResponce customerResponse = new CustomerResponce();
            IEnumerable<Customer> customer;
            try
            {
                customer = await _CustomerServices.CreateCustomer(request);
                customerResponse.Customer = customer;
                customerResponse.IsSuccess = true;
                customerResponse.Message = "Created Successfully";
                customerResponse.StatusCode = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                customerResponse.IsSuccess = false;
                customerResponse.Message = ex.Message;
                customerResponse.StatusCode = HttpStatusCode.InternalServerError;

            }

            return customerResponse;
        }

        [HttpPut("{UserId}")]
        public async Task<CustomerResponce> UpdateCustomer(string UserId,[FromBody] CustomerRequest request)
        {

            CustomerResponce customerResponse = new CustomerResponce();
            IEnumerable<Customer> customer;
            try
            {
                customer = await _CustomerServices.UpdateCustomer(request, UserId);
                customerResponse.Customer = customer;
                customerResponse.IsSuccess = true;
                customerResponse.Message = "Updated Successfully";
                customerResponse.StatusCode = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                customerResponse.IsSuccess = false;
                customerResponse.Message = ex.Message;
                customerResponse.StatusCode = HttpStatusCode.InternalServerError;

            }

            return customerResponse;
        }


        [HttpDelete("{UserId}")]
        public async Task<CustomerResponce> DeleteCustomer(string UserId)
        {

            CustomerResponce customerResponse = new CustomerResponce();
            IEnumerable<Customer> customer;
            try
            {
                customer = await _CustomerServices.DeleteCustomer(UserId);
                customerResponse.Customer = customer;
                customerResponse.IsSuccess = true;
                customerResponse.Message = "Deleted Successfully";
                customerResponse.StatusCode = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                customerResponse.IsSuccess = false;
                customerResponse.Message = ex.Message;
                customerResponse.StatusCode = HttpStatusCode.InternalServerError;

            }

            return customerResponse;
        }

    }
}
