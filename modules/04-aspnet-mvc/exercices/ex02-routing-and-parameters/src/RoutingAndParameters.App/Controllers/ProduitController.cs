using Microsoft.AspNetCore.Mvc;

namespace RoutingAndParameters.App.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(id);
        }

        public IActionResult Search(string q)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                q = "Aucune recherche envoyée";
            }
            return View("Search",q);
        }
    }
}
