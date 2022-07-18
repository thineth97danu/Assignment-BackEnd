using BackEnd.Core.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Data.SqlClient;

namespace UnitOfWork
{
    public sealed class UnitOfWorkClass : BaseUnitOfWork, IUnitOfWork
    {
        Guid _id = Guid.Empty;
        private ILogger<UnitOfWorkClass> _logger;

        private CustomerRepository _customerRepository;
        private OrderRepository _orderRepository;

        public UnitOfWorkClass(IConfiguration configuration, ILogger<UnitOfWorkClass> logger)
        {
            _id = Guid.NewGuid();

            _logger = logger;

            _connection = new SqlConnection(configuration.GetConnectionString("DB"));

            try
            {
                _connection.Open();

            }
            catch (Exception ex)
            {
                ///connection loss
                _logger.LogError(ex.Message);
            }
        }
        public IApplicationCustomerRepository ApplicationCustomerRepository
        {
            get
            {
                if (_customerRepository != null)
                { return _customerRepository; }
                else
                {
                    _customerRepository = new CustomerRepository();
                    _customerRepository._transaction = _transaction;
                    _customerRepository.dbConnection = _connection;
                    return _customerRepository;
                }
            }
        }
        public IApplicationOrderRepository ApplicationOrderRepository
        {
            get
            {
                if (_orderRepository != null)
                { return _orderRepository; }
                else
                {
                    _orderRepository = new OrderRepository();
                    _orderRepository._transaction = _transaction;
                    _orderRepository.dbConnection = _connection;
                    return _orderRepository;
                }
            }
        }
    }
}
