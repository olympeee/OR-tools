using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using Sudoku.Shared;



namespace Sudoku.CNNSolver
{


    public class CNNSolverPython : PythonSolverBase
    {

        public override Shared.SudokuGrid Solve(Shared.SudokuGrid s)
        {
            //System.Diagnostics.Debugger.Break();

            //For some reason, the Benchmark runner won't manage to get the mutex whereas individual execution doesn't cause issues
            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyModule scope = Py.CreateScope())
            {

                int[][] sudok = s.Cells;

                // convert the Person object to a PyObject
                PyObject pySudoku = sudok.ToPython();

                // create a Python variable "person"
                scope.Set("sudoku", pySudoku);

                // the person object may now be used in Python
                string code = Resources.SolverPythonCNN;
                scope.Exec(code);
                var result = scope.Get("Sudoku");
                var toReturn = result.As<int[][]>();


                s.Cells = toReturn;


                return s;
            }
            //}

        }

        protected override void InitializePythonComponents()
        {
            InstallPipModule("keras");
            InstallPipModule("tensorflow");
            InstallPipModule("numpy");
            InstallPipModule("panda");

            base.InitializePythonComponents();
        }



    }


}
