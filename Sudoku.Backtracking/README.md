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

Benchmarks

Le benchmark suivant est un benchmark complet comprenant l'ensemble des difficultés de sudoku (easy, medium, hard,), 5 min max par sudoku ainsi que plusieurs invocations de sudoku :

Effectué sur un Razer Blade 15 2021 : Intel Core I7-10750H, RTX 2080 SUPER.


|                              Method |      SolverPresenter | Difficulty |         Mean |         Error |       StdDev |       Median |          Min |          Max | Rank |
|------------------------------------ |--------------------- |----------- |-------------:|--------------:|-------------:|-------------:|-------------:|-------------:|-----:|
| 'Benchmarking GrilleSudoku Solvers' |          ColorSolver |       Easy |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' |          ColorSolver |     Medium |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' |          ColorSolver |       Hard |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' |          EmptySolver |       Easy |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' |          EmptySolver |     Medium |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' |          EmptySolver |       Hard |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' | Z3PythonNativeSolver |       Easy |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' | Z3PythonNativeSolver |     Medium |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' | Z3PythonNativeSolver |       Hard |           NA |            NA |           NA |           NA |           NA |           NA |    ? |
| 'Benchmarking GrilleSudoku Solvers' | BacktrackingsolverV2 |       Easy |     55.31 ms |     328.38 ms |    18.000 ms |     45.46 ms |     44.40 ms |     76.09 ms |    1 |
| 'Benchmarking GrilleSudoku Solvers' | BackTrackingSolverV1 |       Easy |    113.32 ms |     372.98 ms |    20.444 ms |    102.07 ms |    100.97 ms |    136.92 ms |    2 |
| 'Benchmarking GrilleSudoku Solvers' | BacktrackingsolverV2 |     Medium |    149.78 ms |     551.05 ms |    30.205 ms |    132.78 ms |    131.90 ms |    184.65 ms |    3 |
| 'Benchmarking GrilleSudoku Solvers' |   Z3AsumptionsSolver |       Easy |    306.32 ms |   5,594.39 ms |   306.647 ms |    134.23 ms |    124.37 ms |    660.36 ms |    4 |
| 'Benchmarking GrilleSudoku Solvers' | BackTrackingSolverV1 |     Medium |    356.11 ms |     449.36 ms |    24.631 ms |    347.56 ms |    336.89 ms |    383.88 ms |    5 |
| 'Benchmarking GrilleSudoku Solvers' | Z3PythonDotNetSolver |       Easy |    444.47 ms |      82.57 ms |     4.526 ms |    443.15 ms |    440.74 ms |    449.51 ms |    6 |
| 'Benchmarking GrilleSudoku Solvers' |        Z3CleanSolver |       Easy |    465.81 ms |     384.13 ms |    21.056 ms |    462.54 ms |    446.59 ms |    488.32 ms |    7 |
| 'Benchmarking GrilleSudoku Solvers' | Z3Sub(...)olver [21] |       Easy |    479.64 ms |      27.05 ms |     1.483 ms |    479.09 ms |    478.51 ms |    481.32 ms |    8 |
| 'Benchmarking GrilleSudoku Solvers' |      Z3InitialSolver |       Easy |    492.95 ms |     112.35 ms |     6.158 ms |    490.82 ms |    488.14 ms |    499.89 ms |    9 |
| 'Benchmarking GrilleSudoku Solvers' |   Z3AsumptionsSolver |     Medium |    964.36 ms |  21,632.37 ms | 1,185.743 ms |    367.31 ms |    195.83 ms |  2,329.96 ms |   10 |
| 'Benchmarking GrilleSudoku Solvers' | Z3PythonDotNetSolver |     Medium |    984.89 ms |   1,157.02 ms |    63.420 ms |    958.70 ms |    938.76 ms |  1,057.22 ms |   11 |
| 'Benchmarking GrilleSudoku Solvers' |        Z3CleanSolver |     Medium |  1,008.03 ms |     276.59 ms |    15.161 ms |  1,008.23 ms |    992.77 ms |  1,023.09 ms |   12 |
| 'Benchmarking GrilleSudoku Solvers' | Z3Sub(...)olver [21] |     Medium |  1,058.25 ms |     550.02 ms |    30.149 ms |  1,071.08 ms |  1,023.81 ms |  1,079.87 ms |   13 |
| 'Benchmarking GrilleSudoku Solvers' |      Z3InitialSolver |     Medium |  1,063.83 ms |     202.64 ms |    11.107 ms |  1,065.06 ms |  1,052.16 ms |  1,074.28 ms |   13 |
| 'Benchmarking GrilleSudoku Solvers' |        Z3ScopeSolver |       Easy |  1,733.35 ms |   1,578.42 ms |    86.519 ms |  1,776.37 ms |  1,633.76 ms |  1,789.94 ms |   14 |
| 'Benchmarking GrilleSudoku Solvers' | Z3PythonDotNetSolver |       Hard |  3,554.45 ms |   7,799.86 ms |   427.537 ms |  3,714.24 ms |  3,070.04 ms |  3,879.09 ms |   15 |
| 'Benchmarking GrilleSudoku Solvers' |        Z3CleanSolver |       Hard |  3,568.99 ms |   2,950.96 ms |   161.752 ms |  3,581.18 ms |  3,401.49 ms |  3,724.31 ms |   15 |
| 'Benchmarking GrilleSudoku Solvers' |        Z3ScopeSolver |     Medium |  3,673.40 ms |   5,206.86 ms |   285.406 ms |  3,808.09 ms |  3,345.57 ms |  3,866.53 ms |   16 |
| 'Benchmarking GrilleSudoku Solvers' |      Z3InitialSolver |       Hard |  3,674.02 ms |   3,943.37 ms |   216.150 ms |  3,600.78 ms |  3,504.01 ms |  3,917.28 ms |   16 |
| 'Benchmarking GrilleSudoku Solvers' | Z3Sub(...)olver [21] |       Hard |  3,997.90 ms |   7,315.03 ms |   400.962 ms |  4,209.09 ms |  3,535.49 ms |  4,249.13 ms |   17 |
| 'Benchmarking GrilleSudoku Solvers' |   Z3AsumptionsSolver |       Hard |  4,528.58 ms | 117,638.60 ms | 6,448.169 ms |    951.24 ms |    662.10 ms | 11,972.41 ms |   18 |
| 'Benchmarking GrilleSudoku Solvers' |        Z3ScopeSolver |       Hard | 11,401.69 ms |  48,241.91 ms | 2,644.302 ms | 10,305.20 ms |  9,482.02 ms | 14,417.86 ms |   19 |
| 'Benchmarking GrilleSudoku Solvers' | BacktrackingsolverV2 |       Hard | 17,496.54 ms |   9,835.94 ms |   539.141 ms | 17,205.14 ms | 17,165.81 ms | 18,118.67 ms |   20 |
| 'Benchmarking GrilleSudoku Solvers' | BackTrackingSolverV1 |       Hard | 56,323.62 ms |  60,051.21 ms | 3,291.610 ms | 58,037.44 ms | 52,528.71 ms | 58,404.71 ms |   21 |

