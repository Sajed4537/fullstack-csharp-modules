using System.Security.Cryptography.X509Certificates;

namespace CatalogueMvc.App.Domain.Strategies.Livraison
{
    public class LivraisonSelector : ILivraisonSelector
    {
        public ILivraisonStrategy GetStrategy(ModeLivraison modeLivraison)
        {
            
            ILivraisonStrategy strategy = null;

            switch (modeLivraison)
            {
                case (ModeLivraison.Express):
                    strategy = new LivraisonExpress();
                    break;
                case (ModeLivraison.Standard):
                    strategy = new LivraisonStandard();
                    break;
                default:
                    return strategy = new LivraisonStandard(); 
            }
            return strategy;
        }
    }
}
