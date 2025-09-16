using System;
using static System.Net.Mime.MediaTypeNames;

namespace ListManipulation.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produit> list = new List<Produit>()
            {
                new Produit(1, "Pomme", "Fruits", 1.5m),
                new Produit(2, "Viande hachée", "Viandes", 3m),
                new Produit(3, "Comté", "Produits laitiers", 1m),
                new Produit(4, "Oignion", "Légumes", 0.5m),
                new Produit(5, "Crevette", "Fruits de mer", 4m),
            };

            ListerProduit(list);

            Console.WriteLine();
            Console.WriteLine();

            Produit produit1 = new Produit(1, "Pomme 2", "Fruits", 1.5m);

            Produit produit2 = new Produit(6, "Poire", "Fruits", 1.5m);

            AjouterProduit(produit1, list);

            Console.WriteLine();
            Console.WriteLine();

            AjouterProduit(produit2, list);

            ListerProduit(list);

            Console.WriteLine();
            Console.WriteLine();

            Produit produit3 = new Produit(7, "Poulet", "Viandes", 2m);

            SupprimerProduit(produit3, list);

            Console.WriteLine();
            Console.WriteLine();

            SupprimerProduit(produit2, list);

            ListerProduit(list);

            Console.WriteLine();
            Console.WriteLine();

            MAJPrix(2m, list[0]);

            ListerProduit(list);

            Console.WriteLine();
            Console.WriteLine();

            RechercheParId(1, list);

            Console.WriteLine();
            Console.WriteLine();

            RechercherParNom("pomme", list);

            Console.WriteLine();
            Console.WriteLine();

            var listOrdreAlphabetique =  TrieOrdreAlphabetique(list);

            ListerProduit(listOrdreAlphabetique);

            Console.WriteLine();
            Console.WriteLine();

            var listePrixCroissant = TriePrixCroissant(list);

            ListerProduit(listePrixCroissant);

            Console.WriteLine();
            Console.WriteLine();


            var listePrixDecroissant = TriePrixDecroissant(list);

            ListerProduit(listePrixDecroissant);

            Console.WriteLine();
            Console.WriteLine();


        }

        public static void ListerProduit(List<Produit> listeProduit)
        {
            foreach(Produit produit in listeProduit)
            {
                produit.Afficher();
            }
        }

        public static void AjouterProduit(Produit produitAAjouter, List<Produit> listeProduit)
        {
            bool produitPresent = false;

            foreach(Produit produit in listeProduit)
            {
                if(produit.Id == produitAAjouter.Id)
                {
                    produitPresent = true;
                    Console.WriteLine("Attention ! le produit est déja présent dans la liste.");
                    
                }
            }

            if (!produitPresent)
            {
                listeProduit.Add(produitAAjouter);
                Console.WriteLine($"Le produit {produitAAjouter.Name} a bien été ajouté");
            }
        }

        public static void SupprimerProduit(Produit produitASupprimer, List<Produit> listeProduit)
        {
            bool produitAbsent = true;

            for(int i = 0; i < listeProduit.Count; i++)
            {
                if (listeProduit[i].Id == produitASupprimer.Id)
                {
                    produitAbsent = false;

                    listeProduit.Remove(listeProduit[i]);

                    Console.WriteLine($"Le produit {produitASupprimer.Name} a bien été supprimé");
                    
                }
            }

            if (produitAbsent)
            {
                Console.WriteLine("Attention ! le produit n'existe pas dans la liste");
            }
        }

        public static void MAJPrix(decimal nvPrix, Produit produitPourMAJ)
        {
            produitPourMAJ.Prix = nvPrix;

            Console.WriteLine($"Le prix du produit : {produitPourMAJ.Name} et passé à {nvPrix} euro");
        }

        public static void RechercheParId(int id, List<Produit> produitList)
        {
            foreach(Produit produit in produitList)
            {
                if(produit.Id == id)
                {
                    Console.WriteLine("Le produit a bien été trouvé grâce à son Id");     
                    produit.Afficher();
                    break;
                }
            }
        }

        public static void RechercherParNom(string nom, List<Produit> produitList)
        {
            bool produitTrouve = false;

            foreach(Produit produit in produitList)
            {
                if(produit.Name.ToLower() == nom.ToLower())
                {
                    produitTrouve = true;

                    Console.WriteLine("Le produit a bien été trouvé grâce à son Nom");
                    produit.Afficher();
                }
            }

            if (!produitTrouve)
            {
                Console.WriteLine("Attention ! Le produit n'a pas été trouvé. Il est possible que vous ayez mal orthographié son nom ou qu'il n'existe pas.");
            }

        }

        public static List<Produit> TrieOrdreAlphabetique(List<Produit> produitList)
        {
            return produitList.OrderBy(i=> i.Name).ToList();
        }

        public static List<Produit> TriePrixCroissant(List<Produit> produitList)
        {
            return produitList.OrderBy(i=> i.Prix).ToList();
        }

        public static List<Produit> TriePrixDecroissant(List<Produit> produitList)
        {
            return produitList.OrderByDescending(i => i.Prix).ToList();
        }
    }
}