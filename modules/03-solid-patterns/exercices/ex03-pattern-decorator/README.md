# ex03 — Decorator Pattern (Cart Surcharges)

**Objectif**  
Appliquer le **pattern Decorator** pour enrichir le calcul d’un panier par des
**surcharges optionnelles** sans modifier le calculateur de base, et combiner cela
avec des **stratégies de remise** interchangeables.

- **Calculateur (contrat commun)** : `ICalculateurPanier.Calculer(Panier)` retourne un `Result`
  (sous-total, remise, total avant surcharges, liste de `Surcharge`, total final).
- **Composant de base** : `CalculateurBase` calcule le **sous-total** (quantité × prix) et
  applique la **remise** via une stratégie `IRemiseStrategy`.
- **Décorateurs chaînables** : héritent de `CalculateurDecorator` et **ajoutent** chacun
  leur surcharge au `Result` (ex. `EmballageCadeauDecorator`, `AssuranceDecorator`,
  `LivraisonExpressDecorator`) — composition flexible à l’exécution.
- **Stratégies de remise (Strategy)** via `IRemiseStrategy` :
  - `PasDeRemise` (0),
  - `RemiseFixe` (plafonnée au total),
  - `RemisePourcentage` (validation 0–100),
  - `RemisePalier` (paliers 100→5, 200→15, 300→30),
  - `RemiseCodePromo` (codes → montant fixe ou pourcentage, ex. `PROMO10`, `NOEL20`).

**Run**  
Ouvrir `Exercises.sln`, définir **PatternDecorator.App** comme projet de démarrage,
puis lancer avec **F5**.

**Compétences démontrées**  
- **Decorator** : séparation nette entre **calcul de base** et **surcharges**,
  possibilité de **chaîner** plusieurs décorateurs sans toucher au cœur.
- **Strategy** : calcul de remise **découplé** via `IRemiseStrategy` et ses implémentations.
- **OCP (ouvert/fermé)** : ajouter une nouvelle remise = **nouvelle classe** de stratégie ;
  ajouter une nouvelle surcharge = **nouveau décorateur**.
- **DIP / Composition** : le calculateur de base ne connaît pas les décorateurs,
  et le panier ne connaît pas les algorithmes de remise.
- **Modèle domaine** :
  - `Produit` (Id, Nom)
  - `LignePanier` (validation : `Quantite` > 0, `PrixUnitaire` > 0)
  - `Panier` (liste de lignes, `GetTotalPrix()`, `GetTotalAvecRemise()`)

