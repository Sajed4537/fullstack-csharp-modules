using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Contracts;
using EcommerceCart.App.Repository_UoW.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.Services
{

    internal class PanierServices : IPanierServices
    {
        public IPanierRepository panierRepository {  get; set; }
        public IProduitsRepository produitsRepository { get; set; }
        public IUtilisateursRepository utilisateursRepository { get; set; }
        public IUnitOfWork UoW { get; set; }
        public PanierServices() 
        {
            panierRepository = new InMemoryPanierRepository();
            produitsRepository = new InMemoryProduitsRepository();
            utilisateursRepository = new InMemoryUtilisateursRepository();
            UoW = new InMemoryUnitOfWork();
        }
        
        public int CreatePanier(int idUtilisateur, List<Produits> produits = null)
        {
           var utilisateur =  utilisateursRepository.GetById(idUtilisateur);

            if(utilisateur == null)
            {
                return 0;
            }
            else
            {
                var newPanier = new Panier
                {
                    IdUtilisateur = idUtilisateur,
                };

                panierRepository.Add(newPanier);
                UoW.SaveChanges();
                return newPanier.Id;
            }
        }

        public bool AjouterProduit(Panier panier, Produits produit)
        {
            if(produit == null || panier == null) return false;

            else
            {
                panier.Produits.Add(produit);
                produit.Stock -= 1;
                produitsRepository.Update(produit);
                return true;
            }
        }

        public bool RetirerProduit(Panier panier, int produitId)
        {
            if (panier?.Produits == null) return false;

            var item = panier.Produits.FirstOrDefault(p => p.Id == produitId);
            if (item == null) return false;

            panier.Produits.Remove(item);

            var produit = produitsRepository.GetById(produitId);
            if (produit == null) return false;

            produit.Stock += 1;
            produitsRepository.Update(produit);
            return true;

        }

        public decimal CalculerTotal(Panier panier)
        {
            decimal total = 0;

            foreach(var item in panier.Produits)
            {
                var prix = item.Prix;

                total = total += prix;
            }
            return total;
        }
    }
}
