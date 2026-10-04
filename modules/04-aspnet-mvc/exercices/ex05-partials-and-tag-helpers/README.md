# ex05 — Partials & Tag Helpers (In-Memory Catalog)

## Objective
Construire un mini-catalogue de produits en ASP.NET Core MVC et découvrir :
- la création d’un **service en mémoire** (In-Memory Store) injecté via **Dependency Injection**,
- le pattern **PRG (Post/Redirect/Get)** pour éviter la double soumission de formulaires,
- l’utilisation de **TempData** pour afficher un message flash après une action,
- la factorisation du code avec une **vue partielle**,
- l’intégration de **Bootstrap** pour un rendu plus professionnel.

## Run
1. Ouvrir `Exercises.sln`, définir **PartialsAndTagHelpers.App** comme projet de démarrage, puis lancer avec **F5**.
2. Aller sur `/Product/Index` → affichage de la liste des produits seedés.
3. Cliquer sur *Créer un produit* → accès au formulaire de création.
4. Soumettre vide → erreurs de validation affichées sous les champs.
5. Soumettre avec un prix négatif → message d’erreur ciblé sur Prix.
6. Soumettre avec toutes les valeurs correctes → redirection vers la liste (Index) avec un **message flash**.
7. Cliquer sur *Détails* → affichage des informations d’un produit donné.

## Skills
- Création d’un **service In-Memory** (`ProductStoreInMemory`) et enregistrement dans le conteneur DI avec `AddSingleton`.
- Implémentation des actions `Index`, `Details`, `Create (GET/POST)` dans un contrôleur MVC.
- Application du pattern **PRG** pour améliorer l’expérience utilisateur après soumission.
- Utilisation de **TempData** pour afficher un message flash après la création d’un produit.
- Construction d’une **vue partielle** (`_ProductRow.cshtml`) pour factoriser l’affichage des produits dans le tableau.
- Utilisation des **Tag Helpers** (`asp-for`, `asp-action`, `asp-route-id`, `asp-validation-for`).
- Application des classes **Bootstrap** (`form-control`, `form-select`, `btn btn-primary`, `table`, etc.) pour un rendu plus lisible et moderne.
