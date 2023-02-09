//Importation des bibliothèques nécessaires

using System; //.NET
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Shared; //Importation classes .SHARED

namespace Sudoku.GeneticAlgorithm
{
    public class BackTrackingSolverV1 : ISudokuSolver
    {
        // Execution fonction Solve SudokuGrid de paramètres s
        SudokuGrid ISudokuSolver.Solve(SudokuGrid s)
        {
            if (Solve(s))
            {
                return s;
            }
            else
            {
                Console.Write("Pas de solution pour le Sudoku");
                return s;
            }
        }
        private static bool IsSafe(SudokuGrid s, int row, int column, int num) //vérifie si la valeur "num" peut être insérée dans la cellule (row, column) du Sudoku "s"
        {
            //ICI METHODE ToString() AUSSI UTILISABLE
            int gridSize = s.Cells.GetLength(0);
            int racine = (int)Math.Sqrt(gridSize);
            bool RAWUSE = UsedinRaw(s, row, num, gridSize);
            bool COLUSE = UsedinCol(s, column, num, gridSize);
            bool BOXUSE = UsedinBox(s, row, column, num, gridSize, racine);
            
            //IF 3 CONIDITONS REUNIES == OK
            return RAWUSE && COLUSE && BOXUSE;
        }


        // METHOD CHECK DUPLICATION LIGNE
        private static bool UsedinRaw(SudokuGrid s, int row, int num, int gridSize)
        {
            for (int x = 0; x < gridSize; x++)
            {
                if (s.Cells[row][x] == num)
                {
                    return false;
                }
            }
            return true;
        }

        // METHOD CHECK DUPLICATION COLONNE
        private static bool UsedinCol(SudokuGrid s, int column, int num, int gridSize)
        {
            for (int y = 0; y < gridSize; y++)
            {
                if (s.Cells[y][column] == num)
                {
                    return false;
                }
            }
            return true;
        }


        // METHOD CHECK DUPLICATION BOX
        private static bool UsedinBox(SudokuGrid s, int row, int column, int num, int gridSize, int racine)
        {
            int boxRowStart = row - row % racine;
            int boxColStart = column - column % racine;
            for (int y = boxRowStart; y < boxRowStart + racine; y++)
            {
                for (int x = boxColStart; x < boxColStart + racine; x++)
                {
                    if (s.Cells[y][x] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //METHOD DE SOLVE DU SUDOKU GRID
            private bool Solve(SudokuGrid s)
        {

            //DECLARATION INTS ET BOOL ISEMPTY (VERIFIER SI INT PRESENT SUR LA GRID POUR MODIFIER)
            int row = 0;
            int column = 0;
            bool isEmpty = true;

            // Trouve la première cellule vide
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (s.Cells[i][j] == 0)
                    {
                        isEmpty = false;
                        row = i;
                        column = j;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }

            // BLINDAGE VERIF SI LE TABLEAU EST BIEN REMPLI
            if (isEmpty)
            {
                return true;
            }

            // Essai de nombre de 1 à 9 dans chacun des cases : APPLICATION CONDITION IFSAFE DANS LE TABLEAU ET REMPLISSAGE
            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(s, row, column, num))
                {
                    s.Cells[row][column] = num;
                    if (Solve(s))
                    {
                        return true;
                    }
                    else
                    {
                        s.Cells[row][column] = 0;
                    }
                }
            }
            return false;
        }
    }
}