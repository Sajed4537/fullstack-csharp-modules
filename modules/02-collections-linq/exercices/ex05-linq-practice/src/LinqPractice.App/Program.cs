namespace LinqPractice.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produit> list = new List<Produit>()
            {
                new Produit(1, "Pomme Golden", "Fruits", 20m),
                new Produit(2, "Banane Cavendish", "Fruits", 18m),
                new Produit(3, "Orange Valencia", "Fruits", 22m),
                new Produit(4, "Café Arabica 1kg", "Épicerie", 336m),
                new Produit(5, "Thé Vert Sencha", "Épicerie", 120m),
                new Produit(6, "Riz Basmati 5kg", "Épicerie", 450m),
                new Produit(7, "Eau Minérale Evian 1.5L", "Boissons", 12m),
                new Produit(8, "Coca-Cola 1.5L", "Boissons", 15m),
                new Produit(9, "Jus d’Orange Tropicana 1L", "Boissons", 30m),
                new Produit(10, "Casque Audio Sony", "Électronique", 1299m),
                new Produit(11, "Smartphone Samsung Galaxy", "Électronique", 7690m),
                new Produit(12, "Ordinateur Portable Dell", "Électronique", 5490m),
                new Produit(13, "Jean Levi’s 501", "Vêtements", 895m),
                new Produit(14, "T-Shirt Lacoste", "Vêtements", 320m),
                new Produit(15, "Chaussures de Sport Nike", "Vêtements", 745m),
                new Produit(16, "Canapé IKEA 3 places", "Maison", 2490m),
                new Produit(17, "Table Basse Bois", "Maison", 990m),
                new Produit(18, "Chaise Bureau Ergonomique", "Maison", 1290m),
                new Produit(19, "Shampoing Garnier", "Hygiène", 60m),
                new Produit(20, "Dentifrice Colgate", "Hygiène", 40m),


            };


            foreach (var group in list.GroupBy(i => i.Categorie))
            {
                Console.WriteLine($"Catégorie : {group.Key} - nombre d'articles : {group.Count()}");

                foreach (var produit in group)
                {
                    Console.WriteLine($"   Produit : {produit.Name}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Moyenne des prix : {list.Average(i => i.Prix)} euro");
            Console.WriteLine($"Prix le plus bas : {list.Min(i => i.Prix)} euro");
            Console.WriteLine($"Prix le plus haut : {list.Max(i => i.Prix)} euro");
            Console.WriteLine($"Somme des prix : {list.Sum(i => i.Prix)} euro");

            Console.WriteLine();
            Console.WriteLine();

            foreach (var group in list.GroupBy(i => i.Categorie))
            {
                Console.WriteLine($"Catégorie : {group.Key}");

                foreach (var produit in group.OrderBy(i => i.Prix).Take(1))
                {
                    Console.WriteLine($"   Produit : {produit.Name} - Prix : {produit.Prix} euro");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (var group in list.Where(i => i.Prix > 5m).GroupBy(i => i.Categorie))
            {
                Console.WriteLine($"Catégorie : {group.Key}");

                Console.WriteLine($"Moyenne des prix : {group.Average(i => i.Prix):F2}");

                Console.WriteLine($"Prix le plus bas : {group.Min(i => i.Prix):F2}");

                Console.WriteLine($"Prix le plus haut : {group.Max(i => i.Prix):F2}");

                Console.WriteLine($"Somme des prix : {group.Sum(i => i.Prix):F2}");

                Console.WriteLine();
            }


        }
    }
}


