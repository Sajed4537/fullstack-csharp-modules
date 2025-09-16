using RepositoryAndUnitOfWork.App.Data.Contracts;
using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Data.InMemory
{
    internal class InMemoryCommentRepository : ICommentRepository
    {
        private Dictionary<int, Comment> _repository;

        private int _currentId = 1;

        public InMemoryCommentRepository()
        {
            _repository = new Dictionary<int, Comment>();
        }
        public void Add(Comment entity)
        {
            if (entity != null)
            {
                if (entity.CreatedAt == default)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                var uniqueId = _currentId++;
                entity.Id = uniqueId;

                _repository.Add(uniqueId, entity);
            }
        }

        public Comment? GetById(int id)
        {
            if (_repository.ContainsKey(id))
            {
                return _repository[id];
            }
            return null;
        }

        public IEnumerable<Comment> ListAll()
        {
            var all = new List<Comment>();

            foreach (var item in _repository.Values)
            {
                all.Add(item);
            }
            return all;
        }

        public IEnumerable<Comment> ListByIssue(int issueId)
        {
            var comments = new List<Comment>();

            foreach (var item in _repository.Values)
            {
                if (item.IssueId == issueId)
                {
                    comments.Add(item);
                }
            }
            return comments;
        }

        public bool Remove(int id)
        {
            if (_repository.ContainsKey(id))
            {
                _repository.Remove(id);
                return true;
            }
            return false;
        }

        public bool Update(Comment entity)
        {
            if (entity == null)
            {
                return false;
            }

            if (_repository.ContainsKey(entity.Id))
            {
                _repository[entity.Id] = entity;
                return true;
            }
            return false;
        }
    }
}
