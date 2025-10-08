using Microsoft.AspNetCore.Mvc;
using ViewModelsAndServerValidation.App.Memory;
using ViewModelsAndServerValidation.App.Models;

namespace ViewModelsAndServerValidation.App.Controllers
{
    public class ProductController : Controller
    {
        private IProductStore Productstore;
        public ProductController(IProductStore productStore) 
        {
            Productstore = productStore;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Productstore.ListAll());
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = Productstore.GetById(id);

            if(product == null)
            {
                TempData["message"] = "Le produit n'a été trouvé.";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                TempData["message"] = "Le produit a été ajouté avec succés !";
                Productstore.Add(product);
                return RedirectToAction("Index");
            }
        }
    }
}
