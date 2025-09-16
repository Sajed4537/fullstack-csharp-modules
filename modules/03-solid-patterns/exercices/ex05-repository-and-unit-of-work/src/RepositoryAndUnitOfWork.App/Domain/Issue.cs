using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Domain
{
    public enum IssueStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }
    internal class Issue
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public IssueStatus IssueStatus { get; set; } = IssueStatus.Open;
        public int? AssigneeUserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Issue(){}
    }
}
