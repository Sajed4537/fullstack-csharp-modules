using EcommerceCart.App.Domain;
using EcommerceCart.App.Strategy.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Strategy.Strategies
{
    internal class ExpressLivraison : ILivraisonStrategy
    {
        public decimal CalculerFraisLivraison(Panier panier)
        {
            return 12m;
        }
    }
}
