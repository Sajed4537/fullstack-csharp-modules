# ex04 — LINQ Introduction

**Objectif**  
Introduire les opérations LINQ de base sur une `List<Produit>` :
- **Filtrer** (`Where`) selon un prédicat (prix > 10).
- **Projeter** (`Select`) pour extraire les noms.
- **Trier** (`OrderBy`, `OrderByDescending`) par prix, puis par nom.
- **Paginer** (`Take`, `Skip`) pour récupérer un sous-ensemble.
- **Dédupliquer** (`DistinctBy`) sur une clé (nom).

**Run**  
Ouvrir `Exercises.sln`, définir **LinqIntroduction.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- Modélisation d’un type `Produit` (Id, Name, Categorie, Prix) et méthode d’affichage console.
- Chaînage d’opérateurs LINQ : `Where` → `Select` → `OrderBy`/`OrderByDescending` → `Take`/`Skip`.
- Utilisation de `DistinctBy` pour **éliminer les doublons** d’après une clé.
- Itération d’une séquence LINQ et affichage formaté des résultats.
