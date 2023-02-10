using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Shared;

namespace Sudoku.Solution
{
    public class GenericSolver : ISudokuSolver
    {
        public SudokuGrid Solve(SudokuGrid s)
        {
            return s.CloneSudoku();
        }

    }
}
