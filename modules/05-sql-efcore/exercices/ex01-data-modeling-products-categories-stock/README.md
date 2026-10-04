# ex01 — Data Modeling (Product / Category / Stock)

## Objective
Modéliser les entités principales du domaine d’un petit catalogue produit avant la mise en place d’Entity Framework Core.
Définir les classes `Category`, `Product` et `Stock` avec leurs propriétés et relations :
- **1–N** : `Category` → `Products`
- **1–1** : `Product` ↔ `Stock`

## Steps
1. Créer le projet console .NET 9 `DataModeling.App` dans `Exercises.sln`.
2. Ajouter un dossier `Models/`.
3. Créer les classes `Category.cs`, `Product.cs` et `Stock.cs` :
   - `Category` : identifiant, nom, liste de produits.
   - `Product` : identifiant, nom, prix, référence à une catégorie, stock.
   - `Stock` : identifiant, quantité, référence à un produit.
4. Définir les propriétés de navigation :
   - `Category` contient une collection de `Products`.
   - `Product` référence une `Category` et un `Stock`.
   - `Stock` référence un `Product`.
5. Vérifier la compilation sans erreur (aucune base de données n’est encore utilisée).

## Run
Ouvrir `Exercises.sln`, définir **DataModeling.App** comme projet de démarrage, puis lancer avec **F5**.
Le programme confirme simplement que les modèles compilent : l’objectif est de construire un modèle valide prêt à être utilisé par EF Core.

## Skills
- Compréhension des concepts de **clé primaire** et **clé étrangère**.
- Définition de **relations 1–1** et **1–N** entre entités.
- Utilisation de **propriétés de navigation** pour relier les classes.
- Préparation du modèle pour une future **intégration avec EF Core**.
