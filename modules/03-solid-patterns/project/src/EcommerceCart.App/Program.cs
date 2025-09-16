using EcommerceCart.App.Adapter.Adapters;
using EcommerceCart.App.Adapter.Legacy;
using EcommerceCart.App.Decorator.Decorators;
using EcommerceCart.App.Domain;
using EcommerceCart.App.Repository_UoW.Contracts;
using EcommerceCart.App.Repository_UoW.Services;
using EcommerceCart.App.Strategy.Contracts;
using EcommerceCart.App.Strategy.Strategies;

namespace EcommerceCart.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialisation du panierService pour la gestion des paniers 
            var panierService = new PanierServices();

            // Initialisation des repos  

            IUnitOfWork uow = panierService.UoW;

            IProduitsRepository repoProduits = panierService.produitsRepository;

            IUtilisateursRepository repoUtilisateurs = panierService.utilisateursRepository;

            IPanierRepository repoPanier = panierService.panierRepository;

            // Import de la Data (Utilisateurs - Produits)
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("---------------- Import de la Data Design Pattern : Adapter ---------------- ");

            Console.WriteLine();
            Console.WriteLine();

            LegacyCsvFile legacyCsvFile = new LegacyCsvFile("Adapter/Data/produits.csv");
            CsvProduitsAdapter csvProduitsAdapter = new CsvProduitsAdapter(legacyCsvFile);
            var listProduits = csvProduitsAdapter.Load();


            foreach (var item in listProduits)
            {
                // Ajout des produits importés dans le repoProduits
                repoProduits.Add(item);
                Console.WriteLine($"Id : {item.Id} - Nom : {item.Nom} - Prix : {item.Prix} - Categorie : {item.Categories} - Stock : {item.Stock}");
            }

            uow.SaveChanges();

            LegacyXmlFile legacyXmlFile = new LegacyXmlFile("Adapter/Data/utilisateurs.xml");
            XmlUtilisateursAdapter xmlUtilisateursAdapter = new XmlUtilisateursAdapter(legacyXmlFile);
            var listUtilisateurs = xmlUtilisateursAdapter.Load();

            Console.WriteLine();

            foreach(var item in listUtilisateurs)
            {
                // Ajout des Utilisateurs dans le repoUtilisateurs 
                repoUtilisateurs.Add(item);
                Console.WriteLine($"Id : {item.Id} - Nom : {item.Nom} - Prenom : {item.Prenom} - Email : {item.Email} - Type : {item.Type}");
            }

            uow.SaveChanges();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("---------------- Gestion des paniers Design Pattern : Repository + Unit of Work ---------------- ");

            Console.WriteLine();
            Console.WriteLine();


            // Récupération des utilisateurs pour la création des paniers
            var utilisateurs = repoUtilisateurs.ListAll().ToList();

            // Création des paniers (Récupération de leurs Id)
            var panierId1 = panierService.CreatePanier(utilisateurs[0].Id);
            var panierId2 = panierService.CreatePanier(utilisateurs[1].Id);
            var panierId3 = panierService.CreatePanier(utilisateurs[2].Id);

            // Récupération des paniers pour les ajouter au repoPanier 
            var paniers = repoPanier.ListAll().ToList();    

            var panier1 = repoPanier.GetById(paniers[0].Id);
            var panier2 = repoPanier.GetById(paniers[1].Id);
            var panier3 = repoPanier.GetById(paniers[2].Id);

            // Ajout des panier au repoPanier 
            foreach(var item in paniers) { repoPanier.Add(item);}

            uow.SaveChanges();

            // Récupération des produits 
            var produits = repoProduits.ListAll().ToList();

            // Ajout des produits dans les paniers 
            panierService.AjouterProduit(panier1, produits[0]);
            panierService.AjouterProduit(panier1, produits[1]);
            panierService.AjouterProduit(panier1, produits[2]);

            panierService.AjouterProduit(panier2 , produits[3]);
            panierService.AjouterProduit(panier2 , produits[4]);

            // afficher paniers + Utilisateur
            foreach(var user in utilisateurs)
            {
                var panier = repoPanier.GetPanierByUserId(user.Id);

                if(panier.Produits.Count == 0 ) { Console.WriteLine($"L'utilisateur {user.Prenom} {user.Nom} n'a pas de panier.");}
                else
                {
                    Console.WriteLine($"L'utilisateur {user.Prenom} {user.Nom} a le panier suivant :");
                    foreach (var item in panier.Produits)
                    {
                        Console.WriteLine($"Id : {item.Id} - Nom : {item.Nom} - Prix : {item.Prix} - Categorie : {item.Categories} - Stock : {item.Stock}");
                    }
                    var total = panierService.CalculerTotal(panier);
                    Console.WriteLine($"Total : {total}");
                }
                Console.WriteLine() ;    
            }

            Console.WriteLine();

            Console.WriteLine("---------------- Ajout des promotions et frais de livraison Design Pattern : Decorator, Strategy ---------------- ");

            Console.WriteLine();
            Console.WriteLine();


            // Ajouter les promotions et les livraisons
            Console.WriteLine("Promotions et livraisons : ");

            // Ajouter livraisons
            ILivraisonStrategy livraisonExpress = new ExpressLivraison();
            ILivraisonStrategy livraisonStandard = new StandardLivraison();

            foreach ( var user in utilisateurs)
            {
                var panier = repoPanier.GetPanierByUserId(user.Id);
                if(panier.Produits.Count == 0)
                {
                    continue;
                }
                else if (user.Type == TypeUtilisateur.Administrateur)
                {
                    var remiseAdmin = new RemiseAdministrateurDecorateur(panierService, user);
                    var totalRemise = remiseAdmin.CalculerTotal(panier);
                    Console.WriteLine($"L'utilisateur {user.Prenom} {user.Nom} est un administrateur, la promotion des administrateurs sera prise en compte (-20%).");
                    Console.WriteLine($"Total avec remise : {totalRemise}");
                    Console.WriteLine();

                    var livraison = livraisonExpress.CalculerFraisLivraison(panier);

                    var totalLivraison = totalRemise + livraison;

                    Console.WriteLine($"L'utilisateur {user.Prenom} {user.Nom} a fait le choix d'une livraison Express (+{livraison}) le nouveau total avec la livraison est de {totalLivraison}");

                    Console.WriteLine();


                }
                else if(user.Type == TypeUtilisateur.Client)
                {
                    var remisePourcentage = new RemisePourcentageDecorator(panierService, 0.1m);
                    var totalRemise = remisePourcentage.CalculerTotal(panier);
                    Console.WriteLine($"L'utilisateur {user.Prenom} {user.Nom} est un client, la promotion de 10% sera prise en compte.");
                    Console.WriteLine($"Total avec remise : {totalRemise}");
                    Console.WriteLine();

                    var livraison  =livraisonStandard.CalculerFraisLivraison(panier);

                    var totalLivraison = totalRemise + livraison;

                    Console.WriteLine($"L'utilisateur {user.Prenom} {user.Nom} a fait le choix d'une livraison Standard (+{livraison}) le nouveau total avec la livraison est de {totalLivraison}");

                    Console.WriteLine();
                }
            }
        }
    }
}