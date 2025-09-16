# ex01 — List Manipulation

**Objectif**  
Manipuler une `List<Produit>` en mémoire : créer et afficher des produits,  
ajouter avec contrôle de doublon (sur l’`Id`), supprimer par `Id`,  
mettre à jour le prix, rechercher par `Id` ou par nom (insensible à la casse),  
et trier par nom (alphabétique) ou par prix (croissant/décroissant) via LINQ.

**Run**  
Ouvrir `Exercises.sln`, définir **ListManipulation.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- Conception d’une classe métier `Produit` (propriétés : `Id`, `Name`, `Categorie`, `Prix`) et méthode d’affichage.
- Opérations CRUD en mémoire sur `List<Produit>` : ajout avec détection de doublon, suppression par `Id`, mise à jour du prix.
- Recherches : par `Id` et par **nom** (comparaison insensible à la casse).
- Utilisation de **LINQ** : `OrderBy`, `OrderByDescending`, `ToList` pour ordonner la collection.
