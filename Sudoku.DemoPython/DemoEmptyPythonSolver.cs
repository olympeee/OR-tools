using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using Sudoku.Shared;

namespace Sudoku.DemoPython
{
	public class DemoEmptyPythonSolver:PythonSolverBase
	{
		public override Shared.SudokuGrid Solve(Shared.SudokuGrid s)
		{

			//using (Py.GIL())
			//{
			// create a Python scope
			using (PyModule scope = Py.CreateScope())
			{
				
				// convert the Person object to a PyObject
				PyObject pyCells = s.Cells.ToPython();
				// create a Python variable "instance"
				scope.Set("instance", pyCells);



				// run the Python script
				string code = Resource1.PythonEmptySolver_py;
				scope.Exec(code);




				//Recover Python variable "r"
				var result = scope.Get("r");
				//Convert "r" to a .Net object
				var managedResult = result.As<int[][]>();
				//var convertesdResult = managedResult.Select(objList => objList.Select(o => (int)o).ToArray()).ToArray();
				//Build sudoku to return
				return new Shared.SudokuGrid() { Cells = managedResult };
			}
			//}

		}

		protected override void InitializePythonComponents()
		{
			InstallPipModule("numpy");
			base.InitializePythonComponents();
		}
	}
}
