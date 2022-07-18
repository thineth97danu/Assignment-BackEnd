using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbConnect
{
    public interface IDBContext
    {

    }
    public class DBContext: IDBContext
    {
        public IDbConnection dbConnection;

        public IDbTransaction _transaction;
    }
}
