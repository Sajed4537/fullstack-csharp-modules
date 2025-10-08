using ViewModelsAndServerValidation.App.Memory;
using ViewModelsAndServerValidation.App.Models;

namespace ViewModelsAndServerValidation.App.Service
{
    public class ProductStoreInMemory : IProductStore
    {
        private readonly List<Product> products;

        private int idIncrement = 1;

        public ProductStoreInMemory() 
        {
            products = new List<Product>();
        }
        public void Add(Product product)
        {
            product.Id = idIncrement;
            idIncrement++;
            products.Add(product);

        }

        public Product? GetById(int id)
        {
            return products.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Product> ListAll()
        {
            return products;
        }

        public bool Remove(int id)
        {
            for(int i = 1; i <products.Count; i++)
            {
                if (products[i].Id == id)
                {
                    products.Remove(products[i]);
                    return true;
                }
            }
            return false; 
        }
    }
}
