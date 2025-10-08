using ViewModelsAndServerValidation.App.Models;

namespace ViewModelsAndServerValidation.App.Memory
{
    public interface IProductStore
    {
        public IEnumerable<Product> ListAll();
        public Product? GetById(int id);
        public void Add(Product product);
        public bool Remove(int id);
    }
}
