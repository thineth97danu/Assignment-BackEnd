using BackEnd.Core.IRepository;
using BackEnd.Dto.RequestDto;
using Dapper;
using DbConnect;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository: DBContext, IApplicationCustomerRepository
    {
        #region Create New Customer
        public async Task<IEnumerable<BackEnd.Model.Customer>> CreateCustomer(CustomerRequest request)
        {
           
            IEnumerable<BackEnd.Model.Customer> customer = null;
            try
            {
                Guid _id = System.Guid.NewGuid();

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Username", request.Username.Trim());
                dynamicParameterlist.Add("@Email", request.Email.Trim());
                dynamicParameterlist.Add("@FirstName", request.FirstName.Trim());
                dynamicParameterlist.Add("@LastName", request.LastName.Trim());
                dynamicParameterlist.Add("@id", _id);


                customer = await dbConnection.QueryAsync<BackEnd.Model.Customer>(@"INSERT INTO [Customer]([UserId],[Username],[Email],[FirstName],[LastName])" +
                                                                                 "VALUES (@id,@Username,@Email,@FirstName,@LastName)", dynamicParameterlist);

                if (customer != null)
                {
                    customer = await dbConnection.QueryAsync<BackEnd.Model.Customer>(@"select UserId,Username,Email,FirstName,LastName,CreatedOn,IsActive from [Customer] where UserId=@id", dynamicParameterlist);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        #endregion

        #region Get All Customers
        public async Task<IEnumerable<BackEnd.Model.Customer>> GetAllCustomer()
        {
           
            IEnumerable<BackEnd.Model.Customer> customer;
            try
            {
                customer = await dbConnection.QueryAsync<BackEnd.Model.Customer>(@"select UserId,Username,Email,FirstName,LastName,CreatedOn,IsActive from [Customer]");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        #endregion

        #region Update Customer
        public async Task<IEnumerable<BackEnd.Model.Customer>> UpdateCustomer(CustomerRequest request, string UserId)
        {
            
            IEnumerable<BackEnd.Model.Customer> customer = null;
            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Email", request.Email.Trim());
                dynamicParameterlist.Add("@FirstName", request.FirstName.Trim());
                dynamicParameterlist.Add("@LastName", request.LastName.Trim());
                dynamicParameterlist.Add("@IsActive", request.IsActive);
                dynamicParameterlist.Add("@id", UserId);


                customer = await dbConnection.QueryAsync<BackEnd.Model.Customer>(@"update [Customer] SET [Email]=@Email,[FirstName]=@FirstName,[LastName]=@LastName,[IsActive]=@IsActive where UserId=@id", dynamicParameterlist);

                if (customer != null)
                {
                    customer = await dbConnection.QueryAsync<BackEnd.Model.Customer>(@"select UserId,Username,Email,FirstName,LastName,CreatedOn,IsActive from [Customer] where UserId=@id", dynamicParameterlist);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        #endregion

        #region Delete Customer
        public async Task<IEnumerable<BackEnd.Model.Customer>> DeleteCustomer(string UserId)
        {
          
            IEnumerable<BackEnd.Model.Customer> customer = null;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@id", UserId.Trim());
                customer = await dbConnection.QueryAsync<BackEnd.Model.Customer>(@"delete from Customer where UserId=@id", dynamicParameterlist);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        #endregion


    }
}
