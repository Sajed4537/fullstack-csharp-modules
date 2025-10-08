# ex02 — Routing & Paramètres

**Objectif**  
Découvrir le fonctionnement du routing et du model binding dans ASP.NET Core MVC :  
- Création d’un `ProduitController` avec trois actions : `Index`, `Details(int id)` et `Search(string q)`.  
- Compréhension de la différence entre **paramètre de route** (`id`) et **paramètre de query string** (`q`).  
- Création de trois vues Razor (`Index.cshtml`, `Details.cshtml`, `Search.cshtml`) pour afficher les valeurs reçues.  
- Intégration dans le layout commun et ajout d’un lien *Produits* dans la barre de navigation.

**Run**  
Lancer l’application avec **F5**, puis :  
- Cliquer sur *Produits* dans la navigation → affiche la liste.  
- Aller sur `/Produit/Details/42` → affiche l’ID 42.  
- Aller sur `/Produit/Search?q=lapin` → affiche “lapin”.

**Compétences démontrées**  
- Mise en place du **routing par défaut** (`{controller}/{action}/{id?}`).  
- Utilisation d’un **paramètre de route** pour passer un entier à une action.  
- Utilisation d’un **paramètre de query string** pour passer une valeur texte.  
- **Model binding** automatique des valeurs de l’URL vers les paramètres de méthode.  
- Création de **vues Razor typées** (`@model int`, `@model string`).  
- Ajout d’un **lien de navigation** vers le contrôleur.
