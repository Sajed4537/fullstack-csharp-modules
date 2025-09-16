using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Domain
{
    internal class Comment
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int AuthorUserId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Comment(int issueId, int authorUserId, string body)
        {
            IssueId = issueId;
            AuthorUserId = authorUserId;
            Body = body;
        }
    }
}
