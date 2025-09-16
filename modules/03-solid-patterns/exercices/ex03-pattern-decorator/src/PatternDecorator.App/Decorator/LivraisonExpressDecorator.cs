using PatternDecorator.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal class LivraisonExpressDecorator : CalculateurDecorator
    {
        public LivraisonExpressDecorator(ICalculateurPanier calculateurPanier) : base(calculateurPanier)
        {
        }

        public override string Name => "Livraison express";

        public override decimal CalculateurMontant(Result result, Panier panier)
        {
            return 12m;
        }
    }
}
