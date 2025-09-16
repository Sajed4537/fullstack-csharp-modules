# ex05 — LINQ Practice

**Objectif**  
Pratiquer les opérations **LINQ** sur une `List<Produit>` :
- **Regrouper** par catégorie (`GroupBy`) et afficher le **nombre d’articles** et leurs noms.
- Calculer les **agrégats globaux** : `Average`, `Min`, `Max`, `Sum` sur `Prix`.
- Par **catégorie**, trouver le **produit le moins cher** (`OrderBy` + `Take(1)`).
- Filtrer (`Where Prix > 5`) puis, **par catégorie**, recalculer `Average`, `Min`, `Max`, `Sum` (format `F2`).

**Run**  
Ouvrir `Exercises.sln`, définir **LinqPractice.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- Modélisation d’un type `Produit` (`Id`, `Name`, `Categorie`, `Prix` décimal).
- **Grouping & iteration** : `GroupBy` + boucle imbriquée pour parcourir chaque groupe et ses éléments.
- **Agrégats** : `Average`, `Min`, `Max`, `Sum` sur une propriété décimale.
- **Tri + Top N par groupe** : `OrderBy(i => i.Prix).Take(1)` pour extraire le moins cher de chaque catégorie.
- **Filtrage** avec `Where` avant regroupement, et **formatage** de sortie (`:F2`, interpolation de chaîne).
