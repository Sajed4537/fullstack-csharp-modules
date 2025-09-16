# ex02 — Encapsulation & Validation

**Objectif**  
Mettre en place l’encapsulation avec **propriétés** au-dessus de champs privés et
ajouter une **validation** simple dans les setters/constructeur pour préserver les invariants
(ex. nom non vide, âge strictement positif).

**Run**  
Ouvrir `Exercises.sln`, définir **EncapsulationAndValidation.App** comme projet de démarrage, puis lancer avec **F5**.

**Compétences démontrées**  
- Propriétés avec **backing fields** (`_name`, `_age`) et **get/set** personnalisés.
- **Règles de validation** côté setter (messages d’erreur, valeurs par défaut sûres).
- **Constructeur** paramétré qui passe par les propriétés pour centraliser la validation.
- Manipulation d’une **`List<Personne>`** et itération pour afficher les objets.
