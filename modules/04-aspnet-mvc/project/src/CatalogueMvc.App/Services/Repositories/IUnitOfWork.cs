using CatalogueMvc.App.Models;

namespace CatalogueMvc.App.Services.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Produit> Produits { get; }
        IRepository<Utilisateur> Utilisateurs { get; }
        IRepository<Panier> Paniers { get; }
        int SaveChanges();
    }
}
