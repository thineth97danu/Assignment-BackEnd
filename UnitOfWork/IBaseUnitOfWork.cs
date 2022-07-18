using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork
{
    public interface IBaseUnitOfWork: IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }

}
