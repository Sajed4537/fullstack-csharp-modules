using EcommerceCart.App.Repository_UoW.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.InMemory
{
    internal class InMemoryUnitOfWork : IUnitOfWork
    {
        public int CommitCount { get; private set; }

        public InMemoryUnitOfWork() { }
        public void SaveChanges()
        {
            CommitCount++;
        }
    }
}