Legends

// * Legends *
  SolverPresenter : Value of the 'SolverPresenter' parameter
  Difficulty      : Value of the 'Difficulty' parameter
  Mean            : Arithmetic mean of all measurements
  Error           : Half of 99.9% confidence interval
  StdDev          : Standard deviation of all measurements
  Median          : Value separating the higher half of all measurements (50th percentile)
  Min             : Minimum
  Max             : Maximum
  Rank            : Relative position of current benchmark mean among all benchmarks (Arabic style)
  1 ms            : 1 Millisecond (0.001 sec)


Conclusion

Ce code fournit une solution optimisée pour résoudre les puzzles sudoku en utilisant l'algorithme de backtracking. En suivant les règles du sudoku et en revenant en arrière lorsque cela est nécessaire, 
l'algorithme peut résoudre efficacement n'importe quel puzzle sudoku.
La solution Backtracking V2 est bien mieux optimisée que la V1. Des différences médiannes d'environ 55ms pour les Sudoku EASY, d'environ 210ms pour les sudokus Medium et d'environ 40,000ms pour les sudoku Hard.
On remarque que la méthode de Backtracking est très performante pour des sudokus Easy, cependant bien moins pour des Sudokus Hard, ou le backtracking arrive respectivement premier et dernier par rapport aux solvers Z3.
Ainsi plus le sudoku est de niveau dur et plus la méthode de backtracking prendra du temps à trouver la solution, contrairement à d'autres algorithmes (plus humains)...

Hadrien Trollet
Alix Petit
Sam Yaiche