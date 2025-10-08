namespace CatalogueMvc.App.ViewModels.Paniers
{
    public class LignePanierItemVm
    {
        public int ProduitId { get; set; }
        public string ProduitNom { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int Quantite { get; set; }
        public decimal TotalLigne { get; set; }
    }
}
