# ex02 — Dictionary Basics

**Objectif**  
Utiliser un `Dictionary<int, Produit>` pour des opérations rapides par identifiant :  
construction à partir d’une `List<Produit>`, ajout avec détection de doublon (`ContainsKey`),  
suppression par `Id`, mise à jour du prix, recherche par `Id`.  
Compléter avec une recherche par **nom** (insensible à la casse) et des tris via LINQ.

**Run**  
Ouvrir `Exercises.sln`, définir **DictionaryBasics.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- Modélisation d’un type `Produit` et gestion conjointe **List** + **Dictionary**.  
- **CRUD** en mémoire : ajout (détecte les doublons), suppression (synchro list/dict), mise à jour du prix.  
- Recherches : accès **O(1)** par `Id` avec `Dictionary`, comparaison de **chaînes insensible à la casse** pour le nom.  
- **LINQ** pour trier la liste (ordre alphabétique, prix croissant/décroissant).
