using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Data.Contracts
{
    internal interface IRepository<T>
    {
        T? GetById(int id);
        IEnumerable<T> ListAll();
        void Add(T entity);
        bool Update(T entity);
        bool Remove(int id);
    }
}
