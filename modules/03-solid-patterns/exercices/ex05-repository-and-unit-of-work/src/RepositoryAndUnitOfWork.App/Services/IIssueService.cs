using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Services
{
    internal interface IIssueService
    {
        int CreateIssue(int projectId, string title, string description, int authorUserId);
        bool AssignIssue(int issueId, int assigneeUserId);
        bool AdvanceStatus(int issueId);
        bool Reopen(int issueId);
        int AddComment(int issueId, int authorUserId, string body);
        (Issue issue, IEnumerable<Comment> comments)? GetDetails(int issueId);
    }
}
