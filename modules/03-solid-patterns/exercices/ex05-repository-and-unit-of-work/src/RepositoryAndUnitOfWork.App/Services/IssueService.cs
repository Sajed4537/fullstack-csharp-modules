using RepositoryAndUnitOfWork.App.Data.Contracts;
using RepositoryAndUnitOfWork.App.Data.InMemory;
using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Services
{
    internal class IssueService : IIssueService
    {
        public IIssueRepository IssueRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public IssueService()
        {
            IssueRepository = new InMemoryIssueRepository();
            CommentRepository = new InMemoryCommentRepository();
            UserRepository = new InMemoryUserRepository();
            ProjectRepository = new InMemoryProjectRepository();
            UnitOfWork = new InMemoryUnitOfWork();
        }
        public int AddComment(int issueId, int authorUserId, string body)
        {
            var issue = IssueRepository.GetById(issueId);
            var user = UserRepository.GetById(authorUserId);

            if(issue == null || user == null || string.IsNullOrWhiteSpace(body))
            {
                return 0;
            }
            else
            {
                var newComment = new Comment(issueId, authorUserId, body);
                CommentRepository.Add(newComment);
                UnitOfWork.SaveChanges();
                return newComment.Id;
            }
        }

        public bool AdvanceStatus(int issueId)
        {
            var issue = IssueRepository.GetById(issueId);

            if(issue == null)
            {
                return false;
            }
            else
            {
                if(issue.IssueStatus == IssueStatus.Closed)
                {
                    return false;
                }
                switch (issue.IssueStatus)
                {
                    case IssueStatus.Open:
                        issue.IssueStatus = IssueStatus.InProgress;
                        break;
                    case IssueStatus.InProgress:
                        issue.IssueStatus = IssueStatus.Resolved;
                        break;
                    case IssueStatus.Resolved:
                        issue.IssueStatus = IssueStatus.Closed;
                        break;
                }

                IssueRepository.Update(issue);
                UnitOfWork.SaveChanges();
                return true;
            }
        }

        public bool AssignIssue(int issueId, int assigneeUserId)
        {
            var issue = IssueRepository.GetById(issueId);
            var user = UserRepository.GetById(assigneeUserId);

            if(issue == null || user == null)
            {
                return false;
            }
            else
            {
                issue.AssigneeUserId = assigneeUserId;
                IssueRepository.Update(issue);
                UnitOfWork.SaveChanges();
                return true;
            }
        }

        public int CreateIssue(int projectId, string title, string description, int authorUserId)
        {
            var project = ProjectRepository.GetById(projectId);

            var user = UserRepository.GetById(authorUserId);

            if(project == null || user == null || string.IsNullOrWhiteSpace(title))
            {
                return 0;
            }
            else
            {
                var newIssue = new Issue
                {
                    ProjectId = projectId,
                    Title = title,
                    Description = description,
                    IssueStatus = IssueStatus.Open,
                    AssigneeUserId = null,
                    CreatedAt = DateTime.UtcNow,
                };
                
                IssueRepository.Add(newIssue);
                UnitOfWork.SaveChanges();
                return newIssue.Id;
            }
        }

        public (Issue issue, IEnumerable<Comment> comments)? GetDetails(int issueId)
        {
            var issue = IssueRepository.GetById(issueId);

            if( issue == null)
            {
                return null;
            }
            else
            {
                var comments = CommentRepository.ListByIssue(issueId).OrderBy(i => i.CreatedAt).ToList();

                return (issue, comments);
            }
        }

        public bool Reopen(int issueId)
        {
            var issue = IssueRepository.GetById(issueId);

            if(issue == null)
            {
                return false;
            }
            else
            {
                if(issue.IssueStatus == IssueStatus.Resolved || issue.IssueStatus == IssueStatus.Closed)
                {
                    issue.IssueStatus = IssueStatus.InProgress;
                    IssueRepository.Update(issue);
                    UnitOfWork.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
