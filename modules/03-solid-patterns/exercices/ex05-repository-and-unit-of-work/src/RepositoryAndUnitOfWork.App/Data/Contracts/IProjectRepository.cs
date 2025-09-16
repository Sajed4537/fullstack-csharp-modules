using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Data.Contracts
{
    internal interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> FindByName(string partialName);
    }
}
