# ex05 — Repository & Unit of Work

**Objectif**  
Mettre en place les patterns **Repository** et **Unit of Work** pour un mini bug-tracker
(Users, Projects, Issues, Comments) stocké **en mémoire**. Les services métiers
travaillent uniquement avec des **abstractions** (DIP) et valident les règles (création,
assignation, changement de statut, commentaires), avec un **point de commit unique**.

**Run**  
Ouvrir `Exercises.sln`, définir **RepositoryAndUnitOfWork.App** comme projet de démarrage, puis lancer **F5**.

**Compétences démontrées**  
- **Contrats de persistance**
  - `IRepository<T>` générique : `GetById`, `ListAll`, `Add`, `Update`, `Remove`.
  - Dépôts spécialisés : `IUserRepository`, `IProjectRepository`, `IIssueRepository`,
    `ICommentRepository` (ex. `ListByIssue` pour les commentaires).
  - **Unit of Work** : `IUnitOfWork.SaveChanges()` comme point de commit.
- **Implémentations mémoire**
  - `InMemoryUserRepository`, `InMemoryProjectRepository`, `InMemoryIssueRepository`,
    `InMemoryCommentRepository`, `InMemoryUnitOfWork`.
- **Modèle domaine**
  - `User`, `Project`, `Issue` (avec `IssueStatus`), `Comment` (horodaté `CreatedAt`).
- **Service métier (application)**
  - `IIssueService` / `IssueService` :
    - `CreateIssue(projectId, title, description, authorUserId)`  
      → refuse si projet/user introuvable ou titre vide ; crée l’issue **Open**.
    - `AssignIssue(issueId, assigneeUserId)`  
      → assigne si l’issue et l’utilisateur existent.
    - `AdvanceStatus(issueId)`  
      → Open → InProgress → Resolved → Closed (ne dépasse pas **Closed**).
    - `Reopen(issueId)`  
      → autorisé depuis **Resolved**/**Closed** vers **InProgress**.
    - `AddComment(issueId, authorUserId, body)`  
      → refuse si issue/user introuvable ou `body` vide ; renvoie l’Id du commentaire.
    - `GetDetails(issueId)`  
      → retourne l’issue et ses commentaires **triés par date**.
    - Chaque mutation appelle **`UnitOfWork.SaveChanges()`** après dépôt.
- **Architecture & principes**
  - **DIP** : les services dépendent des **interfaces**, pas des concrétions.
  - **Séparation des responsabilités** : domaine ↔ dépôts ↔ services.
  - **LINQ** utilisé pour l’ordonnancement des commentaires.
