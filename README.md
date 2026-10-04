# Fullstack C# — Modules (Exercises & Projects)

## Summary
Ce repo regroupe **tous les exercices** et **tous les projets** d’un parcours Full-Stack C# en 10 modules.

- Les **exercices** sont ouverts via la solution **`Exercises.sln`** (à la racine).
- Chaque **projet** vit dans `modules/<module>/project/` avec **sa propre solution** (`<ProjectName>.sln`).
- Les règles de nommage et de rédaction sont décrites dans [`CONVENTIONS.md`](./CONVENTIONS.md).

## Modules
- **01 — OOP**
  - Exercises : [`modules/01-poo/exercices`](modules/01-poo/exercices/)
  - Project : [`modules/01-poo/project`](modules/01-poo/project/)
- **02 — Collections & LINQ**
  - Exercises : [`modules/02-collections-linq/exercices`](modules/02-collections-linq/exercices/)
  - Project : [`modules/02-collections-linq/project`](modules/02-collections-linq/project/)
- **03 — SOLID & Design Patterns**
  - Exercises : [`modules/03-solid-patterns/exercices`](modules/03-solid-patterns/exercices/)
  - Project : [`modules/03-solid-patterns/project`](modules/03-solid-patterns/project/)
- **04 — ASP.NET Core MVC**
  - Exercises : [`modules/04-aspnet-mvc/exercices`](modules/04-aspnet-mvc/exercices/)
  - Project : [`modules/04-aspnet-mvc/project`](modules/04-aspnet-mvc/project/)
- **04.5 — SQL Fundamentals**
  - Exercises : [`modules/04.5-sql-fundamentals/exercices`](modules/04.5-sql-fundamentals/exercices/)
  - Project : [`modules/04.5-sql-fundamentals/project`](modules/04.5-sql-fundamentals/project/)
- **05 — SQL & EF Core** (en cours)
  - Exercises : [`modules/05-sql-efcore/exercices`](modules/05-sql-efcore/exercices/)
  - Project : [`modules/05-sql-efcore/project`](modules/05-sql-efcore/project/)

## How to run an exercise
1. Ouvrir **`Exercises.sln`**.
2. Clic droit sur un projet `*.App` → **Set as Startup Project**.
3. **F5** (ou `dotnet run`).

Les exercices SQL (module 04.5) ne sont pas dans la solution : ils s’exécutent dans **SSMS** (voir le README de chaque exercice).

## How to run a module project
1. Ouvrir la solution du projet : `modules/<module>/project/<ProjectName>.sln`.
2. Clic droit sur `<ProjectName>.App` → **Set as Startup Project**.
3. **F5** (ou `dotnet run`).

## Stack
C#, .NET 9, ASP.NET Core MVC, Entity Framework Core, SQL Server, SSMS, LINQ, Visual Studio 2022, Git, GitHub
