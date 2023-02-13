//BACKTRACING SOLVER OPTIMISE

//RESULTS : MEILLEURS TEMPS DE RESOLUTION SUDOKU TOUTES DIFFICULTES

//Importation des bibliothèques nécessaires

using System; //.NET
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Shared; //Importation classes .SHARED

namespace Sudoku.Backtracking
{
    public class BacktrackingsolverV2 : ISudokuSolver
    {
        //SOLVER SUDOKU : appelle SolveBacktracking
        public SudokuGrid? Solve(SudokuGrid s)
        {
            int[,] sudoku = ConvertToArray(s);

            if (SolveBacktracking(sudoku, 0, 0))
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        s.Cells[i][j] = sudoku[i, j];
                    }
                }

                return s;
            }
            //SI LA GRILLE NE PEUT PAS ETRE RESOLUE : RENVOIE NULL
            else
            {
                return null;
            }
        }



        //convertit les données de la grille de sudoku de la classe "SudokuGrid" en un tableau à deux dimensions d'entiers
        //UTILSATION D'UN TABLEAU SOUS FORMAT INT[,]
        //LE TABLEAU INT[,] RECUPERE TOUTES LES VALEURS DU SUDOKU s 
        private static int[,] ConvertToArray(SudokuGrid s)
        {
            int[,] sudoku = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = s.Cells[i][j];
                }
            }

            return sudoku;
        }


        //ALGORITHME SOLVER BACKTRACKING

        //L'algorithme consiste à remplir chaque case vide de la grille avec un nombre possible (de 1 à 9), puis à vérifier si cela rend la grille valide.
        //Si la grille devient invalide, le nombre précédent est annulé et un autre nombre est essayé.
        //L'algorithme se poursuit jusqu'à ce qu'une solution valide soit trouvée ou jusqu'à ce qu'il n'y ait plus de nombres possibles à essayer pour une case particulière.
        private bool SolveBacktracking(int[,] grid, int row, int col)
        {
            if (row == 8 && col == 9)
            {
                return true;
            }

            if (col == 9)
            {
                row++;
                col = 0;
            }

            if (grid[row, col] != 0)
            {
                return SolveBacktracking(grid, row, col + 1);
            }

            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(grid, row, col, num))
                {
                    grid[row, col] = num;
                    if (SolveBacktracking(grid, row, col + 1))
                    {
                        return true;
                    }
                    grid[row, col] = 0;
                }
            }

            return false;
        }

        //vérifie si un nombre particulier peut être inséré dans une case donnée sans violer les règles de la grille de sudoku.
        private static bool IsSafe(int[,] grid, int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == num || grid[i, col] == num)
                {
                    return false;
                }
            }

            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[startRow + i, startCol + j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}