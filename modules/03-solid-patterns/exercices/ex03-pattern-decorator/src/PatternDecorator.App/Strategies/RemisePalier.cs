using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Strategies
{
    internal class RemisePalier : IRemiseStrategy
    {
        

        public RemisePalier()
        {

        }
        public decimal CalculRemise(decimal prixTotal)
        {
            if (prixTotal >= 300)
            {
                return 30;
            }
            else if (prixTotal >= 200)
            {
                return 15;
            }
            else if (prixTotal >= 100)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
