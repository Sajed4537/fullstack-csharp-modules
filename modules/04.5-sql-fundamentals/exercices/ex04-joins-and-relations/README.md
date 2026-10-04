# ex04 — Joins & Relations

## Objective
Apprendre à relier plusieurs tables d’une base SQL Server à l’aide des différentes formes de `JOIN` :
- **INNER JOIN** : retourne uniquement les lignes présentes dans les deux tables.
- **LEFT JOIN** : retourne toutes les lignes de la table de gauche, même sans correspondance.
- **JOINS successifs** : permettent de combiner plus de deux tables à travers leurs clés étrangères.

## Steps
1. Compréhension du principe de liaison entre tables (`Categories → Products → Stock`).
2. Réalisation de requêtes avec `INNER JOIN` et `LEFT JOIN` pour comparer les résultats.
3. Construction d’une requête reliant les trois tables afin d’afficher les catégories, produits et quantités disponibles.
4. Vérification de la cohérence des relations et observation des différences entre les types de jointures.

## Run
Ouvrir **SSMS**, puis exécuter `src/joins_and_relations.sql`.

## Skills
- Écriture de requêtes **`INNER JOIN`** et **`LEFT JOIN`**.
- Combinaison de **plusieurs tables** via leurs clés étrangères.
- Navigation dans la **structure relationnelle** pour extraire des informations complètes.
