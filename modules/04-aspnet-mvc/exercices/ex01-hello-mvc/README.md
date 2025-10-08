# ex01 — Hello MVC

**Objectif**  
Créer une première application ASP.NET Core MVC afin de comprendre le flux complet :  
- Création d’un contrôleur `HelloController` avec une action `Index`.  
- Utilisation d’un **ViewModel** (`HelloViewModel`) pour transporter une donnée.  
- Création de la vue Razor `Views/Hello/Index.cshtml` qui affiche le message du ViewModel.  
- Intégration dans le layout commun (`_Layout.cshtml`).  
- Ajout d’un lien *Hello* dans la barre de navigation.

**Run**  
Lancer l’application avec **F5**, puis cliquer sur le lien **Hello** dans la barre de navigation.

**Compétences démontrées**  
- Création d’un **contrôleur MVC** avec action `Index`.  
- Mise en place d’un **ViewModel** simple pour passer des données à la vue.  
- Création d’une **vue Razor typée** affichant `@Model.Texte`.  
- Utilisation d’un **layout commun** pour header/nav/footer.  
- Ajout d’un **lien de navigation** avec `asp-controller` et `asp-action`.