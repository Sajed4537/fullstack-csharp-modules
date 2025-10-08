using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.Repositories;
using CatalogueMvc.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueMvc.App.Controllers
{
    public class UtilisateursController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public UtilisateursController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_unitOfWork.Utilisateurs.ListAll());
        }


        [HttpGet]
        public IActionResult Create()
        {
            var vm = new UtilisateurFormVm();
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(UtilisateurFormVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                var utilisateur = new Utilisateur();
                utilisateur.Nom = vm.Nom;
                utilisateur.Prenom = vm.Prenom;
                utilisateur.Email = vm.Email;
                utilisateur.Type = vm.Type;

                _unitOfWork.Utilisateurs.Add(utilisateur);
                _unitOfWork.SaveChanges();
                TempData["message"] = "Utilisateur créé";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            var utilisateur = _unitOfWork.Utilisateurs.GetById(id);

            if (utilisateur == null)
            {
                TempData["message"] = "Utilisateur introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(utilisateur);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var utilisateur = _unitOfWork.Utilisateurs.GetById(id);
            if (utilisateur == null)
            {
                TempData["message"] = "Utilisateur introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                var vm = new UtilisateurFormVm();
                vm.Id = id;
                vm.Nom = utilisateur.Nom.Trim();
                vm.Prenom = utilisateur.Prenom.Trim();
                vm.Email = utilisateur.Email.Trim();
                vm.Type = utilisateur.Type;

                return View(vm);
            }

        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UtilisateurFormVm vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            else
            {
                var utilisateur = new Utilisateur();
                utilisateur.Id = id;
                utilisateur.Nom = vm.Nom.Trim();
                utilisateur.Prenom = vm.Prenom.Trim();
                utilisateur.Email = vm.Email.Trim();
                utilisateur.Type = vm.Type;

                _unitOfWork.Utilisateurs.Update(utilisateur);
                _unitOfWork.SaveChanges();
                TempData["message"] = "Utilisateur modifié.";
                return RedirectToAction("Index");

            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var utilisateur = _unitOfWork.Utilisateurs.GetById(id);

            if (utilisateur == null)
            {
                TempData["message"] = "Utilisateur introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(utilisateur);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmation(int id)
        {
            var utilisateur = _unitOfWork.Utilisateurs.GetById(id);

            if (utilisateur == null)
            {
                TempData["message"] = "Utilisateur introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = $"L'Utilisateur {utilisateur.Id} : {utilisateur.Nom} {utilisateur.Prenom} a bien été supprimé";
                _unitOfWork.Utilisateurs.Remove(id);
                _unitOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
