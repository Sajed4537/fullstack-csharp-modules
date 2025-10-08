namespace CatalogueMvc.App.Domain.Strategies.Livraison
{
    public class LivraisonExpress : ILivraisonStrategy
    {
        public decimal CalculLivraison()
        {
            return 12m;
        }
    }
}
