using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.App.Strategies
{
    internal class RemiseFixe : IRemiseStrategy
    {
        public decimal Montant { get; set; }

        public RemiseFixe(decimal montant)
        {
            Montant = montant;
        }
        public decimal CalculRemise(decimal prixTotal)
        {
            return Math.Min(Montant, prixTotal);
        }
    }
}
