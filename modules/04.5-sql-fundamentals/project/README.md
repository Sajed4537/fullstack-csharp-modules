# SQL Project — Library Management System

## 🎯 Objectif
Concevoir et administrer une base de données complète dédiée à la gestion d’une bibliothèque.  
Le projet couvre toutes les étapes essentielles : création du schéma relationnel, insertion et manipulation de données, jointures, agrégations, opérations CRUD et optimisation via indexation.

---

## 🧱 Structure du projet
- **`create_tables.sql`** → création de la base `LibraryDB` avec ses tables, clés étrangères et jeu de données initial.  
- **`demo_queries.sql`** → démonstration des fonctionnalités principales :  
  - lectures simples  
  - jointures  
  - filtres et agrégations  
  - opérations CRUD complètes  
  - index et analyse de performance  
- **`reset.sql`** → nettoyage complet des tables et réinitialisation des identifiants (`IDENTITY`).

---

## ⚙️ Fonctionnalités clés
- Création automatique de la base de données `LibraryDB`.  
- Relations 1→N entre `Authors`, `Books` et `Loans`.  
- Gestion des statuts de disponibilité des livres (colonne `Available`).  
- Cycle CRUD complet simulant un emprunt, un retour et une suppression contrôlée.  
- Indexation non-clustered sur `Books.Title` pour optimiser les recherches par titre.  
- Observation et interprétation du **plan d’exécution** (de `Clustered Scan` à `Index Seek`).  

---

## 🧠 Compétences démontrées
- Conception et modélisation de bases SQL relationnelles.  
- Maîtrise des contraintes d’intégrité et des clés étrangères.  
- Écriture de requêtes SQL structurées et commentées (JOINS, WHERE, GROUP BY).  
- Réalisation d’un CRUD complet avec logique métier cohérente.  
- Création, utilisation et suppression d’un **index non-clustered**.  
- Analyse et interprétation du plan d’exécution dans SSMS.  
- Documentation claire, lisible et compatible avec GitHub.

---

## 🚀 Lancer le projet
1. Ouvrir **SQL Server Management Studio (SSMS)**.  
2. Exécuter `create_tables.sql` pour créer la base et insérer les données.  
3. Tester et explorer les requêtes depuis `demo_queries.sql`.  
4. Observer les différences de performance avant/après l’indexation.  
5. Exécuter `reset.sql` pour réinitialiser la base avant une nouvelle démonstration.

---

## 🧩 Aperçu du modèle relationnel
| Table | Description | Principales colonnes |
|--------|--------------|----------------------|
| **Authors** | Informations sur les auteurs | `AuthorID`, `Name`, `Nationality` |
| **Books** | Informations sur les livres et leur disponibilité | `BookID`, `Title`, `Genre`, `Available`, `AuthorID` |
| **Loans** | Historique des emprunts de livres | `LoanID`, `PersonName`, `LoanDate`, `ReturnDate`, `BookID` |

---

## 📈 Exemple d’optimisation
> Recherche d’un livre par titre :
```sql
SELECT * FROM Books WHERE Title = 'Les Miserables';
