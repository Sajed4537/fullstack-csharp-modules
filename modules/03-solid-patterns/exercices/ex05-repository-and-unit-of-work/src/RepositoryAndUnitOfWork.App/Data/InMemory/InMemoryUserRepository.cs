using RepositoryAndUnitOfWork.App.Data.Contracts;
using RepositoryAndUnitOfWork.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Data.InMemory
{
    internal class InMemoryUserRepository : IUserRepository
    {
        private Dictionary<int, User> _repository;

        private int _currentId = 1;

        public InMemoryUserRepository()
        {
            _repository = new Dictionary<int, User>();
        }
        public void Add(User entity)
        {
            if(entity != null)
            {
                var uniqueId = _currentId++;
                entity.Id = uniqueId;

                _repository.Add(uniqueId, entity);
            }
            
        }

        public User? FindByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            foreach(var user in _repository.Values)
            {
                if(user.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    return user;
                }
            }
            return null;
        }

        public User? GetById(int id)
        {
            if (_repository.ContainsKey(id))
            {
                return _repository[id];
            }
            return null;
        }

        public IEnumerable<User> ListAll()
        {
            var all = new List<User>();

            foreach(var item in _repository.Values)
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

        public bool Update(User entity)
        {
            if(entity == null)
            {
                return false;
            }

            if(_repository.ContainsKey(entity.Id))
            {
                _repository[entity.Id] = entity;
                return true;
            }
            return false;
        }
    }
}
