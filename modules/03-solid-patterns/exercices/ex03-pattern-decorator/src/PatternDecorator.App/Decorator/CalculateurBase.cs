using PatternDecorator.App.Domain;
using PatternDecorator.App.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal class CalculateurBase : ICalculateurPanier
    {
        IRemiseStrategy RemiseStrategy { get; set; }

        public CalculateurBase(IRemiseStrategy remiseStrategy, Result result)
        {
            RemiseStrategy = remiseStrategy;
        }
        public Result Calculer(Panier panier)
        {
            decimal sousTotal = 0;
            if(panier  == null | panier.PanierList == null | panier.PanierList.Count == 0)
            {
                Result resultatNull = new Result(0, 0, 0, 0);
                return resultatNull;
            }
            foreach(var item in panier.PanierList)
            {
                var quantite = item.Quantite;
                var prixUnitaire = item.PrixUnitaire;

                var prix = quantite * prixUnitaire;

                sousTotal += prix;
            }

            var remise = RemiseStrategy.CalculRemise(sousTotal);

            var totalAvantSurcharge = sousTotal - remise;

            Result result = new Result(sousTotal, remise, totalAvantSurcharge, totalAvantSurcharge);

            return result;
        }
    }
}
