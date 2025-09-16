using PatternDecorator.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal class EmballageCadeauDecorator : CalculateurDecorator
    {
        public EmballageCadeauDecorator(ICalculateurPanier calculateurPanier) : base(calculateurPanier)
        {
        }

        public override string Name => "Emballage cadeau";

        public override decimal CalculateurMontant(Result result, Panier panier)
        {
            var quantite = 0;
            foreach(var item in panier.PanierList)
            {
                quantite += item.Quantite;
            }

            return quantite * 2m;


        }
    }
}
