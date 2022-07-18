using BackEnd.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitOfWork
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IApplicationCustomerRepository ApplicationCustomerRepository { get; }
        IApplicationOrderRepository ApplicationOrderRepository { get; }
    }
}
