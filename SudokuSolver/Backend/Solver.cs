using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Solver
    {
        public string[,] Solve(string[,] partialSudokuGrid)
        {
            return SolveSudokuPuzzle(partialSudokuGrid);
        }

        private string[,] SolveSudokuPuzzle(string[,] partialSudokuGrid)
        {
            SudokuGrid sudokuGrid = new SudokuGrid(partialSudokuGrid);

            return null;
        }
    }
}
