using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UnitOfWork
{
    public abstract class BaseUnitOfWork
    {
        public static IDbConnection _connection;
        public static IDbTransaction _transaction;

        public BaseUnitOfWork()
        {

        }


        public void BeginTransaction()
        {
            _connection.BeginTransaction();
        }
        public void CommitTransaction()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _transaction.Commit();
                _connection.Close();


            }
        }
        public void RollbackTransaction()
        {
            try
            {
                _transaction.Rollback();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();

            }
        }
        public void Dispose()
        {
            _connection.Dispose();


        }
    }

}
