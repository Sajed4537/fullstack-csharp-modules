# ex04 — Factory Method (Notification Channels)

**Objectif**  
Appliquer le **pattern Factory Method** pour créer des expéditeurs de notification
(Email, SMS, Push) via des **créateurs** dédiés, tout en exposant un contrat unique
`INotificationSender`. Les créateurs valident leur configuration avant d’instancier
le bon expéditeur ; le programme choisit dynamiquement le canal.

**Run**  
Ouvrir `Exercises.sln`, définir **PatternFactoryMethod.App** comme projet de démarrage,
puis lancer avec **F5**.

**Compétences démontrées**  
- **Factory Method** : `NotificationCreator` (créateur abstrait) et créateurs concrets
  `EmailCreator`, `SmsCreator`, `PushCreator` qui retournent un `INotificationSender`
  après **validation** des paramètres (host/port/from, apiKey/sender, appToken/appId).  
- **Contrat unique** : `INotificationSender.Send(Message)` permet d’utiliser Email/SMS/Push
  de façon interchangeable ; **DIP** : le code client dépend de l’interface, pas des classes concrètes.
- **Validation d’entrée** dans les expéditeurs :
  - **Email** : destinataire non vide, présence de `@`, titre et corps requis.  
  - **SMS** : numéro valide via regex `^\+?\d{8,15}$`.  
  - **Push** : identifiant alphanumérique (avec `_`/`-`).  
- **Gestion d’erreurs** : les créateurs lèvent des `ArgumentException` en cas de configuration invalide ;
  le `Program` capture les erreurs et affiche **Succès/Échec** selon le résultat.
- **Ouverture au changement (OCP)** : ajouter un nouveau canal = créer **un nouvel expéditeur** +
  **un nouveau créateur** sans modifier le code existant.

**Modèle**
- `Message` : `To`, `Title`, `Body` (transport de données du message).
