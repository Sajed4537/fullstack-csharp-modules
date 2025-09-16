# Module 02 — Project (Movie Catalog)

## Summary
Application console de **catalogue de films** pour pratiquer Collections & LINQ.

**Objectifs**
- Modéliser l’entité `Film` : `Id`, `Titre`, `Genre`, `NoteSur10`, `Annee`, `Realisateur` ; égalité par `Id` (`Equals`/`GetHashCode`).
- Opérations CRUD en mémoire : **ajouter** (refus des doublons), **supprimer** par `Id`, **mettre à jour** la note (0–10).
- Recherches : par **Id** (via `Dictionary<int, Film>`), par **titre** (contient, insensible à la casse), par **genre**.
- Tri : par **titre** (alphabétique) et par **note** (croissant/décroissant).
- Statistiques par **genre** : **total**, **moyenne**, **max**, **min**, **top 2** films (note décroissante).
- **Pagination** simple avec `Skip`/`Take`.

## Stack
C#, .NET 8 (Console), LINQ

## How to run
- Ouvrir : [`MovieCatalog.sln`](./MovieCatalog.sln)
- Définir **MovieCatalog.App** comme projet de démarrage
- F5 (ou `dotnet run`)

## Links
- Source code : `modules/02-collections-linq/project/src/`
