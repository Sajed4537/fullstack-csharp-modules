using CatalogueMvc.App.Models;

namespace CatalogueMvc.App.Services.Repositories
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private int compteur;

        private readonly IRepository<Produit> _produitsRepo;
        private readonly IRepository<Utilisateur> _utilisateursRepo;
        private readonly IRepository<Panier> _paniersRepo;

        public InMemoryUnitOfWork()
        {
            _produitsRepo = new InMemoryRepository<Produit>();
            _utilisateursRepo = new InMemoryRepository<Utilisateur>();
            _paniersRepo = new InMemoryRepository<Panier>();
        }

        public IRepository<Produit> Produits => _produitsRepo;

        public IRepository<Utilisateur> Utilisateurs => _utilisateursRepo;

        public IRepository<Panier> Paniers => _paniersRepo;

        public int SaveChanges()
        {
            return compteur++;
        }
    }
}
