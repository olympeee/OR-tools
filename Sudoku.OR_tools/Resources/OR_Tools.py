import random
import math
import numpy as np
from ortools.sat.python import cp_model

instance=     [[9, 0, 2, 0, 0, 5, 4, 0, 3],
               [1, 0, 0, 0, 6, 3, 0, 2, 5],
               [5, 0, 8, 4, 0, 7, 0, 6, 0],
               [0, 2, 6, 3, 0, 9, 0, 0, 1],
               [0, 5, 7, 0, 1, 0, 2, 9, 0],
               [0, 9, 0, 6, 7, 0, 5, 3, 0],
               [2, 4, 0, 5, 3, 0, 6, 0, 0],
               [7, 0, 5, 2, 0, 0, 3, 0, 4],
               [0, 8, 0, 0, 4, 1, 9, 5, 0]]

r=instance

def solve_sudoku(grid):
    model = cp_model.CpModel()
    dimension = 9
    cells = {}
    for i in range(dimension):
        for j in range(dimension):
            if grid[i][j] == 0:
                #le resolveur crée les variables du pb sous un tableau cell
                cell = model.NewIntVar(1, 9, "cell[%i,%i]" % (i, j))
                cells[i, j] = cell
            else:
                cell = model.NewIntVar(grid[i][j], grid[i][j], "cell[%i,%i]" % (i, j))
                cells[i, j] = cell
                model.Add(cell == grid[i][j])
#Elaboration contraintes lignes et colonnes
    for i in range(dimension):
        row = [cells[i, j] for j in range(dimension)]
        model.AddAllDifferent(row)
        col = [cells[j, i] for j in range(dimension)]
        model.AddAllDifferent(col)
#Elaboration contrainte bloc
    for i in range(3):
        for j in range(3):
            block = [cells[x + i * 3, y + j * 3] for x in range(3) for y in range(3)]
            model.AddAllDifferent(block)

    solver = cp_model.CpSolver()
    solution = solver.Solve(model)

    if solution == cp_model.OPTIMAL:
      
        result = np.zeros((dimension, dimension), dtype=int)
        for i in range(dimension):
            for j in range(dimension):
                result[i, j] = int(solver.Value(cells[i, j]))
        return result
    else:
        return None

solution = solve_sudoku(grid)
if solution is not None:
    for row in solution:
        print(row)
else:
    print("No solution found.")


