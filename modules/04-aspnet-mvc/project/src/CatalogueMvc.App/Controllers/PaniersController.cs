using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.Repositories;
using CatalogueMvc.App.ViewModels.Paniers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace CatalogueMvc.App.Controllers
{
    public class PaniersController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PaniersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.Paniers.ListAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var utilisateurs = _unitOfWork.Utilisateurs.ListAll();

            var vm = new PanierCreateVm();

            vm.Utilisateurs = utilisateurs.Select(i => new SelectListItem() { Value = i.Id.ToString(), Text = $"{i.Nom} {i.Prenom}" });

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(PanierCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                var utilisateurs = _unitOfWork.Utilisateurs.ListAll();

                vm.Utilisateurs = utilisateurs.Select(i => new SelectListItem() { Value = i.Id.ToString(), Text = $"{i.Nom} {i.Prenom}" });

                return View(vm);
            }
            else
            {
                var nvPanier = new Panier();

                nvPanier.IdUtilisateur = vm.IdUtilisateur;
                _unitOfWork.Paniers.Add(nvPanier);
                _unitOfWork.SaveChanges();
                TempData["message"] = "Panier créé avec succès.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var panier = _unitOfWork.Paniers.GetById(id);

            if (panier == null)
            {
                TempData["message"] = "Panier introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                var vm = new PanierDetailsVm();

                var utilisateur = _unitOfWork.Utilisateurs.GetById(panier.IdUtilisateur);

                vm.NomUtilisateur = $"{utilisateur.Prenom} {utilisateur.Nom}";

                vm.PanierId = panier.Id;

                decimal total = 0m;
                
                foreach(var item in panier.Produits)
                {
                    var lignePanier = new LignePanierItemVm();
                    lignePanier.ProduitId = item.ProduitId;
                    lignePanier.ProduitNom = item.Nom;
                    lignePanier.PrixUnitaire = item.PrixUnitaire;
                    lignePanier.Quantite= item.Quantite;
                    lignePanier.TotalLigne = item.PrixUnitaire * item.Quantite;

                    total += lignePanier.TotalLigne;

                    vm.Lignes.Add(lignePanier);

                }

                vm.SubTotal = total;

                return View(vm);

            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var panier = _unitOfWork.Paniers.GetById(id);

            if (panier == null)
            {
                TempData["message"] = "Panier introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(panier);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmation(int id)
        {
            var panier = _unitOfWork.Paniers.GetById(id);

            if (panier == null)
            {
                TempData["message"] = "Panier introuvable.";
                return RedirectToAction("Index");
            }
            else
            {
                var utilisateur = _unitOfWork.Utilisateurs.GetById(panier.IdUtilisateur);

                TempData["message"] = $"Le Panier {panier.Id} appartenant à {utilisateur.Prenom} {utilisateur.Nom} a bien été supprimé";
                _unitOfWork.Paniers.Remove(id);
                _unitOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
