# ex06 — Adapter Pattern (CSV / XML Contacts)

**Objectif**  
Unifier la lecture de **sources hétérogènes** (CSV, XML) vers un même modèle `Contact`
en appliquant le **pattern Adapter** : chaque format est encapsulé derrière l’interface
`IContactFeed`, de sorte que le service consomme une API unique (Load → IEnumerable<Contact>).

**Run**  
Ouvrir `Exercises.sln`, définir **PatternAdapter.App** comme projet de démarrage, puis lancer **F5**.  
Le programme charge successivement `Data/contacts.csv` et `Data/contacts.xml` et affiche les contacts.

**Compétences démontrées**  
- **Contract unique** : `IContactFeed.Load()` retourne une séquence de `Contact`.
- **Adapters** :
  - `CsvContactAdapter` lit le contenu via `LegacyCsvFile`, **normalise** les fins de ligne,
    **valide l’en-tête** (`firstname,lastname,email`), ignore les lignes invalides, puis mappe vers `Contact`.
  - `XmlContactAdapter` lit via `LegacyXmlFile`, parse avec `XDocument`, récupère `firstName/lastName/email`,
    **ignore** les éléments incomplets, et renvoie la liste.
- **Sources legacy encapsulées** : `LegacyCsvFile` / `LegacyXmlFile` fournissent simplement `ReadAll()` (chemin + lecture UTF-8). 
- **Service découplé** : `ContactService.LoadAllContacts(IContactFeed)` se contente d’itérer les contacts et d’afficher
  prénom/nom/email — le format source est **transparent**.
- **Domaine minimal** : `Contact` (`FirstName`, `LastName`, `Email`).
- **Démonstration** (dans `Program`) : exécution avec un adaptateur CSV puis avec un adaptateur XML
  (`Data/contacts.csv`, `Data/contacts.xml`).
- **Ouvert/Fermé (OCP)** : ajouter un nouveau format (JSON, API HTTP, etc.) = écrire un **nouvel adapter**
  implémentant `IContactFeed` sans changer le service.
