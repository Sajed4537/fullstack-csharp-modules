# Module 04.5 — Project (Library Management System)

## Summary
Base de données complète dédiée à la **gestion d’une bibliothèque** dans SQL Server.
Le projet couvre toutes les étapes essentielles : création du schéma relationnel, insertion et manipulation de données, jointures, agrégations, opérations CRUD et optimisation via indexation.

## Features
- Création automatique de la base de données `LibraryDB`.
- Relations 1→N entre `Authors`, `Books` et `Loans`.
- Gestion des statuts de disponibilité des livres (colonne `Available`).
- Cycle CRUD complet simulant un emprunt, un retour et une suppression contrôlée.
- Indexation non-clustered sur `Books.Title` pour optimiser les recherches par titre.
- Observation et interprétation du **plan d’exécution** (de `Clustered Scan` à `Index Seek`).

## Project structure
- `src/schema_conceptuel.txt` : modèle conceptuel de la base.
- `src/library_project.sql` : création de la base `LibraryDB`, de ses tables, clés étrangères et du jeu de données initial.
- `src/demo_queries.sql` : démonstration des fonctionnalités principales :
  - lectures simples
  - jointures
  - filtres et agrégations
  - opérations CRUD complètes
  - index et analyse de performance
- `src/reset.sql` : nettoyage complet des tables et réinitialisation des identifiants (`IDENTITY`).

## Data model
| Table | Description | Principales colonnes |
|---|---|---|
| **Authors** | Informations sur les auteurs | `AuthorID`, `Name`, `Nationality` |
| **Books** | Informations sur les livres et leur disponibilité | `BookID`, `Title`, `Genre`, `Available`, `AuthorID` |
| **Loans** | Historique des emprunts de livres | `LoanID`, `PersonName`, `LoanDate`, `ReturnDate`, `BookID` |

## Optimization example
Recherche d’un livre par titre :

```sql
SELECT * FROM Books WHERE Title = 'Les Miserables';
```

Sans index, SQL Server parcourt toute la table (`Clustered Scan`). Après création d’un index non-clustered sur `Books.Title`, il utilise un `Index Seek`.

## Skills
- Conception et modélisation de bases SQL relationnelles.
- Maîtrise des contraintes d’intégrité et des clés étrangères.
- Écriture de requêtes SQL structurées et commentées (`JOIN`, `WHERE`, `GROUP BY`).
- Réalisation d’un CRUD complet avec logique métier cohérente.
- Création, utilisation et suppression d’un **index non-clustered**.
- Analyse et interprétation du plan d’exécution dans SSMS.

## Stack
SQL Server, T-SQL, SQL Server Management Studio (SSMS)

## How to run
1. Ouvrir **SQL Server Management Studio (SSMS)**.
2. Exécuter `src/library_project.sql` pour créer la base et insérer les données.
3. Tester et explorer les requêtes depuis `src/demo_queries.sql`.
4. Observer les différences de performance avant/après l’indexation.
5. Exécuter `src/reset.sql` pour réinitialiser la base avant une nouvelle démonstration.

## Links
- Source code : `modules/04.5-sql-fundamentals/project/src/`
