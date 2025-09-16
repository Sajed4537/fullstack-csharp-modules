using System;
using static System.Net.Mime.MediaTypeNames;

namespace DictionaryBasics.App
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

            Dictionary<int, Produit> dictionnaire = new Dictionary<int, Produit>();

            foreach (Produit produit in list)
            {
                dictionnaire.Add(produit.Id, produit);
            }

            ListerProduit(dictionnaire);

            Console.WriteLine();
            Console.WriteLine();

            Produit produit1 = new Produit(1, "Pomme 2", "Fruits", 1.5m);

            Produit produit2 = new Produit(6, "Poire", "Fruits", 1.5m);

            AjouterProduit(produit1, dictionnaire, list);

            Console.WriteLine();
            Console.WriteLine();

            AjouterProduit(produit2, dictionnaire, list);

            ListerProduit(dictionnaire);

            Console.WriteLine();
            Console.WriteLine();

            Produit produit3 = new Produit(7, "Poulet", "Viandes", 2m);

            SupprimerProduit(produit3, dictionnaire, list);

            Console.WriteLine();
            Console.WriteLine();

            SupprimerProduit(produit2, dictionnaire, list);

            ListerProduit(dictionnaire);

            Console.WriteLine();
            Console.WriteLine();

            MAJPrix(2m, list[0]);

            ListerProduit(dictionnaire);

            Console.WriteLine();
            Console.WriteLine();

            RechercheParId(1, dictionnaire);

            Console.WriteLine();
            Console.WriteLine();

            RechercherParNom("pomme", list);

            Console.WriteLine();
            Console.WriteLine();

            var listOrdreAlphabetique = TrieOrdreAlphabetique(list);

            foreach(Produit produit in listOrdreAlphabetique)
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            var listePrixCroissant = TriePrixCroissant(list);

            foreach (Produit produit in listePrixCroissant)
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();


            var listePrixDecroissant = TriePrixDecroissant(list);

            foreach (Produit produit in listePrixDecroissant)
            {
                produit.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

        }

        public static void ListerProduit(Dictionary<int,Produit> dictionnaireProduit)
        {
            foreach (KeyValuePair<int, Produit> pair in dictionnaireProduit)
            {
                pair.Value.Afficher();
            }
        }

        public static void AjouterProduit(Produit produitAAjouter, Dictionary<int, Produit> dictionnaireProduit, List<Produit> listeProduit)
        {
            bool produitPresent = false;

            if (dictionnaireProduit.ContainsKey(produitAAjouter.Id))
            {
                produitPresent = true;
                Console.WriteLine("Attention ! le produit est déja présent dans la liste.");

            }

            if (!produitPresent)
            {
                dictionnaireProduit.Add(produitAAjouter.Id, produitAAjouter);
                listeProduit.Add(produitAAjouter);
                Console.WriteLine($"Le produit {produitAAjouter.Name} a bien été ajouté");
            }
        }

        public static void SupprimerProduit(Produit produitASupprimer, Dictionary<int, Produit> dictionnaireProduit, List<Produit> listeProduit)
        {
            bool produitAbsent = true;

            if (dictionnaireProduit.ContainsKey(produitASupprimer.Id))
            {
                produitAbsent = false;

                dictionnaireProduit.Remove(produitASupprimer.Id);
                listeProduit.Remove(produitASupprimer);


                Console.WriteLine($"Le produit {produitASupprimer.Name} a bien été supprimé");

            }

            if (produitAbsent)
            {
                Console.WriteLine("Attention ! le produit n'existe pas dans la liste");
            }
        }

        public static void MAJPrix(decimal nvPrix, Produit produitPourMAJ)
        {
            produitPourMAJ.Prix = nvPrix;

            Console.WriteLine($"Le prix du produit : {produitPourMAJ.Name} et passé à {produitPourMAJ.Prix} euro");
        }

        public static void RechercheParId(int id, Dictionary<int, Produit> dictionnaireProduit)
        {
            if (dictionnaireProduit.ContainsKey(id))
            {
                Console.WriteLine("Le produit a bien été trouvé grâce à son Id");

                dictionnaireProduit[id].Afficher();
            }
            else
            {
                Console.WriteLine("Le produit n'existe pas");
            }
        }

        public static void RechercherParNom(string nom, List<Produit> produitList)
        {
            bool produitTrouve = false;

            foreach (Produit produit in produitList)
            {
                if (produit.Name.ToLower() == nom.ToLower())
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
            return produitList.OrderBy(i => i.Name).ToList();
        }

        public static List<Produit> TriePrixCroissant(List<Produit> produitList)
        {
            return produitList.OrderBy(i => i.Prix).ToList();
        }

        public static List<Produit> TriePrixDecroissant(List<Produit> produitList)
        {
            return produitList.OrderByDescending(i => i.Prix).ToList();
        }
    }
}