using PatternStrategy.App.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.App.Domain
{
    internal class Panier 
    {
       public List<LignePanier> PanierList { get; set; }
        private IRemiseStrategy RemiseStrategy;

        public Panier(List<LignePanier> lignePaniers, IRemiseStrategy remiseStrategy)
        {
            PanierList = lignePaniers;
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
