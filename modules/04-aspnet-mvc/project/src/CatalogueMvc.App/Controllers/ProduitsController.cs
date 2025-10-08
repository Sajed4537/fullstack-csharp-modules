using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.Repositories;
using CatalogueMvc.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueMvc.App.Controllers
{
    public class ProduitsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ProduitsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_unitOfWork.Produits.ListAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new ProduitFormVm();
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ProduitFormVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                var produit = new Produit();
                produit.Nom = vm.Nom;
                produit.Categorie = vm.Categorie.Value;
                produit.Prix = vm.Prix;
                produit.Stock = vm.Stock;

                _unitOfWork.Produits.Add(produit);
                _unitOfWork.SaveChanges();
                TempData["message"] = "Produit créé";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            var produit = _unitOfWork.Produits.GetById(id);

            if(produit  == null)
            {
                TempData["message"] = "Produit introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(produit);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _unitOfWork.Produits.GetById(id);
            if (product == null)
            {
                TempData["message"] = "Produit introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                var vm = new ProduitFormVm();
                vm.Id = id;
                vm.Nom = product.Nom.Trim();
                vm.Prix = product.Prix;
                vm.Categorie = product.Categorie;
                vm.Stock = product.Stock;

                return View(vm);
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProduitFormVm vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                var product = new Produit();
                product.Id = id;
                product.Nom = vm.Nom.Trim();
                product.Prix = vm.Prix;
                product.Categorie = vm.Categorie.Value;
                product.Stock = vm.Stock;

                _unitOfWork.Produits.Update(product);
                _unitOfWork.SaveChanges();
                TempData["message"] = "Produit modifié.";
                return RedirectToAction("Index");

            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produit = _unitOfWork.Produits.GetById(id);

            if(produit == null)
            {
                TempData["message"] = "Produit introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(produit);
            }
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmation(int id)
        {
            var produit = _unitOfWork.Produits.GetById(id);

            if(produit == null)
            {
                TempData["message"] = "Produit introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = $"Le Produit {produit.Id} : {produit.Nom} a bien été supprimé";
                _unitOfWork.Produits.Remove(id);
                _unitOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
