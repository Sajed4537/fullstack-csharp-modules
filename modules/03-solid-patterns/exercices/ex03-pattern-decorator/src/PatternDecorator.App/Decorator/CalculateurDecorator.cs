using PatternDecorator.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal abstract class CalculateurDecorator : ICalculateurPanier
    {
        private readonly ICalculateurPanier CalculateurPanier;
        public abstract string Name { get;}


        public CalculateurDecorator(ICalculateurPanier calculateurPanier)
        {
            CalculateurPanier = calculateurPanier;
        }
        public Result Calculer(Panier panier)
        {
            var calcul = CalculateurPanier.Calculer(panier);

            var montant = CalculateurMontant(calcul, panier);

            if(montant <= 0)
            {
                return calcul;
            }
            else
            {
                calcul.Surcharges.Add(new Surcharge(Name, montant));
                calcul.TotalFinal += montant;
                return calcul;
            }

        }

        public abstract decimal CalculateurMontant(Result result, Panier panier);
    }
}
