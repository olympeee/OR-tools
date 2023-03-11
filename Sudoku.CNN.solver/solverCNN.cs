using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using Sudoku.CNNsolver;
using Sudoku.Shared;



namespace sudoku.CNNsolver
{


    public class CNNSolverPython : PythonSolverBase
    {

        public override SudokuGrid Solve(SudokuGrid s)
        {
            //System.Diagnostics.Debugger.Break();

            //For some reason, the Benchmark runner won't manage to get the mutex whereas individual execution doesn't cause issues
            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyModule scope = Py.CreateScope())
            {
                var sudokuDB = new StreamReader(File.OpenRead(@".\Resources\model\Database\sudoku.csv"));
                int[][] sudok = s.Cells;



                //donner la DB et le model en tant que variable (le model en tabbleau de byte et chercher sur keras comment recup avec le model en donnant le model directement)



                // convert the Person object to a PyObject
                PyObject pySudoku = sudok.ToPython();
                Console.Write("Voulez vous charger un ancien model\n 1:oui\n 2:non je souhaite l'entrainer");
                int choix = Console.Read();

                // convert the Person object to a PyObject

                PyObject choice = choix.ToPython();

                PyObject pySudokuDB = sudokuDB.ToPython();

                // create a Python variable "person"
                scope.Set("sudoku", pySudoku);

                scope.Set("sudokuDB", pySudokuDB);

                // the person object may now be used in Python

                scope.Set("choix", choice);


                // the person object may now be used in Python

                string code = Resource1.model;
                scope.Exec(code);
                code = Resource1.data_preprocess;
                scope.Exec(code);
                code = Resource1.SolverPythonCNN;
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
}
