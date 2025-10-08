using CatalogueMvc.App.Models;

namespace CatalogueMvc.App.Services.PanierServices
{
    public interface IPanierServices
    {
        public Panier GetOrCreatePanier(int userId);
        public bool Add(int panierId, int produitId, int qty, out string? erreur);
        public bool Remove(int panierId, int produitId, int qty, out string? erreur);
        public decimal ComputeSubtotal(int panierId);
        public decimal GetLivraisonFees(Panier panier);
        public decimal ComputeTotal(int panierId); 
    }
}
