using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.InMemory
{
    internal class InMemoryProduitsRepository : IProduitsRepository
    {
        private Dictionary<int, Produits> _repository;
        private int _currentId = 1;

        public InMemoryProduitsRepository() 
        {
            _repository = new Dictionary<int, Produits>();
        }

        public void Add(Produits entity)
        {
            if (entity != null)
            {
                var uniqueId = _currentId++;
                entity.Id = uniqueId;

                _repository.Add(uniqueId, entity);
            }
        }

        public Produits? FindByNom(string nom)
        {
            foreach (var item in _repository.Values)
            {
                if (item.Nom == nom)
                {
                    return item;
                }
            }
            return default(Produits?);
        }

        public Produits? GetById(int id)
        {
            if (_repository.ContainsKey(id))
            {
                return _repository[id];
            }
            return null;
        }

        public IEnumerable<Produits> ListAll()
        {
            var all = new List<Produits>();

            foreach (var item in _repository.Values)
            {
                all.Add(item);
            }
            return all;
        }

        public IEnumerable<Produits> ListByCategorie(Categories categorie)
        {
            var listProduits= new List<Produits>();

            foreach (var item in _repository.Values)
            {
                if(item.Categories == categorie)
                {
                    listProduits.Add(item);
                }
            }

            return listProduits;
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

        public IEnumerable<Produits> SortByPrix(IEnumerable<Produits> produits, bool croissant, bool decroissant)
        {
            if((croissant ==  false && decroissant == false) || (croissant == false && decroissant == false))
            {
                throw new ArgumentException("Il faut choisir un seul mode de trie.");
            }
            else if(croissant && !decroissant)
            {
                return produits.OrderBy(p => p.Prix);
            }
            else
            {
                return produits.OrderByDescending(p => p.Prix);
            }
        }

        public IEnumerable<Produits> SortByStock(IEnumerable<Produits> produits, bool croissant, bool decroissant)
        {
            if ((croissant == false && decroissant == false) || (croissant == false && decroissant == false))
            {
                throw new ArgumentException("Il faut choisir un seul mode de trie.");
            }
            else if (croissant && !decroissant)
            {
                return produits.OrderBy(p => p.Stock);
            }
            else
            {
                return produits.OrderByDescending(p => p.Stock);
            }
        }

        public bool Update(Produits entity)
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
