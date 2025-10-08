using CatalogueMvc.App.Domain.Strategies.Livraison;
using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.Repositories;

namespace CatalogueMvc.App.Services.PanierServices
{
    public class PanierServices : IPanierServices
    {
        private IUnitOfWork _unitOfWork;
        private ILivraisonSelector _livraisonSelector;
        public PanierServices(IUnitOfWork unitOfWork, ILivraisonSelector livraisonSelector)
        {
            _unitOfWork = unitOfWork;
            _livraisonSelector = livraisonSelector;
        }
        public bool Add(int panierId, int produitId, int qty, out string? erreur)
        {
            var panier = _unitOfWork.Paniers.GetById(panierId);
            var produit = _unitOfWork.Produits.GetById(produitId);

            if (panier == null || produit == null)
            {
                erreur = "Panier ou produit introuvable.";
                return false;
            }
            else if(qty <= 0)
            {
                erreur = "Quantité invalide.";
                return false;
            }
            else if (produit.Stock < qty)
            {
                erreur = "Stock insuffisant.";
                return false;
            }
            else
            {
                var ligne = panier.Produits.FirstOrDefault(i => i.ProduitId == produitId);
                if (ligne == null)
                {
                    ligne = new LignePanier();
                    ligne.ProduitId = produitId;
                    ligne.PrixUnitaire = produit.Prix;
                    ligne.Nom = produit.Nom;
                    ligne.Quantite = qty;
                    panier.Produits.Add(ligne);
                    erreur = null;
                    produit.Stock -= qty;
                    return true;

                }
                ligne.Quantite += qty;
                produit.Stock -= qty;
                _unitOfWork.SaveChanges();
                erreur = null;
                return true;
            }
        }

        public decimal ComputeSubtotal(int panierId)
        {
            var panier = _unitOfWork.Paniers.GetById(panierId);

            if(panier == null)
            {
                return 0m;
            }
            decimal total = 0m;
            foreach(var item in panier.Produits)
            {
                var prix = item.PrixUnitaire * item.Quantite;
                total += prix;
            }
            _unitOfWork.SaveChanges();
            return total;
        }

        public decimal ComputeTotal(int panierId)
        {
            var panier = _unitOfWork.Paniers.GetById(panierId);
            if (panier == null) return 0m;

            var sousTotal = ComputeSubtotal(panierId);
            var frais = GetLivraisonFees(panier);
            _unitOfWork.SaveChanges();
            return sousTotal + frais;
        }

        public decimal GetLivraisonFees(Panier panier)
        {
            var strategy = _livraisonSelector.GetStrategy(panier.ModeLivraison);
            _unitOfWork.SaveChanges();
            return strategy.CalculLivraison();
        }

        public Panier GetOrCreatePanier(int userId)
        {
            var paniers = _unitOfWork.Paniers.ListAll();

            foreach(var panier in paniers)
            {
                if(panier.IdUtilisateur == userId)
                {
                    return panier;
                }
            }

            var panierReturn = new Panier();
            panierReturn.IdUtilisateur = userId;
            _unitOfWork.Paniers.Add(panierReturn);
            _unitOfWork.SaveChanges();
            return panierReturn;
        }

        public bool Remove(int panierId, int produitId, int qty, out string? erreur)
        {
            var panier = _unitOfWork.Paniers.GetById(panierId);
            var produit = _unitOfWork.Produits.GetById(produitId);
            var ligne = panier.Produits.FirstOrDefault(i => i.ProduitId == produitId);

            if (panier == null || produit == null || ligne == null)
            {
                erreur = "Panier, produit ou ligne produit introuvable.";
                return false;
            }
            else if (qty <= 0)
            {
                erreur = "Quantité invalide.";
                return false;
            }
            else if (ligne.Quantite < qty)
            {
                erreur = "Quantité à retirer trop élevée.";
                return false;
            }
            else
            {
                ligne.Quantite -= qty;
                if(ligne.Quantite == 0)
                {
                    panier.Produits.Remove(ligne);
                }

                produit.Stock += qty;
                _unitOfWork.SaveChanges();
                erreur = null;
                return true;
            }

        }
    }
}
