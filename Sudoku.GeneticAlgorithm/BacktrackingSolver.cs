using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using Sudoku.Shared;

namespace Sudoku.GeneticAlgorithm


{
    public class BacktrackingSolver : ISudokuSolver
    {
        public SudokuGrid Solve(SudokuGrid s)
        {
            return s.CloneSudoku();
        }
        public class BackTracking
        {
            /*
            static void Main(string[] args)
            {
                int[,] grid = new int[9, 9] {
                {5, 3, 0, 0, 7, 0, 0, 0, 0},
                {6, 0, 0, 1, 9, 5, 0, 0, 0},
                {0, 9, 8, 0, 0, 0, 0, 6, 0},
                {8, 0, 0, 0, 6, 0, 0, 0, 3},
                {4, 0, 0, 8, 0, 3, 0, 0, 1},
                {7, 0, 0, 0, 2, 0, 0, 0, 6},
                {0, 6, 0, 0, 0, 0, 2, 8, 0},
                {0, 0, 0, 4, 1, 9, 0, 0, 5},
                {0, 0, 0, 0, 8, 0, 0, 7, 9}
            };

                if (Solve(grid))
                {
                    Console.WriteLine("La grille de sudoku a été résolue avec succès :");
                    PrintGrid(grid);
                }
                else
                {
                    Console.WriteLine("Impossible de résoudre la grille de sudoku.");
                }

                Console.ReadKey();
            }
            */
            static bool Solve(int[,] grid)
            {
                int row = 0;
                int col = 0;

                if (!FindUnassignedLocation(grid, ref row, ref col))
                {
                    return true;
                }

                for (int num = 1; num <= 9; num++)
                {
                    if (IsSafe(grid, row, col, num))
                    {
                        grid[row, col] = num;

                        if (Solve(grid))
                        {
                            return true;
                        }

                        grid[row, col] = 0;
                    }
                }

                return false;
            }

            static bool FindUnassignedLocation(int[,] grid, ref int row, ref int col)
            {
                for (row = 0; row < 9; row++)
                {
                    for (col = 0; col < 9; col++)
                    {
                        if (grid[row, col] == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            static bool UsedInRow(int[,] grid, int row, int num)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (grid[row, col] == num)
                    {
                        return true;
                    }
                }

                return false;
            }

            static bool UsedInCol(int[,] grid, int col, int num)
            {
                for (int row = 0; row < 9; row++)
                {
                    if (grid[row, col] == num)
                    {
                        return true;
                    }
                }

                        return false;
                    }

                    static bool UsedInBox(int[,] grid, int boxStartRow, int boxStartCol, int num)
                    {
                        for (int row = 0; row < 3; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                if (grid[row + boxStartRow, col + boxStartCol] == num)
                                {
                                    return true;
                                }
                            }
                        }

                        return false;
                    }

                    static bool IsSafe(int[,] grid, int row, int col, int num)
                    {
                        return !UsedInRow(grid, row, num) &&
                               !UsedInCol(grid, col, num) &&
                               !UsedInBox(grid, row - row % 3, col - col % 3, num);
                    }

                    static void PrintGrid(int[,] grid)
                    {
                        for (int row = 0; row < 9; row++)
                        {
                            if (row % 3 == 0)
                            {
                                Console.WriteLine("-------------------------");
                            }

                            for (int col = 0; col < 9; col++)
                            {
                                if (col % 3 == 0)
                                {
                                    Console.Write("| ");
                                }

                                Console.Write(grid[row, col] + " ");
                            }

                            Console.WriteLine("|");
                        }

                        Console.WriteLine("-------------------------");
                    }
                }
            }
}