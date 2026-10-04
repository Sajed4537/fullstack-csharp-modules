# ex02 — EF Core Migrations & Update Database

**Objectif**  
Configurer **Entity Framework Core** pour générer automatiquement une base de données à partir du modèle défini dans l’exercice précédent.  
Créer un `DbContext`, exécuter une migration, et vérifier la création réelle des tables dans SQL Server.

- Création d’un projet console `.NET 8` : `EfCoreMigrationsUpdateDatabase.App`  
- Installation des packages :  
  - `Microsoft.EntityFrameworkCore`  
  - `Microsoft.EntityFrameworkCore.SqlServer`  
  - `Microsoft.EntityFrameworkCore.Tools`  
- Création d’une classe `AppDbContext` héritant de `DbContext`  
- Configuration de la connexion SQL Server via `OnConfiguring()`  
- Génération d’une migration avec `Add-Migration InitialCreate`  
- Application de la migration avec `Update-Database`

**Étapes**  
1. Créer le projet `EfCoreMigrationsUpdateDatabase.App`.  
2. Ajouter une **référence de projet** vers `DataModeling.App`.  
3. Installer les packages EF Core nécessaires.  
4. Créer la classe `AppDbContext` :  
   - Définir les `DbSet` : `Categories`, `Products`, `Stocks`.  
   - Ajouter un constructeur sans paramètre.  
   - Configurer la base SQL dans `OnConfiguring()` (`CatalogueDb` sur `(localdb)\MSSQLLocalDB`).  
5. Exécuter la commande suivante dans la console du gestionnaire de packages :  
   `Add-Migration InitialCreate`  
6. Puis appliquer la migration avec la commande :  
   `Update-Database`  
7. Vérifier dans **SQL Server Object Explorer** :  
   - Base : `CatalogueDb`  
   - Tables : `Categories`, `Products`, `Stocks`

**Run**  
Aucune exécution directe.  
Le test de réussite se fait en vérifiant la création effective de la base et des tables dans SQL Server Object Explorer.

**Compétences démontrées**  
- Compréhension du **modèle Code First** avec Entity Framework Core.  
- Création et configuration d’un `DbContext`.  
- Utilisation de **migrations EF Core** (`Add-Migration`, `Update-Database`).  
- Vérification d’une base SQL locale à partir de classes C#.
