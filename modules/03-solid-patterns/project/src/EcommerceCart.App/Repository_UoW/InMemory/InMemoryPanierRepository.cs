using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.InMemory
{
    internal class InMemoryPanierRepository : IPanierRepository
    {
        private Dictionary<int, Panier> _repository;

        private int _currentId = 1;

        public InMemoryPanierRepository()
        {
            _repository = new Dictionary<int, Panier>();
        }

        public void Add(Panier entity)
        {
            if (entity != null)
            {
                var uniqueId = _currentId++;
                entity.Id = uniqueId;

                _repository.Add(uniqueId, entity);
            }
        }

        public Panier? GetById(int id)
        {
            if (_repository.ContainsKey(id))
            {
                return _repository[id];
            }
            return null;
        }

        public Panier? GetPanierByUserId(int userId)
        {
            foreach(var item in _repository.Values)
            {
                if(item.IdUtilisateur == userId)
                {
                    return item;
                }
            } 
            return default(Panier?);
        }

        public IEnumerable<Panier> ListAll()
        {
            var all = new List<Panier>();

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

        public bool Update(Panier entity)
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
