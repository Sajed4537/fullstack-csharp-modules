# ex05 — Advanced Polymorphism & Collections

**Objectif**  
Combiner **polymorphisme** et **collections génériques** en modélisant une hiérarchie `Animal`
(classe abstraite avec `Name`, `Age`, `Presenter()`, et `Crier()` abstraite) et des dérivés
(`Chien`, `Chat`, `Oiseau`).  
Introduire une **interface** transversale `IVolant` implémentée par `Oiseau`, puis itérer une
`List<Animal>` pour invoquer dynamiquement `Presenter()` / `Crier()` et, lorsque disponible,
`Voler()` via un test de type (`is`).

**Run**  
Ouvrir `Exercises.sln`, définir **AdvancedPolymorphismAndCollections.App**
comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- **Classe abstraite** + **override** : `Animal` déclare `Crier()`, les dérivés fournissent
  l’implémentation (aboiement/miaou/cui-cui).
- **Interface** et **test de type** : `IVolant` + pattern matching `is` pour appeler `Voler()`
  quand disponible.
- **Collections génériques** : création et parcours d’une `List<Animal>` pour manipuler des
  objets hétérogènes de façon unifiée.
