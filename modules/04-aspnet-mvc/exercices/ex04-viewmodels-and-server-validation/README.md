# ex04 — ViewModels & Validation côté serveur

**Objectif**  
Mettre en place un formulaire basé sur un **ViewModel** dédié pour séparer la logique de saisie du modèle de domaine, et découvrir :  
- l’utilisation des **DataAnnotations** pour la validation côté serveur,  
- la création d’une **règle de validation custom** (ex. unicité du nom),  
- le **model binding** pour remplir automatiquement un ViewModel à partir des inputs,  
- le pattern **PRG (Post/Redirect/Get)** pour éviter la double soumission,  
- l’utilisation de **TempData** pour afficher un message flash,  
- l’intégration des **Tag Helpers** pour simplifier le HTML Razor.

**Run**  
1. Lancer l’application avec **F5**.  
2. Aller sur `/Product/Index` → liste des produits.  
3. Cliquer sur *Créer un produit* → formulaire basé sur le `ProductFormVm`.  
4. Soumettre vide → erreurs de validation affichées sous les champs.  
5. Soumettre avec un nom déjà existant → erreur ciblée sur **Name** (validation custom).  
6. Soumettre avec toutes les valeurs correctes → redirection vers la liste (Index) avec un **message flash**.  
7. Cliquer sur *Éditer* → formulaire pré-rempli ; erreurs affichées en cas de saisie invalide ; soumission valide → mise à jour + PRG avec message flash.

**Compétences démontrées**  
- Création d’un **ViewModel** (`ProductFormVm`) distinct du modèle de domaine pour sécuriser et contrôler les champs exposés.  
- Application de la validation avec **DataAnnotations** (`[Required]`, `[StringLength]`, `[Range]`) et ajout d’une **règle custom** côté serveur.  
- Utilisation du **ModelState** pour gérer et afficher les erreurs dans la vue.  
- Implémentation des actions `Index`, `Details`, `Create (GET/POST)` et `Edit (GET/POST)` avec validation et redirections.  
- Mise en œuvre du pattern **PRG** pour améliorer l’expérience utilisateur.  
- Usage de **TempData** pour afficher un message flash après création ou modification.  
- Utilisation des **Tag Helpers** (`asp-for`, `asp-action`, `asp-route-id`, `asp-validation-for`) pour relier formulaire et contrôleur.  
- Intégration des classes **Bootstrap** (`form-control`, `form-select`, `btn btn-primary`, `table`, etc.) pour une interface claire et moderne.
