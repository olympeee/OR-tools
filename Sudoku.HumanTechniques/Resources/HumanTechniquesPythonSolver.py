import random
'''import ortools
// sudoku instance, we use '0' for empty cells
instance = ((0,0,0,0,9,4,0,3,0),
            (0,0,0,5,1,0,0,0,7),
            (0,8,9,0,0,0,0,4,0),
            (0,0,0,0,0,0,2,0,8),
            (0,6,0,2,0,1,0,5,0),
            (1,0,2,0,0,0,0,0,0),
            (0,7,0,0,0,0,5,2,0),
            (9,0,0,0,6,5,0,0,0),
            (0,4,0,9,7,0,0,0,0))
r=instance
def generate_grid():
   grid = [[0 for x in range(9)] for y in range(9)]

    for i in range(9):
        for j in range(9):
            while True:
                num = random.randint(1, 9)
                if is_valid(grid, i, j, num):
                    grid[i][j] = num
                    break

    return grid
'''

def is_valid(grid, row, col, num):
    # check row
    for i in range(9):
        if grid[row][i] == num:
            return False

    # check column
    for i in range(9):
        if grid[i][col] == num:
            return False

    # check 3x3 subgrid
    row_start = (row // 3) * 3
    col_start = (col // 3) * 3

    for i in range(3):
        for j in range(3):
            if grid[row_start + i][col_start + j] == num:
                return False

    return True


def solve(grid):
    for row in range(9):
        for col in range(9):
            if grid[row][col] == 0:
                for num in range(1, 10):
                    if is_valid(grid, row, col, num):
                        grid[row][col] = num
                        if solve(grid):
                            return True
                        grid[row][col] = 0
                return False
    return True


'''grid = generate_grid()
print("Grille générée:")
for row in grid:
    print(row)
print()'''

if solve(grid):
    '''print("Grille résolue:")
    for row in grid:
        print(row)'''
    r = grid
else:
    print("Impossible de résoudre la grille.")