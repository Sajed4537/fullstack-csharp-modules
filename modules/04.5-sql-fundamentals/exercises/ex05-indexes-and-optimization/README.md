# Exercise 05 — Indexes & Optimization

## 🎯 Objectif
Découvrir le rôle des index dans SQL Server et comprendre comment ils améliorent la performance des requêtes.

## 🧱 Étapes réalisées
- Observation d’un plan d’exécution sans index (`Table Scan`).
- Création d’un index non-clustered sur une colonne fréquemment filtrée (`Categories.Name`).
- Vérification du plan d’exécution après ajout de l’index (`Index Seek`).
- Comparaison du coût d’exécution et analyse du gain de performance.
- Identification des bonnes pratiques d’utilisation des index.

## 📘 Résumé
L’ajout d’un index non-clustered sur une colonne utilisée dans les filtres (`WHERE`) permet d’accélérer considérablement la recherche des données.
Le plan d’exécution montre que SQL utilise désormais une **recherche d’index (Index Seek)** au lieu d’un **balayage complet de table (Table Scan)**.
Cette optimisation améliore la lecture, mais doit être utilisée avec discernement, car trop d’index peuvent ralentir les opérations d’insertion ou de mise à jour.
