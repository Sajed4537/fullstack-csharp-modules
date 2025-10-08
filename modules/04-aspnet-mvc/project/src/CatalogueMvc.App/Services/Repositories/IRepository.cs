namespace CatalogueMvc.App.Services.Repositories
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        IEnumerable<T> ListAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(int id);
    }
}
