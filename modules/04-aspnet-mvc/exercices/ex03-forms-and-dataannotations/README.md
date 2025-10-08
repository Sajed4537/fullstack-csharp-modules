# ex03 — Formulaires et Validation

**Objectif**  
Mettre en place un formulaire de création d’un produit avec ASP.NET Core MVC et découvrir :  
- la différence entre **GET** (afficher un formulaire) et **POST** (traiter un formulaire),  
- le **model binding** (liaison automatique entre inputs HTML et propriétés d’objet C#),  
- la **validation serveur** avec **DataAnnotations**,  
- la protection **anti-CSRF** via jeton antiforgery.

**Run**  
1. Lancer l’application avec **F5**.  
2. Aller sur `/Produit/Index` → page liste avec formulaire de recherche et lien *Créer un produit*.  
3. Cliquer sur *Créer un produit* → accès au formulaire de création.  
4. Soumettre vide → erreurs de validation affichées sous les champs.  
5. Soumettre avec un prix négatif → message d’erreur ciblé sur Prix.  
6. Soumettre avec toutes les valeurs correctes → redirection vers la liste (Index).

**Compétences démontrées**  
- Création d’un **ViewModel typé** avec validation déclarative (`[Required]`, `[MaxLength]`, `[Range]`).  
- Mise en place de deux actions `Create` (GET pour afficher, POST pour traiter).  
- Utilisation du **model binding** pour remplir automatiquement un objet C# avec les champs du formulaire.  
- Gestion des erreurs avec `ModelState.IsValid` et affichage via `asp-validation-for`.  
- Protection **CSRF** avec `[ValidateAntiForgeryToken]` et le jeton généré dans le formulaire.  
- Mise en place d’un formulaire GET pour la recherche.