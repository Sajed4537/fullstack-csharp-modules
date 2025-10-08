using ViewModelsAndServerValidation.App.Models;

namespace ViewModelsAndServerValidation.App.Services
{
    public interface IProductStore
    {
        public bool Add(Product product);
        public IEnumerable<Product> GetAll();
        public Product? GetById(int id);
        public Product? ExistByName(string name, int? exceptId);
        public Product Update(Product product);
        public bool Remove(int id);

    }
}
