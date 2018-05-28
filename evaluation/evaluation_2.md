# Evaluation

## Remarques générales

* Il faut maintenant te concentrer sur la partie documentation.

## Objets 2 : Conception et programmation orientées objets (C#, .NET)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais concevoir un diagramme de classes qui représente mon application. | 5 | 8 | Il manque des relations (utilisateur n'a aucune relation ? Par qui est porté l'évènement UserChangedEvent ? La couche de persistance doit bien manipuler des objets ?)
| Je sais réaliser un diagramme de paquetages qui illustre bien l'isolation entre les parties de mon application. | 0 | 4 |
| Je sais réaliser un diagramme de séquences qui décrit l'un des processus de mon application. | 0 | 2 | 
| Je sais décrire mes trois diagrammes en mettant en valeur et en justifiant les éléments essentiels. | 0 | 6 |

**Note provisoire**: 05/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je maîtrise les bases de la programmation C# (classes, structures, instances...) | 2 | 2 | OK |  
| Je sais utiliser l'abstraction à bon escient (héritage, interface, polymorphisme). | 3 | 3 | OK |
| Je sais gérer des collections simples (tableaux, listes, ...) | 2 | 2 | OK |
| Je sais gérer des collections avancées (dictionnaires). | 2 | 2 | Essaye de créer un dictionnaire (les films par genre par exemple). Utilise LinQ pour créer ton dictionnaire !  |
| Je sais contrôler l'encapsulation au sein de mon application. | 5 | 5 | C'est bien |
| Je sais tester mon application. | 3 | 4 | Il faut faire attention à la couverture de tests. Ton code est-il couvert (cas aux limites) ? |
| Je sais utiliser LINQ. | 1 | 1 | OK |
| Je sais gérer les évènements. | 1 | 1 | Ton métier n'émet pas d'évènement. |

**Note provisoire**: 19/20

## IHM : Interface Homme-Machine (WAML, WPF)

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais décrire le contexte de mon application pour qu'il soit compréhensible par tout le monde. | 0 | 4 |
| Je sais dessiner des sketchs pour concevoir les fenêtres de mon application. | 0 | 4 |
| Je sais enchaîner mes sketchs au sein d'un storyboard. | 0 | 4 | 
| Je sais concevoir un diagramme de cas d'utilisation qui représente les fonctionnalités de mon application. | 3 | 5 | Plutôt que de répéter *s'authentifier*, n'y a t'il pas une meilleure modélisation ?
| Je sais concevoir une application ergonomique. | 2 | 2 |
| Je sais concevoir une application avec une prise en compte de l'accessibilité. | 1 | 1 | Point provisoire si tu es capable de me dire en quoi ton application prend en compte l'accessibilité.

**Note provisoire**: 3/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais choisir mes layouts à bon escient. | 1 | 1 | Ok |
| Je sais choisir mes composants à bon escient. | 1 | 1 | OK |
| Je sais créer mon propre composant. | 2 | 2 | OK |
| Je sais personnaliser mon application en utilisant des ressources et des styles. | 2 | 2 | C'est bien |
| Je sais utiliser les DataTemplates (locaux et globaux). | 2 | 2 | OK |
| Je sais intercepter les évènements de la vue. | 2 | 2 | OK |
| Je sais notifier la vue depuis des évènements métier. | 2 | 2 | Pas d'évènement emis depuis le métier |
| Je sais gérer le DataBinding sur mon master. | 1 | 1 | OK |
| Je sais gérer le DataBinding sur mon détail. | 0.5 | 1 | Il manque l'édition (partiellement implémentée en mode admin) |
| Je sais gérer le DataBinding et les Dependency Property sur mes UserControls. | 2 | 2 | OK |
| Je sais développer un Master/Detail (navigation, liens entre les deux écrans, ...) | 3 | 4 | Il manque encore quelques détails |

**Note provisoire**: 18.5/20

## Projet Tuteuré S2

### Documentation

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais mettre en avant dans mon diagramme de classes la persistance de mon application. | 1 | 2 | Il manque encore les relations
| Je sais mettre en avant dans mon diagramme de classes ma partie personnelle. | 0 | 4 |
| Je sais mettre en avant dans mon diagramme de paquetages la persistance de mon application. | 0 | 4 | 
| Je sais réaliser une vidéo de 1 à 3 minutes qui montre la démo de mon application. | 0 | 10 |

**Note provisoire**: 01/20

### Code

| Critère | Points | Max | Commentaires |
|---------|--------|-----|--------------|
| Je sais coder la persitance au sein de mon application. | 3 | 3 | OK |
| Je sais coder une fonctionnalité qui m'est personnelle. | 3 | 3 | Mise en place d'un BdD Sqlite + fwk graphique |
| Je sais documenter mon code. | 0 | 2 | Le code n'est pas documenté |
| Je sais utiliser Git. | 2 | 2 | OK |
| Je sais développer une application qui compile. | 3 | 3 | OK |
| Je sais développer une application fonctionnelle. | 3 | 4 | Il manque l'édition sur le detail |
| Je sais mettre à disposition un outil pour déployer mon application. | 0 | 3 | Pas d'installer |

**Note provisoire**: 14/20
