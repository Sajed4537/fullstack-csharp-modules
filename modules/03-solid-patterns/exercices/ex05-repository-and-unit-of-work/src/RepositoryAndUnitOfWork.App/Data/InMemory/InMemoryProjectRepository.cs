using RepositoryAndUnitOfWork.App.Data.Contracts;
using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Data.InMemory
{
    internal class InMemoryProjectRepository : IProjectRepository
    {
        private Dictionary<int, Project> _repository;
        private int _currentId = 1;
        public InMemoryProjectRepository() 
        {
            _repository = new Dictionary<int, Project>();
        }

        public void Add(Project entity)
        {
            if (entity != null)
            {
                var uniqueId = _currentId++;
                entity.Id = uniqueId;

                _repository.Add(uniqueId, entity);
            }
        }

        public IEnumerable<Project> FindByName(string partialName)
        {
            var projects = new List<Project>();

            if (string.IsNullOrWhiteSpace(partialName))
            {
                return projects;
            }

            foreach (var project in _repository.Values)
            {
                if (project.Name.Equals(partialName, StringComparison.OrdinalIgnoreCase))
                {
                    projects.Add(project);
                }
            }
            return projects;
        }

        public Project? GetById(int id)
        {
            if (_repository.ContainsKey(id))
            {
                return _repository[id];
            }
            return null;
        }

        public IEnumerable<Project> ListAll()
        {
            var all = new List<Project>();

            foreach (var item in _repository.Values)
            {
                all.Add(item);
            }
            return all;
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

        public bool Update(Project entity)
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