# Conventions

Règles de nommage, d’organisation et de rédaction à respecter pour tous les modules du repo.

## Folder structure
```
modules/
└── NN-module-name/
    ├── README.md                         (fiche du module)
    ├── exercices/
    │   └── exNN-exercise-name/
    │       ├── README.md                 (fiche de l’exercice)
    │       └── src/
    │           └── ExerciseName.App/     (projet .NET)
    └── project/
        ├── README.md                     (fiche du projet)
        ├── ProjectName.sln               (solution dédiée)
        └── src/
            └── ProjectName.App/
```

## Naming
| Élément | Règle | Exemple |
|---|---|---|
| Dossier de module | `NN-kebab-case` (anglais) | `05-sql-efcore` |
| Dossier des exercices | Toujours `exercices` | `exercices/` |
| Dossier d’exercice | `exNN-kebab-case` (anglais) | `ex02-pattern-strategy` |
| Projet d’exercice | Nom de l’exercice en PascalCase + `.App` | `PatternStrategy.App` |
| Projet de module | Nom métier en PascalCase + `.App` | `MovieCatalog.App` |
| Solution de projet | Nom métier en PascalCase, **sans** `.App` | `MovieCatalog.sln` |
| Namespace | Identique au nom du projet | `DataModeling.App.Models` |
| Framework cible | .NET 9 (`net9.0`) | |

## Solutions (.sln)
- **Exercices** : jamais de `.sln` propre à un exercice. Tous les exercices sont ajoutés à `Exercises.sln` (racine), dans le dossier de solution du module (`05-SQL-EFCore`).
  Dans Visual Studio : clic droit sur le dossier du module dans `Exercises.sln` → **Ajouter** → **Nouveau projet**, emplacement `.../exNN-name/src/`, en **décochant** « Placer la solution et le projet dans le même répertoire ».
- **Projet de module** : une `.sln` dédiée dans `project/`, le code dans `project/src/`.
- **SQL pur** (scripts `.sql`) : pas de projet .NET, les scripts vont directement dans `src/`.

## README style
- Un seul titre `#` par fichier, en anglais, avec le tiret long `—`.
- Toutes les sections en `##`, en anglais.
- Contenu rédigé en français.
- Notions clés en **gras**, noms de classes / fichiers / commandes entre `backticks`.
- Listes à puces avec `-`, étapes avec `1.` `2.` `3.`.
- Pas d’emojis, pas de séparateurs `---`.
- Framework toujours écrit **.NET 9**.

## Exercise README template
```markdown
# exNN — Title In English

## Objective
Ce que fait l’exercice, en 2 à 4 lignes.

## Steps
1. Étape (section facultative).

## Run
Ouvrir `Exercises.sln`, définir **ExerciseName.App** comme projet de démarrage, puis lancer avec **F5**.

## Skills
- **Notion** : explication courte.
```

## Module README template
```markdown
# Module NN — Title

## Summary
2 à 3 lignes.

## Exercises
- `ex01-exercise-name` — Title

## Project
- Project Name : [`project/`](./project/)
- Solution : `project/ProjectName.sln`
- App : `project/src/ProjectName.App/`
```

## Project README template
```markdown
# Module NN — Project (Project Name)

## Summary
## Features
## Stack
## How to run
## Example flow    (facultatif)
## Links
```
Des sections spécifiques peuvent être ajoutées entre `Features` et `Stack` si nécessaire (ex. `Data model`, `Project structure`, `Skills`).
