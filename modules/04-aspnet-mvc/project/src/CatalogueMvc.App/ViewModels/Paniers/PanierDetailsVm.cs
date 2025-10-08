using CatalogueMvc.App.Domain.Strategies.Livraison;
using CatalogueMvc.App.Models;
using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.ViewModels.Paniers
{
    public class PanierDetailsVm
    {
        public int PanierId { get; set; }
        public string NomUtilisateur { get; set; }
        public List<LignePanierItemVm> Lignes { get; set; }
        public decimal SubTotal { get; set; }
        public decimal FraisLivraison { get; set; }
        public decimal Total { get; set; }
        public ModeLivraison ModeLivraison { get; set; }
        public decimal MontantRemise { get; set; }

        public PanierDetailsVm()
        {
            Lignes = new List<LignePanierItemVm>();
        }
    }
}
