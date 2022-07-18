using BackEnd.Core.IRepository;
using BackEnd.Dto.ResponseDto;
using BackEnd.Model;
using Dapper;
using DbConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : DBContext, IApplicationOrderRepository
    {
        public async Task<IEnumerable<Order>> OrderDetails(string UserId)
        {

            IEnumerable<Order> orderdetails = null;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CustomerId", UserId);
                orderdetails = await dbConnection.QueryAsync<Order>("spActiveOrdersForCustomer", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderdetails;
        }  
    }
}
