using PatternDecorator.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal interface ICalculateurPanier
    {
        public Result Calculer(Panier panier);
    }
}
