namespace CatalogueMvc.App.Domain.Strategies.Livraison
{
    public interface ILivraisonSelector
    {
        public ILivraisonStrategy GetStrategy(ModeLivraison modeLivraison);
    }
}
