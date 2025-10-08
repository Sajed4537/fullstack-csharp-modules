using System.Runtime.CompilerServices;
using System.Xml.Linq;
using ViewModelsAndServerValidation.App.Models;

namespace ViewModelsAndServerValidation.App.Services
{
    public class ProductStoreInMemory : IProductStore
    {
        private List<Product> _productStore;
        private int idIncrement = 1; 

        public ProductStoreInMemory()
        {
            _productStore = new List<Product>();
        }

        public bool Add(Product product)
        {
            var doublonName = _productStore.FirstOrDefault(i=> String.Equals(i.Name, product.Name, StringComparison.OrdinalIgnoreCase));

            if (doublonName != null)
            {
                return false;
            }
            else
            {
                product.Id = idIncrement;
                idIncrement++;
                _productStore.Add(product);
                return true;
            }
        }

        public Product? ExistByName(string name, int? exceptId)
        {
            return _productStore.FirstOrDefault(i => String.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase) && (!exceptId.HasValue || i.Id != exceptId.Value));
        }

        public IEnumerable<Product> GetAll()
        {
            return _productStore;
        }

        public Product? GetById(int id)
        {
            return _productStore.FirstOrDefault(i => i.Id == id);
        }

        public bool Remove(int id)
        {
            var produitSupp = _productStore.FirstOrDefault(i => i.Id == id);

            if(produitSupp != null)
            {
                _productStore.Remove(produitSupp);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Product Update(Product product)
        {
            var productUpdate = _productStore.FirstOrDefault(i => i.Id == product.Id);

            if(productUpdate != null)
            {
                productUpdate.Name = product.Name;
                productUpdate.Categorie = product.Categorie;
                productUpdate.Prix = product.Prix;
                return productUpdate;
            }
            else
            {
                return product;
            }
        }
    }
}
