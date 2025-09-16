using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.App.Strategies
{
    internal class PasDeRemise : IRemiseStrategy
    {

        public PasDeRemise() 
        { }
        public decimal CalculRemise(decimal prixTotal)
        {
            return 0;
        }
    }
}
