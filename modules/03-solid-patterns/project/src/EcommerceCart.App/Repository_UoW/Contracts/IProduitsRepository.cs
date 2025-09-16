using EcommerceCart.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.Contracts
{
    internal interface IProduitsRepository : IRepository<Produits>
    {
        IEnumerable<Produits> ListByCategorie(Categories categorie);
        Produits? FindByNom(string nom);
        IEnumerable<Produits> SortByPrix(IEnumerable<Produits> produits, bool croissant, bool decroissant);
        IEnumerable<Produits> SortByStock(IEnumerable<Produits> produits, bool croissant, bool decroissant);
        
    }
}
