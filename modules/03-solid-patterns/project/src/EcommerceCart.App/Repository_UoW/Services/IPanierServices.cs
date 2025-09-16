using EcommerceCart.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.Services
{
    internal interface IPanierServices
    {
        int CreatePanier(int idUtilisateur, List<Produits> produits = null);
        bool AjouterProduit(Panier panier, Produits produit);

        bool RetirerProduit(Panier panier, int produitId);

        decimal CalculerTotal(Panier panier);

    }
}
