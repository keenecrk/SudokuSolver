using System;
using System.Collections.Generic;

namespace Backend
{
    internal class SudokuGrid
    {
        List<SudokuCell> _grid = new List<SudokuCell>();

        public SudokuGrid(string[,] partialSudokuGrid)
        {
            InitCells();
            MapPeers();
        }

        private void InitCells()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    _grid.Add(new SudokuCell
                    {
                        Row = row,
                        Column = column
                    }); ;
                }
            }
        }

        private void MapPeers()
        {
            throw new NotImplementedException();
        }
    }
}