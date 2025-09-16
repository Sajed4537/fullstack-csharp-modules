using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EcommerceCart.App.Repository_UoW.InMemory
{
    internal class InMemoryUtilisateursRepository : IUtilisateursRepository
    {
        private Dictionary<int, Utilisateurs> _repository;
        private int _currentId = 1;

        public InMemoryUtilisateursRepository()
        {
            _repository = new Dictionary<int, Utilisateurs>();
        }

        public void Add(Utilisateurs entity)
        {
            if (entity != null)
            {
                var uniqueId = _currentId++;
                entity.Id = uniqueId;

                _repository.Add(uniqueId, entity);
            }
        }

        public Utilisateurs? FindByEmail(string email)
        {
            foreach(var item in _repository.Values)
            {
                if(item.Email == email)
                {
                    return item;
                }
            }
            return default(Utilisateurs?);
        }

        public Utilisateurs? FindByNomPrenom(string nom, string prenom)
        {
            foreach( var item in _repository.Values)
            {
                if(item.Nom == nom &&  item.Prenom == prenom)
                {
                    return item;
                }
            }
            return default(Utilisateurs?);
        }

        public Utilisateurs? GetById(int id)
        {
            if (_repository.ContainsKey(id))
            {
                return _repository[id];
            }
            return null;
        }

        public IEnumerable<Utilisateurs> ListAll()
        {
            var all = new List<Utilisateurs>();

            foreach (var item in _repository.Values)
            {
                all.Add(item);
            }
            return all;
        }

        public IEnumerable<Utilisateurs> ListByTypeUtilisateur(TypeUtilisateur type)
        {
            var listeUtilisateur = new List<Utilisateurs>();

            foreach (var item in _repository.Values)
            {
                if(item.Type == type)
                {
                    listeUtilisateur.Add(item);
                }
            }

            return listeUtilisateur;
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

        public bool Update(Utilisateurs entity)
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
