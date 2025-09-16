# ex04 — Interfaces & Abstract Classes

**Objectif**  
Comparer et combiner **classes abstraites** et **interfaces** : définir un contrat commun avec une
classe abstraite (`Personne`) et un contrat transverse avec une interface (`ITravailleur`), puis
spécialiser le comportement dans `Etudiant` et `Professeur` via `override` et implémentation
de `Travailler()`.

**Run**  
Ouvrir `Exercises.sln`, définir **InterfacesAndAbstractClasses.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- Déclaration d’une **classe abstraite** (membres concrets + méthode `abstract Presenter()`).
- Définition et **implémentation d’interface** (`ITravailleur.Travailler()`).
- **Spécialisation** dans les dérivés (`override Presenter()`), tout en partageant l’API commune.
- **Encapsulation & validation** dans les propriétés (`Name`, `Age`) pour garder des états valides.
- Itération sur des **collections** d’objets et invocation des méthodes adéquates.
