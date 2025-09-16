# ex06 — Exceptions & Validation

**Objectif**  
- Appliquer une **validation** dans les propriétés (`Name`, `Age`) pour empêcher les états invalides.  
- Illustrer la **gestion d’erreurs** (bloc `try/catch`) lors de l’instanciation ou de l’affectation.  
- Conserver la structure OO : base abstraite `Personne`, dérivés `Etudiant` / `Professeur`,
  et interface `ITravailleur`.

**Run**  
Ouvrir `Exercises.sln`, définir **ExceptionsAndValidation.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- **Encapsulation + validation** côté setters (nom non vide, âge strictement positif).  
- **Héritage** et **spécialisation** (`Presenter()` surchargée dans les dérivés).  
- **Interface** transversale (`ITravailleur.Travailler()`).  
- **Gestion d’erreurs** structurée avec `try/catch` et messages explicites.
