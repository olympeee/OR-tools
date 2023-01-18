using Sudoku.Shared;

namespace Sudoku.ColorSolver
{
    public class ColorSolver : ISudokuSolver
    {
    
        SudokuGrid ISudokuSolver.Solve(SudokuGrid s)
        {
	        return s;
        }
    }
}