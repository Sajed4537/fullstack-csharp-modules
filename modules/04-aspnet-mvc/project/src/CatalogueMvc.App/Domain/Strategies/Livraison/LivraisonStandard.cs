namespace CatalogueMvc.App.Domain.Strategies.Livraison
{
    public class LivraisonStandard : ILivraisonStrategy
    {
        public decimal CalculLivraison()
        {
            return 5m;
        }
    }
}
