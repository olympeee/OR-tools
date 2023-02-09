using Sudoku.Shared;

namespace Sudoku.GeneticAlgorithm


{
    public class BacktrackingSolver : ISudokuSolver
    {
        public SudokuGrid Solve(SudokuGrid s)
        {
            return s.CloneSudoku();
        }

    }
}