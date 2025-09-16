# ex02 — Strategy Pattern (Discount Policies)

**Objectif**  
Mettre en œuvre le **pattern Strategy** pour appliquer des politiques de remise
interchangeables sur un panier. Le calcul du total est **découplé** de l’algorithme
de remise via l’interface `IRemiseStrategy`, ce qui permet de **brancher** la
stratégie désirée au moment de l’exécution.

**Run**  
Ouvrir `Exercises.sln`, définir **PatternStrategy.App** comme projet de démarrage,
puis lancer avec **F5**.

**Compétences démontrées**  
- **Strategy** : contrat `IRemiseStrategy.CalculRemise(decimal)` et multiples
  implémentations plug-and-play :
  - `PasDeRemise` (0),
  - `RemiseFixe` (montant plafonné au total),
  - `RemisePourcentage` (validation 0–100),
  - `RemisePalier` (seuils 100→5, 200→15, 300→30),
  - `RemiseCodePromo` (codes → montant fixe ou pourcentage).
- **Composition / injection** : le `Panier` reçoit la stratégie dans son constructeur
  et calcule `GetTotalAvecRemise()` sans connaître le détail de l’algorithme.
- **Modèle domaine** : `Produit`, `LignePanier` (quantité × prix unitaire), `Panier`
  (somme des lignes). Validation des **entrées** (quantité/prix > 0) au niveau des
  setters de `LignePanier`.
- **Ouverture au changement** : ajout d’une nouvelle remise = **nouvelle classe**
  implémentant `IRemiseStrategy` (pas de modification du code existant).
