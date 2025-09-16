using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Decorator.Decorators
{
    internal class RemisePourcentageDecorator : PricingDecorator
    {
        private decimal _pourcentage;

       

        public decimal Pourcentage
        {
            get => _pourcentage;
            set
            {
                if (Pourcentage < 0 || Pourcentage > 1)
                {
                    _pourcentage = 0;
                }
                else
                {
                    _pourcentage = value;
                }
            }
        }

        public RemisePourcentageDecorator(IPanierServices panierServices, decimal pourcentage) : base(panierServices)
        {
            Pourcentage = pourcentage;
        }

        public override decimal CalculerTotal(Panier panier)
        {
            var total = base.CalculerTotal(panier);

            var totalRemise = total - (total * Pourcentage);
            return totalRemise;
        }
    }
}
