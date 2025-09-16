using RepositoryAndUnitOfWork.App.Data.Contracts;
using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Data.InMemory
{
    internal class InMemoryIssueRepository : IIssueRepository
    {
        private Dictionary<int, Issue> _repository;

        private int _currentId = 1;
        public InMemoryIssueRepository() 
        {
            _repository = new Dictionary<int, Issue>();
        }
        public void Add(Issue entity)
        {
            if (entity != null)
            {
                if(entity.CreatedAt == default)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                var uniqueId = _currentId++;
                entity.Id = uniqueId;

                _repository.Add(uniqueId, entity);
            }
        }

        public Issue? GetById(int id)
        {
            if (_repository.ContainsKey(id))
            {
                return _repository[id];
            }
            return null;
        }

        public IEnumerable<Issue> ListAll()
        {
            var all = new List<Issue>();

            foreach (var item in _repository.Values)
            {
                all.Add(item);
            }
            return all;
        }

        public IEnumerable<Issue> ListAssignedTo(int userId)
        {
            var issues = new List<Issue>();

            foreach (var item in _repository.Values)
            {
                if(item.AssigneeUserId == userId)
                {
                    issues.Add(item);
                }
            }
            return issues;
        }

        public IEnumerable<Issue> ListByProject(int projectId)
        {
            var issues = new List<Issue>();

            foreach (var item in _repository.Values)
            {
                if (item.ProjectId == projectId)
                {
                    issues.Add(item);
                }
            }
            return issues;
        }

        public IEnumerable<Issue> ListByStatus(IssueStatus status)
        {
            var issues = new List<Issue>();

            foreach (var item in _repository.Values)
            {
                if (item.IssueStatus == status)
                {
                    issues.Add(item);
                }
            }
            return issues;
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

        public bool Update(Issue entity)
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