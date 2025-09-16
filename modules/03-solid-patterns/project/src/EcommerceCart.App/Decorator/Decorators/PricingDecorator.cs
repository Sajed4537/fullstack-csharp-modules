using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Decorator.Decorators
{
    internal abstract class PricingDecorator : IPanierServices
    {
        private readonly IPanierServices panierServices;

        public PricingDecorator(IPanierServices panierServices)
        {
            this.panierServices = panierServices;
        }

        public bool AjouterProduit(Panier panier, Produits produit)
        {
            throw new NotImplementedException();
        }

        public virtual decimal CalculerTotal(Panier panier)
        {
            return panierServices.CalculerTotal(panier);
        }

        public int CreatePanier(int idUtilisateur, List<Produits> produits = null)
        {
            throw new NotImplementedException();
        }

        public bool RetirerProduit(Panier panier, int produitId)
        {
            throw new NotImplementedException();
        }
    }
}
