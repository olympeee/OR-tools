using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Shared;


namespace SudokuCSP
{
    public class SudokuCSP : ISudokuSolver
    {

        public SudokuGrid Solve(SudokuGrid s)
        {
            int[,] sudoku;

            sudoku = Convertion(s);

            SolverCSP(sudoku, 0, 0);
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    s.Cells[i][j] = sudoku[i, j];

            return s;
        }

        public int[,] Convertion(SudokuGrid s)
        {

            int[,] sudok = new int[10, 10];


            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    sudok[i, j] = s.Cells[i][j];

            return sudok;
        }

        static bool SolverCSP(int[,] grid, int row, int col)
        {
            if (row == 9 - 1 && col == 9)
                return true;

            if (col == 9)
            {
                row++;
                col = 0;
            }

            if (grid[row, col] != 0)
                return SolverCSP(grid, row, col + 1);

            for (int num = 1; num < 10; num++)
            {
                if (IsSafe(grid, row, col, num))
                {

                    grid[row, col] = num;

                    if (SolverCSP(grid, row, col + 1))
                        return true;
                }

                grid[row, col] = 0;
            }
            return false;
        }

        static bool IsSafe(int[,] grid, int row, int col, int num)
        {
            for (int x = 0; x <= 8; x++)
                if (grid[row, x] == num)
                    return false;

            for (int x = 0; x <= 8; x++)
                if (grid[x, col] == num)
                    return false;

            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (grid[i + startRow, j + startCol] == num)
                        return false;

            return true;
        }
    }
}