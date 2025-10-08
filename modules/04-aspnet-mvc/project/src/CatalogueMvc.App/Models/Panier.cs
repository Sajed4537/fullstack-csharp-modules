using CatalogueMvc.App.Domain.Strategies.Livraison;

namespace CatalogueMvc.App.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public int IdUtilisateur { get; set; }
        public List<LignePanier> Produits { get; set; }
        public ModeLivraison ModeLivraison { get; set; } = ModeLivraison.Standard;
        public Panier()
        {
            Produits = new List<LignePanier>();
        }
    }
}
