using System;

namespace LinqIntroduction.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produit> list = new List<Produit>()
            {
                new Produit(1, "A Produit 1", "Catégorie 1", 2m),
                new Produit(2, "B Produit 2", "Catégorie 2", 1.3m),
                new Produit(3, "C Produit 3", "Catégorie 3", 1.5m),
                new Produit(4, "D Produit 4", "Catégorie 4", 33.6m),
                new Produit(5, "E Produit 5", "Catégorie 5", 76.8m),
                new Produit(6, "F Produit 6", "Catégorie 6", 4.5m),
                new Produit(6, "F Produit 6", "Catégorie 6", 4.5m)
            };


            foreach(Produit produit in list.Where(i => i.Prix > 10m))
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            var nomsProduits = list.Select(i => i.Name);

            foreach (string nom in nomsProduits)
            {
                Console.WriteLine(nom);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Trie prix croissant");

            foreach(Produit produit in list.OrderBy(i => i.Prix))
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Trie prix décroissant");

            foreach (Produit produit in list.OrderByDescending(i => i.Prix))
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Trie par nom en ordre alphabétique");

            foreach (Produit produit in list.OrderBy(i => i.Name))
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Les 3 premiers");

            foreach (Produit produit in list.Take(3))
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Saut des 2 premiers");

            foreach (Produit produit in list.Skip(2))
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Utilisation de DistinctBy(NOM)");

            foreach (Produit produit in list.DistinctBy(i => i.Name))
            {
                produit.Afficher();
            }




        }
    }
}