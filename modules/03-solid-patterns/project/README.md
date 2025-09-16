# Module 03 — Project (Ecommerce Cart)

## Summary
Application console de **panier e-commerce** qui combine plusieurs patterns
(**Adapter**, **Repository & Unit of Work**, **Decorator**, **Strategy**) pour :
importer des données (produits / utilisateurs), gérer les paniers et calculer
le total (remises + livraison) de façon **extensible** et **découplée**.

**Objectifs**
- **Adapter**  
  Unifier des sources hétérogènes derrière un contrat unique `IDataImporter<T>` :
  `CsvProduitsAdapter` (CSV produits) et `XmlUtilisateursAdapter` (XML utilisateurs).  
  Les lectures brutes sont encapsulées par `LegacyCsvFile` / `LegacyXmlFile`.
- **Repository & Unit of Work**  
  Contrats : `IRepository<T>`, `IProduitsRepository`, `IUtilisateursRepository`,
  `IPanierRepository`, `IUnitOfWork`. Implémentations **InMemory** (dictionnaires)
  + `InMemoryUnitOfWork` comme **point de commit** unique.
- **Services métier (panier)**  
  `IPanierServices` / `PanierServices` :
  - `CreatePanier(idUtilisateur)`  
  - `AjouterProduit(panier, produit)` / `RetirerProduit(panier, produitId)` (maj du stock)  
  - `CalculerTotal(panier)` (somme des prix)
- **Decorator (pricing/remises)**  
  Base `PricingDecorator` (enveloppe un `IPanierServices`) et décorateurs chaînables :  
  `RemiseAdministrateurDecorateur` (–20% administrateur), `RemisePourcentageDecorator` (remise configurable).
- **Strategy (livraison)**  
  `ILivraisonStrategy` avec deux stratégies : `StandardLivraison` (+5) et `ExpressLivraison` (+12).

## Stack
C#, .NET 8 (Console), LINQ

## How to run
- Ouvrir la solution : `EcommerceCart.sln`
- Définir **EcommerceCart.App** comme projet de démarrage
- Vérifier les données d’entrée (ex. `Adapter/Data/produits.csv`, `Adapter/Data/utilisateurs.xml`)
- Lancer avec **F5** (ou `dotnet run`)

## Exemple de flux (résumé)
1. **Import** des produits (CSV) et utilisateurs (XML) via les **adapters** → insertion dans les repositories → `SaveChanges()`.
2. **Création du panier** pour un utilisateur, ajout/retrait de produits (stock mis à jour).
3. **Remises (Decorator)** :  
   - Admin → `RemiseAdministrateurDecorateur` (–20%)  
   - Client → `RemisePourcentageDecorator` (ex. –10%)
4. **Livraison (Strategy)** :  
   - Standard (+5) ou Express (+12)
5. **Total final** = total après remise + frais de livraison.

## Links
- Source code : `modules/03-solid-patterns/project/src/`
