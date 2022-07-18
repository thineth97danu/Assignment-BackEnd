using BackEnd.Core.IService;
using BackEnd.Dto.RequestDto;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork;

namespace BackEnd.Services.Customer
{
    public class CustomerService : ICustomer
    {
        IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get All Customer
        public async Task<IEnumerable<Model.Customer>> GetAllCustomer()
        {
            IEnumerable<Model.Customer> customer;

            using (_unitOfWork)
            {
                try
                {
                    customer = await _unitOfWork.ApplicationCustomerRepository.GetAllCustomer();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return customer;
        }
        #endregion

        #region Create Customer
        public async Task<IEnumerable<Model.Customer>> CreateCustomer(CustomerRequest request)
        {
            IEnumerable<Model.Customer> customer;

            using (_unitOfWork)
            {
                try
                {
                    customer = await _unitOfWork.ApplicationCustomerRepository.CreateCustomer(request);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return customer;
        }
        #endregion

        #region Update Customer
        public async Task<IEnumerable<Model.Customer>> UpdateCustomer(CustomerRequest request, string UserId)
        {
            IEnumerable<Model.Customer> customer;

            using (_unitOfWork)
            {
                try
                {
                    customer = await _unitOfWork.ApplicationCustomerRepository.UpdateCustomer(request, UserId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return customer;
        }
        #endregion

        #region Delete Customer
        public async Task<IEnumerable<Model.Customer>> DeleteCustomer(string UserId)
        {
            IEnumerable<Model.Customer> customer;

            using (_unitOfWork)
            {
                try
                {
                    customer = await _unitOfWork.ApplicationCustomerRepository.DeleteCustomer(UserId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return customer;
        }
        #endregion


    }
}
