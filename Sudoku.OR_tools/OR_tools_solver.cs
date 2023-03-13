using Sudoku.Shared;
using Python.Runtime;
using System.Resources;

namespace Sudoku.OR_tools;

public class ORtoolssolver : PythonSolverBase
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
                // convert the Person object to a PyObject
                PyObject pyCells = s.Cells.ToPython();

                // create a Python variable "person"
                scope.Set("instance", pyCells);


				this.AddNumpyConverterScript(scope);
				
                // the person object may now be used in Python
                string code = Resources.OR_Tools_py;
                scope.Exec(code);
                var result = scope.Get("r");
                var managedResult = result.As<int[,]>().ToJaggedArray();
                //var convertesdResult = managedResult.Select(objList => objList.Select(o => (int)o).ToArray()).ToArray();
                return new Shared.SudokuGrid() { Cells = managedResult };
            }
            //}
        }

        protected override void InitializePythonComponents()
        {
            InstallPipModule("ortools");
            base.InitializePythonComponents();
        }
     
}



       
    

