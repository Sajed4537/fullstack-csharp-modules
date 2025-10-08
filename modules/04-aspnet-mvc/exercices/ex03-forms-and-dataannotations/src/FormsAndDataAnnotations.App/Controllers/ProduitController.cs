using FormsAndDataAnnotations.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FormsAndDataAnnotations.App.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index(string q)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ProduitCreateVm produit)
        {
            if(!ModelState.IsValid)
            {
                return View(produit);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
