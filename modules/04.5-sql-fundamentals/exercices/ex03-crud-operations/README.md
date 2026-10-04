# ex03 — CRUD Operations

## Objective
Apprendre à manipuler les données d'une base SQL Server à l’aide des quatre opérations fondamentales du SQL :
- **Create** (`INSERT`) : ajouter des données.
- **Read** (`SELECT`) : lire et filtrer les données.
- **Update** (`UPDATE`) : modifier des enregistrements existants.
- **Delete** (`DELETE`) : supprimer des enregistrements.

## Steps
1. Ajout de données dans les tables `Categories`, `Products` et `Stock` à l’aide de la commande `INSERT`.
2. Lecture des données avec `SELECT`, accompagnée de filtres `WHERE`.
3. Modification de valeurs avec `UPDATE` et conditions ciblées.
4. Suppression d’enregistrements avec `DELETE` tout en respectant les relations entre tables.
5. Vérification des opérations après chaque action pour comprendre le comportement des données.

## Run
Ouvrir **SSMS**, puis exécuter `src/crud_operations.sql` (la base de l’ex02 doit exister).

## Skills
- Réalisation d’un **CRUD complet** en SQL (`INSERT`, `SELECT`, `UPDATE`, `DELETE`).
- Utilisation des conditions **`WHERE`** pour éviter les modifications globales.
- Respect de l’**ordre d’exécution** imposé par les clés étrangères.
