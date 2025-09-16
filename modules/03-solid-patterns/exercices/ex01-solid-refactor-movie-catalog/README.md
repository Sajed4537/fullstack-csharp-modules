# ex01 — SOLID Refactor: Movie Catalog

**Objectif**  
Refactorer un catalogue de films en appliquant les principes **SOLID** :
- **SRP/ISP/DIP** : séparation en services ciblés (`IFilmService`, `IFilmSearch`, `IFilmSort`, `IFilmStats`)
  et dépendance à des **abstractions** (`IFilmRepository`), implémentation mémoire (`InMemoryFilmRepository`).
- **OCP** : ajout d’extensions sans modifier l’existant (ex. tri par année via `IFilmSortByYear` / `FilmSortByYearService`).
- **Gestion d’erreurs** claire via exceptions dédiées (`KeyAlreadyPresent`, `FilmInitialisationProblem`).
- **LINQ** pour recherches, tris et statistiques (groupement par genre, moyennes, min/max, top 2).

**Run**  
Ouvrir `Exercises.sln`, définir **SolidRefactorMovieCatalog.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- **Domaine clair** : `Film` (Id, Titre, Genre, NoteSur10, Année, Réalisateur) + `GenreStats` pour les agrégats.  
- **Repository pattern** : `IFilmRepository` + `InMemoryFilmRepository` (Add/Remove/Update/GetAll/GetById).  
- **Services spécialisés** (SRP) :  
  - `FilmService` (CRUD + validation des entrées)  
  - `FilmSearchService` (recherches par id, titre, genre)  
  - `FilmSortService` (tris par titre/note)  
  - `FilmStatsService` (groupements & agrégats par genre)  
- **Extensions OCP** : `IFilmSortByYear` / `FilmSortByYearService` pour trier par année, sans toucher au code existant.  
- **LINQ** : `Where`, `OrderBy`/`OrderByDescending`, `GroupBy`, `Average`, `Min`, `Max`, `Take`.  
- **DIP** : les services consomment `IFilmRepository` (injection par constructeur), facilitant le remplacement de l’implémentation.
