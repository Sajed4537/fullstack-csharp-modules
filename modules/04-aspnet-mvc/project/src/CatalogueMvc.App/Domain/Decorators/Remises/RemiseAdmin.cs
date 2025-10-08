using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.PanierServices;

namespace CatalogueMvc.App.Domain.Decorators.Remises
{
    public class RemiseAdmin : PricingDecorator
    {
        public Utilisateur Utilisateur { get; set; }
        public RemiseAdmin(IPanierServices panierServices, Utilisateur utilisateur) : base(panierServices)
        {
            Utilisateur = utilisateur;
        }

        public override decimal ComputeTotal(int panierId)
        {
            if (Utilisateur == null || Utilisateur.Type == TypeUtilisateur.Client)
            {
                return base.ComputeTotal(panierId);
            }
            else
            {
                var total = base.ComputeTotal(panierId);

                var totalRemise = total - (total * 0.2m);
                return totalRemise;
            }
        }
    }
}
