# ex05 — Indexes & Optimization

## Objective
Découvrir le rôle des index dans SQL Server et comprendre comment ils améliorent la performance des requêtes.

## Steps
1. Observation d’un plan d’exécution sans index (`Table Scan`).
2. Création d’un index non-clustered sur une colonne fréquemment filtrée (`Categories.Name`).
3. Vérification du plan d’exécution après ajout de l’index (`Index Seek`).
4. Comparaison du coût d’exécution et analyse du gain de performance.
5. Identification des bonnes pratiques d’utilisation des index.

## Run
Ouvrir **SSMS**, activer **Include Actual Execution Plan**, puis exécuter `src/indexes_and_optimization.sql`.

## Skills
- Création d’un **index non-clustered** sur une colonne utilisée dans les filtres (`WHERE`).
- Lecture d’un **plan d’exécution** : passage d’un **Table Scan** à un **Index Seek**.
- Compréhension du compromis : un index accélère la lecture mais peut ralentir les insertions et mises à jour.
