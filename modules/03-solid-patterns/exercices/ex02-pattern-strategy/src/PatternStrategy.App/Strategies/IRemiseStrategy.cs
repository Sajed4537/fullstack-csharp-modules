using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.App.Strategies
{
    internal interface IRemiseStrategy
    {
        public decimal CalculRemise(decimal prixTotal);
    }
}
