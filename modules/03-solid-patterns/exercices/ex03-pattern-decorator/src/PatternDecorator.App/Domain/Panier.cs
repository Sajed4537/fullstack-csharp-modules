using PatternDecorator.App.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Domain
{
    internal class Panier 
    {
       public List<LignePanier> PanierList { get; set; }
        private IRemiseStrategy RemiseStrategy;

        public Panier(IRemiseStrategy remiseStrategy, List<LignePanier> lignePaniers = null)
        {
            if(lignePaniers == null)
            {
                PanierList = new List<LignePanier>();
            }
            else
            {
                PanierList = lignePaniers;
            }
                
            RemiseStrategy = remiseStrategy;
        }

        public decimal GetTotalPrix()
        {
            decimal totalPrix = 0; 

            foreach (var panier in PanierList)
            {
                var prix = panier.PrixUnitaire * panier.Quantite;

                totalPrix += prix;
            }

            return totalPrix;
        }

        public decimal GetTotalAvecRemise()
        {
            var total = GetTotalPrix();

            return total - RemiseStrategy.CalculRemise(total);


        }
    }
}
