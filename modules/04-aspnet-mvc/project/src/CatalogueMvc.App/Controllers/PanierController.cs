using CatalogueMvc.App.Domain.Decorators.Remises;
using CatalogueMvc.App.Domain.Strategies.Livraison;
using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.PanierServices;
using CatalogueMvc.App.Services.Repositories;
using CatalogueMvc.App.ViewModels.Paniers;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueMvc.App.Controllers
{
    public class PanierController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IPanierServices _panierServices;

        public PanierController(IUnitOfWork unitOfWork, IPanierServices panierServices)
        {
            _unitOfWork = unitOfWork;
            _panierServices = panierServices;
        }


        [HttpGet]
        public IActionResult Index(int panierId)
        {
            var panier = _unitOfWork.Paniers.GetById(panierId);

            if(panier == null)
            {
                TempData["message"] = "Le panier est introuvable.";
                return RedirectToAction("Index", "Paniers");
            }
            else
            {
                var vm = new PanierDetailsVm();
                var utilisateur = _unitOfWork.Utilisateurs.GetById(panier.IdUtilisateur);

                vm.NomUtilisateur = $"{utilisateur.Prenom} {utilisateur.Nom}";
                vm.PanierId = panierId;

                foreach(var item in panier.Produits)
                {
                    var lignePanier = new LignePanierItemVm();
                    lignePanier.PrixUnitaire = item.PrixUnitaire;
                    lignePanier.Quantite = item.Quantite;
                    lignePanier.ProduitId = item.ProduitId;
                    lignePanier.ProduitNom = item.Nom;
                    lignePanier.TotalLigne = item.PrixUnitaire * item.Quantite;

                    vm.Lignes.Add(lignePanier);
                }

                vm.SubTotal = _panierServices.ComputeSubtotal(panierId);
                vm.FraisLivraison = _panierServices.GetLivraisonFees(panier);
                vm.ModeLivraison = panier.ModeLivraison;
                vm.Total = vm.SubTotal + vm.FraisLivraison;

                var totalRemise = 0m;

                if (utilisateur.Type == TypeUtilisateur.Administrateur)
                {
                    var remise = new RemiseAdmin(_panierServices, utilisateur);
                    var totalAvantRemise = vm.SubTotal + vm.FraisLivraison;
                    totalRemise = remise.ComputeTotal(panierId);
                    vm.Total = totalRemise;
                    vm.MontantRemise = totalRemise - totalAvantRemise;
                }

                var produitsDispo = _unitOfWork.Produits.ListAll().Where(p => p.Stock > 0).ToList();

                ViewBag.ProduitsDisponibles = produitsDispo;

                return View(vm);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SetLivraison(int panierId, ModeLivraison mode)
        {
            var panier = _unitOfWork.Paniers.GetById(panierId);

            if(panier == null)
            {
                TempData["message"] = "Panier introuvable.";
                return RedirectToAction("Index", "Paniers");
            }

            panier.ModeLivraison = mode;

            _unitOfWork.SaveChanges();
            TempData["message"] = "Mode de livraison mis à jour.";
            return RedirectToAction("Index", new { panierId = panier.Id });

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddLine(int panierId, int produitId, int qty = 1)
        {
            _panierServices.Add(panierId, produitId, qty, out var err);

            if(err != null)
            {
                TempData["message"] = err ?? "Ajout impossible.";
                return RedirectToAction("Index", new { panierId });
            }
            else
            {
                TempData["message"] = "Produit ajouté au panier.";
                return RedirectToAction("Index", new { panierId });
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult RemoveLine(int panierId, int produitId, int qty = 1)
        {
            _panierServices.Remove(panierId, produitId, qty, out var err);

            if (err != null)
            {
                TempData["message"] = err ?? "Retrait impossible.";
                return RedirectToAction("Index", new { panierId });
            }
            else
            {
                TempData["message"] = "Produit retiré du panier.";
                return RedirectToAction("Index", new { panierId });
            }
        }
    }
}
