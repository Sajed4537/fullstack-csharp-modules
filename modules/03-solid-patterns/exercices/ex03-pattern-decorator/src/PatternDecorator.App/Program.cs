using PatternDecorator.App.Decorator;
using PatternDecorator.App.Domain;
using PatternDecorator.App.Strategies;
using System;

namespace PatternDecorator.App
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

            Panier panier1 = new Panier(remisePalier, listeLignePaniers2);

            //Panier panier2 = new Panier(remisePourcentage,listeLignePaniers1);
            //Panier panier2 = new Panier(remiseFixe,listeLignePaniers1);
            Panier panier2 = new Panier(remiseCodePromoBon, listeLignePaniers1);
            //Panier panier2 = new Panier(remiseCodePromoMauvais,listeLignePaniers1);

            Console.WriteLine("=== Paniers éléctroniques ===");

            Console.WriteLine($"Total sans remise : {panier1.GetTotalPrix()}");
            Console.WriteLine($"Total avec remise : {panier1.GetTotalAvecRemise()}");

            Console.WriteLine();

            Console.WriteLine("DECORATEUR");

            ICalculateurPanier calculateurPanier1 = new CalculateurBase(remisePalier, new Result(0, 0, 0, 0));

            calculateurPanier1 = new EmballageCadeauDecorator(calculateurPanier1);
            calculateurPanier1 = new AssuranceDecorator(calculateurPanier1);
            calculateurPanier1 = new LivraisonExpressDecorator(calculateurPanier1);

            var resultat1 = calculateurPanier1.Calculer(panier1);

            Console.WriteLine($"Total final : {resultat1.TotalFinal}");
            Console.WriteLine($"Sous total : {resultat1.SousTotal}");
            Console.WriteLine($"Total avant surcharges : {resultat1.TotalAvantSurcharges}");
            Console.WriteLine($"Remise : {resultat1.Remise}");
            Console.WriteLine();
            Console.WriteLine("Liste des surcharges :");
            foreach(var item in resultat1.Surcharges)
            {
                Console.WriteLine($"- {item.Nom} - {item.Montant}");
            }

            Console.WriteLine();

            Console.WriteLine("=== Paniers alimentaires ===");

            Console.WriteLine($"Total sans remise : {panier2.GetTotalPrix()}");
            Console.WriteLine($"Total avec remise : {panier2.GetTotalAvecRemise()}");

            Console.WriteLine();

            Console.WriteLine("DECORATEUR");

            ICalculateurPanier calculateurPanier2 = new CalculateurBase(remiseCodePromoBon, new Result(0, 0, 0, 0));

            calculateurPanier2 = new EmballageCadeauDecorator(calculateurPanier2);
            calculateurPanier2 = new AssuranceDecorator(calculateurPanier2);
            calculateurPanier2 = new LivraisonExpressDecorator(calculateurPanier2);

            var resultat2 = calculateurPanier2.Calculer(panier2);

            Console.WriteLine($"Total final : {resultat2.TotalFinal}");
            Console.WriteLine($"Sous total : {resultat2.SousTotal}");
            Console.WriteLine($"Total avant surcharges : {resultat2.TotalAvantSurcharges}");
            Console.WriteLine($"Remise : {resultat2.Remise}");
            Console.WriteLine();
            Console.WriteLine("Liste des surcharges :");
            foreach (var item in resultat2.Surcharges)
            {
                Console.WriteLine($"- {item.Nom} - {item.Montant}");
            }

        }
    }
}