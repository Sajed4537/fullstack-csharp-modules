using HelloMvc.App.Models;
using HelloMvc.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvc.App.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            var message = "Bonjour depuis MVC";

            HelloViewModel viewModel = new HelloViewModel(message);

            return View(viewModel);
        }
    }
}
