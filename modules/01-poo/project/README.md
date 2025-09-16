# Module 01 — Project (OOP Fundamentals)

## Summary
Application console de **gestion de bibliothèque** pour pratiquer la POO en C#.

**Objectifs**
- Modéliser les entités du domaine :
  `Bibliotheque`, `Livre`, `Utilisateur` (spécialisé en `Etudiant` et `Professeur`), et l’interface `IEmprunteur` (contrat des emprunteurs).
- Implémenter les règles métier d’emprunt/retour et la validation via exceptions : `LivreIndisponibleException`, `LivreInexistantException`, `LivreNonEmprunteException`.
- Appliquer l’**encapsulation** et garder un **état cohérent** (invariants, contrôles).
- Organiser le code en dossiers (`Domain`, `Interface`, `Exceptions`) pour une lecture claire.

## Stack
C#, .NET 8 (Console)

## How to run
- Ouvrir la solution : [`OopFundamentals.sln`](./OopFundamentals.sln)
- Définir **OopFundamentals.App** comme projet de démarrage
- F5 (ou `dotnet run`)

## Links
- Source code : `modules/01-poo/project/src/`
