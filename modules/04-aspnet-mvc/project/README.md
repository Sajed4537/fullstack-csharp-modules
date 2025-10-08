# Module 04 — Project (Ecommerce MVC)

## Summary
Application web ASP.NET Core MVC de *plateforme e-commerce* illustrant la transposition d’une architecture console vers une application web structurée selon les principes *SOLID* et intégrant plusieurs *Design Patterns*  
(*Repository & Unit of Work, Strategy, Decorator, Adapter*).  

L’application permet d’importer des données (produits / utilisateurs), de gérer les paniers, et de calculer le total (remises + livraison) dans un environnement web complet, avec une interface claire et une logique découplée.

*Objectifs*
- *Adapter (import de données)*  
  Permettre l’import de fichiers CSV ou XML via un contrat unique `IFileParser` :  
  CsvProductParser / XmlProductParser pour les produits, CsvUserParser / XmlUserParser pour les utilisateurs.  
  Les fichiers sont analysés, validés, et prévisualisés avant leur insertion dans le référentiel mémoire.
- *Repository & Unit of Work*  
  Contrats : `IRepository<T>`, `IUnitOfWork`.  
  Implémentations *InMemory* (dictionnaires génériques) + `InMemoryUnitOfWork` comme *point de commit* unique.  
  Gestion commune de toutes les entités (Produits, Utilisateurs, Paniers).
- *Services métier (panier)*  
  `IPanierServices` / `PanierServices` :
  - `CreatePanier(idUtilisateur)`  
  - `AjouterProduit(panier, produit)` / `RetirerProduit(panier, produitId)` (mise à jour du stock)  
  - `CalculerTotal(panier)` (somme des prix + application de la livraison et des remises)
- *Strategy (livraison)*  
  `ILivraisonStrategy` avec deux stratégies :  
  `LivraisonStandard` (+5€) et `LivraisonExpress` (+12€).  
  Sélection dynamique du mode de livraison dans l’interface du panier.
- *Decorator (remise administrateur)*  
  `PricingDecorator` (base abstraite) et `RemiseAdmin` (–20% pour les administrateurs).  
  Le décorateur s’applique automatiquement selon le type d’utilisateur.
- *Architecture MVC*  
  Séparation stricte entre les couches :
  - *Controllers* (logique applicative)
  - *ViewModels* (transport des données vers la vue)
  - *Views Razor* (interface utilisateur)
  - *Services / Repositories* (métier et persistance)

## Stack
C#, .NET 8 (ASP.NET Core MVC), LINQ, Bootstrap 5

## How to run
- Ouvrir la solution : `EcommerceMvc.sln`
- Définir *EcommerceMvc.App* comme projet de démarrage
- Vérifier les fichiers d’import dans le dossier `/DATA`
- Lancer avec *F5* (ou `dotnet run`)
- Aller sur :
  - `/Import` → pour importer les données
  - `/Produits` → pour gérer les produits
  - `/Utilisateurs` → pour gérer les utilisateurs
  - `/Paniers` → pour gérer les paniers

## Exemple de flux (résumé)
1. *Import* des produits (CSV/XML) et utilisateurs → validation → preview → insertion en mémoire.
2. *Consultation / édition* via les CRUD Produits et Utilisateurs.
3. *Création du panier* pour un utilisateur :
   - Ajout / retrait de produits.
   - Sélection du mode de livraison (Strategy).
   - Application automatique de la remise (Decorator).
4. *Calcul du total final* :
   - Sous-total des produits.
   - + frais de livraison.
   - – remise éventuelle administrateur.
5. *Message de confirmation* après import ou opération CRUD (via TempData).

## Links
- Source code : `modules/04-mvc-ecommerce/project/src/`
- Data samples : `modules/04-mvc-ecommerce/project/DATA/`
