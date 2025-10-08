using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.PanierServices;

namespace CatalogueMvc.App.Domain.Decorators.Remises
{
    public abstract class PricingDecorator : IPanierServices
    {
        private IPanierServices _panierServices;

        public PricingDecorator(IPanierServices panierServices)
        {
            _panierServices = panierServices;
        }

        public bool Add(int panierId, int produitId, int qty, out string? erreur)
        {
            throw new NotImplementedException();
        }

        public decimal ComputeSubtotal(int panierId)
        {
            throw new NotImplementedException();
        }

        public virtual decimal ComputeTotal(int panierId)
        {
            return _panierServices.ComputeTotal(panierId);
        }

        public decimal GetLivraisonFees(Panier panier)
        {
            throw new NotImplementedException();
        }

        public Panier GetOrCreatePanier(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int panierId, int produitId, int qty, out string? erreur)
        {
            throw new NotImplementedException();
        }
    }
}
