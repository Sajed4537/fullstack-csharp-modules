# ex03 — HashSet & Equality

**Objectif**  
Utiliser un `HashSet<Produit>` pour **éliminer les doublons** en redéfinissant l’égalité.
`Produit` considère deux instances égales si elles partagent le même **Id**
(en surdéfinissant `Equals` et `GetHashCode`). Le programme illustre la différence
entre une `List<Produit>` (peut contenir des doublons) et un `HashSet<Produit>`
(qui ne garde qu’un exemplaire par Id).

**Run**  
Ouvrir `Exercises.sln`, définir **HashSetAndEquality.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- **Égalité par identité** : `Equals(object)` et `GetHashCode()` basés sur `Id` (contrat respecté).  
- **Déduplication** : insertion d’une liste potentiellement dupliquée dans un `HashSet<Produit>` pour obtenir un ensemble unique.  
- **Retour d’insertion** : `HashSet.Add` renvoie `false` si l’élément (même Id) existe déjà.
