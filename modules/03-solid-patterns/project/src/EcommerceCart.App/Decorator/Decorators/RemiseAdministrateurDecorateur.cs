using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Decorator.Decorators
{
    internal class RemiseAdministrateurDecorateur : PricingDecorator
    {
        public Utilisateurs Utilisateurs { get; set; }

        public RemiseAdministrateurDecorateur(IPanierServices panierServices, Utilisateurs utilisateurs) : base(panierServices)
        {
            Utilisateurs=utilisateurs;
        }

        public override decimal CalculerTotal(Panier panier)
        {
            if(Utilisateurs == null || Utilisateurs.Type == TypeUtilisateur.Client)
            {
                return base.CalculerTotal(panier);
            }
            else
            {
                var total = base.CalculerTotal(panier);

                var totalRemise = total - (total * 0.2m); 
                return totalRemise;
            }
        }
    }
}
