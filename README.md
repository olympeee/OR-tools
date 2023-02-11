README pour BackTrackingSolver


Ce code est une implémentation d'un algorithme de backtracking pour résoudre les puzzles sudoku. 
L'implémentation fait partie de l'espace de noms Sudoku.Backtracking et implémente l'interface ISudokuSolver 
de l'espace de noms Sudoku.Shared.

Installation de l'environnement

Fork du repository principal sur Github, 
•Clone du fork en local.
•Chargement de la solution existante 
•Création d'un nouveau projet de type bibliothèque de classe ou application de console, dans la version du Framework compatible avec le tronc commun.
•Ajout du nouveau projet Sudoku.Backtracking.
•Définition des références à partir de Sudoku.Benchmark vers Sudoku.Backtracking•
•Création des classes BacktrackingSolverV1 et V2 dans le nouveau projet.
•Ajout des librairies suivantes :

Bibliothèques importées
Les bibliothèques suivantes sont importées dans le code :

System : Fait partie du cadre .NET et fournit des fonctionnalités de base telles que les tableaux, les exceptions, etc.
System.Collections.Generic : Une bibliothèque fournissant des classes de collections telles que les listes et les dictionnaires.
System.Linq : bibliothèque fournissant des fonctions de requête pour les tableaux et autres collections.
System.Text : Une bibliothèque fournissant des fonctionnalités de manipulation de texte.
System.Threading.Tasks : Une bibliothèque fournissant des fonctionnalités pour exécuter des opérations de manière asynchrone.
Sudoku.Shared : Une bibliothèque contenant les classes utilisées dans le projet de solveur de sudoku.


Définition des classes
Les classes BackTrackingSolverV1 et BacktrackingSolverV2 sont définie dans l'espace de noms Sudoku.Backtracking. Elles implémentent l'interface ISudokuSolver, qui requiert l'implémentation d'une seule méthode Solve(SudokuGrid s). 
Cette méthode prend un objet SudokuGrid comme paramètre et renvoie la version résolue de cette grille.
La classe BacktrackingSolverV2 est une version optimisée de la classe BacktrackingSolverV1 permettant d'avoir de meilleurs resultats lors de benchmarks.

Méthode Solve
La méthode Solve ou SolveBacktracking vérifie d'abord s'il y a des cellules vides dans la grille en parcourant les cellules en boucle et en vérifiant leurs valeurs. Si toutes les cellules sont remplies, la méthode renvoie true car la grille est résolue.

S'il y a des cellules vides, la méthode commence à essayer des nombres de 1 à 9 dans chaque cellule vide. Avant d'essayer un nombre, elle appelle la méthode IsSafe pour vérifier si le nombre peut être placé dans la cellule 
sans enfreindre les règles du sudoku. 
Si le nombre peut être placé, la méthode s'appelle récursivement avec la grille mise à jour. Si la méthode renvoie true, la méthode courante renvoie également true, indiquant que la grille est résolue. 
Si la méthode renvoie faux, la méthode actuelle revient en arrière en remettant la valeur de la cellule à 0 et en essayant le nombre suivant.

Méthode IsSafe
La méthode IsSafe vérifie si un nombre donné peut être placé dans une cellule donnée sans enfreindre les règles du sudoku. Elle vérifie si le nombre est déjà présent dans la même ligne, colonne ou case. 
Elle renvoie true si tous les contrôles passent, indiquant que le nombre peut être placé dans la cellule.

Méthodes UsedinRaw, UsedinCol et UsedinBox
Ces méthodes effectuent les contrôles mentionnés dans la méthode IsSafe. 
La méthode UsedinRaw vérifie si le numéro est déjà présent dans la même ligne, UsedinCol vérifie si le numéro est déjà présent dans la même colonne, et UsedinBox vérifie si le numéro est déjà présent dans la même case.

Méthodes ConvertToArray

Cette méthode "ConvertToArray" est utilisée pour convertir un objet de type "SudokuGrid" en un tableau à deux dimensions de type entier. Le tableau a une taille de 9x9, ce qui correspond à la taille d'une grille de sudoku standard.

La méthode définit un tableau à deux dimensions nommé "sudoku" qui sera utilisé pour stocker les valeurs de la grille de sudoku.

Ensuite, il y a une boucle à double entrée qui parcourt les lignes et les colonnes de la grille de sudoku. Pour chaque cellule, la valeur de la cellule correspondante dans l'objet "SudokuGrid" 
est récupérée en utilisant la propriété "Cells" et stockée dans le tableau "sudoku".

Enfin, le tableau "sudoku" rempli est retourné en tant que résultat de la méthode.

Différences entre V1 et V2 : 

La classe "BacktrackingsolverV1" est renommée en "BacktrackingsolverV2".
L'algorithme "SolveBacktracking" a été modifié pour être plus efficace en termes de performance. (Recuperation de la grille de sudoku sous forme de 'ConvertToArray' (tableau a 2 dimensions).
La méthode "ConvertToArray" a été ajoutée pour convertir les données de la grille de sudoku de la classe "SudokuGrid" en un tableau à deux dimensions d'entiers.
Le code a été reformaté pour une meilleure lisibilité et une structure plus claire.
Ces modifications visent à optimiser la vitesse et l'efficacité du code pour résoudre des grilles de sudoku.


Conclusion
Ce code fournit une solution optimisée pour résoudre les puzzles sudoku en utilisant l'algorithme de backtracking. En suivant les règles du sudoku et en revenant en arrière lorsque cela est nécessaire, 
l'algorithme peut résoudre efficacement n'importe quel puzzle sudoku.