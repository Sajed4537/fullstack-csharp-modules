using PatternDecorator.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal class AssuranceDecorator : CalculateurDecorator
    {
        public AssuranceDecorator(ICalculateurPanier calculateurPanier) : base(calculateurPanier)
        {
        }

        public override string Name => "Assurance";

        public override decimal CalculateurMontant(Result result, Panier panier)
        {
            var pourcentage =  0.02m * result.SousTotal;

            return pourcentage;
            
        }
    }
}
