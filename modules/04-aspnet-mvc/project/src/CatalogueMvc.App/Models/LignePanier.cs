namespace CatalogueMvc.App.Models
{
    public class LignePanier
    {
        public int ProduitId { get; set; }
        public string Nom { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int Quantite { get; set; }
    }
}
