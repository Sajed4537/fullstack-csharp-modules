# ex03 — Inheritance & Polymorphism

## Objective
Mettre en place une hiérarchie avec une classe de base `Personne` et des classes dérivées
(`Etudiant`, `Professeur`) qui **spécialisent** le comportement via `override` d’une méthode virtuelle
(`Presenter()`). Démonstration du **polymorphisme** en itérant une `List<Personne>` contenant des
types dérivés et en invoquant dynamiquement la bonne implémentation.

## Run
Ouvrir `Exercises.sln`, définir **InheritanceAndPolymorphism.App** comme projet de démarrage, puis lancer avec **F5**.

## Skills
- **Héritage** : constructeur de base appelé depuis les dérivés ; ajout d’attributs spécifiques (niveau/matière).
- **Polymorphisme** : `virtual`/`override`, **liaison dynamique**
