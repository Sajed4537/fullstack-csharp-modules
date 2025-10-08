using Microsoft.AspNetCore.Mvc;
using ViewModelsAndServerValidation.App.Models;
using ViewModelsAndServerValidation.App.Services;
using ViewModelsAndServerValidation.App.ViewModels;

namespace ViewModelsAndServerValidation.App.Controllers
{
    public class ProductController : Controller
    {
        private IProductStore ProductStore;

        public ProductController(IProductStore productStore)
        {
            ProductStore = productStore;
        }

        public IActionResult Index()
        {
            var products = ProductStore.GetAll();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = ProductStore.GetById(id);
            if(product == null)
            {
                TempData["message"] = "Produit introuvable.";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new ProductFormVm();

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ProductFormVm vm)
        {
            var doublon = ProductStore.ExistByName(vm.Name, vm.Id);
           
            if (doublon != null)
            {
                ModelState.AddModelError("Name", "Ce nom existe déjà.");
                return View(vm);
            }
            else if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                var product = new Product();
                product.Name = vm.Name.Trim();
                product.Prix = vm.Prix;
                product.Categorie = vm.Categorie.Value;

                var confirmation = ProductStore.Add(product);

                if (!confirmation)
                {
                    TempData["message"] = "Echec de la création du produit.";
                    return RedirectToAction("Index");
                }

                TempData["message"] = "Produit créé.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = ProductStore.GetById(id);
            if(product == null)
            {
                TempData["message"] = "Produit introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                var vm = new ProductFormVm();

                vm.Id = product.Id;
                vm.Name = product.Name.Trim();
                vm.Prix = product.Prix;
                vm.Categorie = product.Categorie;

                return View(vm);
            }
                
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductFormVm vm)
        {
            var doublon = ProductStore.ExistByName(vm.Name, id);

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else if (doublon != null)
            {
                ModelState.AddModelError("Name", "Ce nom existe déjà."); 
                return View(vm);
            }
            else
            {
                var product = new Product();
                product.Id = id;
                product.Name = vm.Name.Trim();
                product.Prix = vm.Prix;
                product.Categorie = vm.Categorie.Value;

                ProductStore.Update(product);
                TempData["message"] = "Produit modifié.";
                return RedirectToAction("Index");

            }
        }
    }
}
