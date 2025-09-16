using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Strategies
{
    internal class RemisePourcentage : IRemiseStrategy
    {
        private decimal _pourcentage; 
        public decimal Pourcentage 
        {
            get => _pourcentage;
            set
            {
                if(value > 100 || value < 0)
                {
                    throw new Exception("Attention ! Le pourcentage ne doit pas étre plus grand que 100 et plus petit que 0.");
                }
                else
                {
                    _pourcentage = value;
                }
            }
        }
        public RemisePourcentage(decimal pourcentage)
        {
            Pourcentage = pourcentage;
        }
        public decimal CalculRemise(decimal prixTotal)
        {
            return prixTotal * (Pourcentage / 100);
        }
    }
}
