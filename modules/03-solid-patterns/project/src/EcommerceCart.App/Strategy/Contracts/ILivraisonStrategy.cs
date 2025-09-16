using EcommerceCart.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Strategy.Contracts
{
    internal interface ILivraisonStrategy
    {
        decimal CalculerFraisLivraison(Panier panier);
    }
}
