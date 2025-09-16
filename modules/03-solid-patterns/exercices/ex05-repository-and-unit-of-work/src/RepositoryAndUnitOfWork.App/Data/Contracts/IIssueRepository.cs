using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Data.Contracts
{
    internal interface IIssueRepository : IRepository<Issue>
    {
        IEnumerable<Issue> ListByProject(int projectId);

        IEnumerable<Issue> ListByStatus(IssueStatus status);

        IEnumerable<Issue> ListAssignedTo(int userId);
    }
}
