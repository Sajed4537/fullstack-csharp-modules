# ex02 — EF Core Migrations & Update Database

## Objective
Configurer **Entity Framework Core** pour générer automatiquement une base de données à partir du modèle défini dans l’exercice précédent.
Créer un `DbContext`, exécuter une migration, et vérifier la création réelle des tables dans SQL Server.

## Steps
1. Créer le projet console .NET 9 `EfCoreMigrationsUpdateDatabase.App` dans `Exercises.sln`.
2. Ajouter une **référence de projet** vers `DataModeling.App` (ex01).
3. Installer les packages NuGet :
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.SqlServer`
   - `Microsoft.EntityFrameworkCore.Tools`
4. Créer la classe `AppDbContext` (dossier `Data/`) héritant de `DbContext` :
   - Définir les `DbSet` : `Categories`, `Products`, `Stocks`.
   - Ajouter un constructeur sans paramètre.
   - Configurer la base SQL dans `OnConfiguring()` (`CatalogueDb` sur `(localdb)\MSSQLLocalDB`).
5. Générer la migration dans la **Console du Gestionnaire de package** : `Add-Migration InitialCreate`.
6. Appliquer la migration : `Update-Database`.
7. Vérifier dans **SQL Server Object Explorer** :
   - Base : `CatalogueDb`
   - Tables : `Categories`, `Products`, `Stocks`

## Run
Pas d’exécution console : définir **EfCoreMigrationsUpdateDatabase.App** comme projet par défaut dans la Console du Gestionnaire de package, lancer `Update-Database`, puis vérifier la base et les tables dans **SQL Server Object Explorer**.

## Skills
- Compréhension du **modèle Code First** avec Entity Framework Core.
- Création et configuration d’un `DbContext`.
- Utilisation des **migrations EF Core** (`Add-Migration`, `Update-Database`).
- Génération d’une base SQL locale à partir de classes C#.
