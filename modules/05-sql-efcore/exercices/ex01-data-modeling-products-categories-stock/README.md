# ex01 — Data Modeling (Product / Category / Stock)

**Objectif**  
Modéliser les entités principales du domaine d’un petit catalogue produit avant la mise en place d’Entity Framework Core.  
Définir les classes `Category`, `Product` et `Stock` avec leurs propriétés et relations.

- Création d’un projet console `.NET 8` : `DataModelingProductsCategoriesStock.App`
- Ajout d’un dossier `Models/`
- Création des entités :
  - `Category` : identifiant, nom, liste de produits
  - `Product` : identifiant, nom, prix, référence à une catégorie, stock
  - `Stock` : identifiant, quantité, référence à un produit
- Mise en place des relations :
  - **1–N** : `Category` → `Products`
  - **1–1** : `Product` ↔ `Stock`

---

**Étapes**

1. Créer le projet `DataModelingProductsCategoriesStock.App` (application console .NET 8).
2. Ajouter un dossier `Models/`.
3. Créer les classes suivantes :
   - `Category.cs`
   - `Product.cs`
   - `Stock.cs`
4. Définir les propriétés et relations :
   - `Category` contient une collection de `Products`.
   - `Product` référence une `Category` et un `Stock`.
   - `Stock` référence un `Product`.
5. Vérifier la compilation sans erreur (aucune base de données n’est encore utilisée).

---

**Run**  
Aucun exécutable à lancer dans cet exercice.  
L’objectif est uniquement de construire un modèle valide prêt à être utilisé par Entity Framework Core.

---

**Compétences démontrées**  
- Compréhension des concepts de **clé primaire** et **clé étrangère**.  
- Définition de **relations 1–1** et **1–N** entre entités.  
- Utilisation de **propriétés de navigation** pour relier les classes.  
- Préparation du modèle pour une future **intégration avec EF Core**.
