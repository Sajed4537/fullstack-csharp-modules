using PatternStrategy.App.Domain;
using PatternStrategy.App.Strategies;
using System;

namespace PatternStrategy.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produit> produitsAlimentaire = new List<Produit>()
            {
                new Produit(1, "Banane"),
                new Produit(2, "Pomme"),
                new Produit(3, "Courgette"),
                new Produit(4, "Patate")
            };

            LignePanier lignePanier1 = new LignePanier(produitsAlimentaire[0], 2, 1.5m);
            LignePanier lignePanier2 = new LignePanier(produitsAlimentaire[1], 4, 2m);
            LignePanier lignePanier3 = new LignePanier(produitsAlimentaire[2], 5, 7.6m);
            LignePanier lignePanier4 = new LignePanier(produitsAlimentaire[3], 8, 3.6m);

            List<LignePanier> listeLignePaniers1 = new List<LignePanier>();
            listeLignePaniers1.Add(lignePanier1);
            listeLignePaniers1.Add(lignePanier2);
            listeLignePaniers1.Add(lignePanier3);
            listeLignePaniers1.Add(lignePanier4);

            List<Produit> produitsElectroniques = new List<Produit>
            {
                new Produit(5, "Iphone 16"),
                new Produit(6, "Ordinateur")
            };

            LignePanier lignePanier5 = new LignePanier(produitsElectroniques[0], 1, 899);
            LignePanier lignePanier6 = new LignePanier(produitsElectroniques[1], 1, 1000);

            List<LignePanier> listeLignePaniers2 = new List<LignePanier>();
            listeLignePaniers2.Add(lignePanier5);
            listeLignePaniers2.Add(lignePanier6);

            IRemiseStrategy remiseFixe = new RemiseFixe(10);
            IRemiseStrategy remisePourcentage = new RemisePourcentage(20);
            IRemiseStrategy remisePalier = new RemisePalier();
            IRemiseStrategy remiseCodePromoBon = new RemiseCodePromo("NOEL20");
            IRemiseStrategy remiseCodePromoMauvais = new RemiseCodePromo("PROMO");
            IRemiseStrategy pasDeRemise = new PasDeRemise();

            Panier panier1 = new Panier(listeLignePaniers2, remisePalier);

            Console.WriteLine("=== Paniers éléctroniques ===");

            Console.WriteLine($"Total sans remise : {panier1.GetTotalPrix()}");
            Console.WriteLine($"Total avec remise : {panier1.GetTotalAvecRemise()}");

            //Panier panier2 = new Panier(listeLignePaniers1, remisePourcentage);
            //Panier panier2 = new Panier(listeLignePaniers1, remiseFixe);
            Panier panier2 = new Panier(listeLignePaniers1, remiseCodePromoBon);
            //Panier panier2 = new Panier(listeLignePaniers1, remiseCodePromoMauvais);

            Console.WriteLine("=== Paniers alimentaires ===");

            Console.WriteLine($"Total sans remise : {panier2.GetTotalPrix()}");
            Console.WriteLine($"Total avec remise : {panier2.GetTotalAvecRemise()}");
        }
    }
}