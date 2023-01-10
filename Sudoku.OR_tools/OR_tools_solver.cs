using Sudoku.Shared;

namespace Sudoku.OR_tools;

public class ORtoolssolver : ISudokuSolver
{
    public SudokuGrid Solve(SudokuGrid s)
    {
        return s.CloneSudoku();
    }

}