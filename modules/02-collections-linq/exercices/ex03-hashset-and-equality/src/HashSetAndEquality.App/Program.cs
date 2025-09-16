using System;

namespace HashSetAndEquality.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produit> list = new List<Produit>()
            {
                new Produit(1, "Pomme", "Fruits", 1.5m),
                new Produit(1, "Viande hachée", "Viandes", 3m),
                new Produit(3, "Comté", "Produits laitiers", 1m),
                new Produit(4, "Oignion", "Légumes", 0.5m),
                new Produit(5, "Crevette", "Fruits de mer", 4m),
            };


            HashSet<Produit> produits = new HashSet<Produit>();

            foreach (Produit produit in list)
            {
                produits.Add(produit);
            }

            Console.WriteLine("List");

            foreach (Produit produit in list)
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Hashset");

            foreach (Produit produit in produits)
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Produit produit1 = new Produit(3, "produit 1", "Catégorie 1", 1.6m);

            Console.WriteLine("L'ajout du produit retourne : " + produits.Add(produit1));

        }
    }
}