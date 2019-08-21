using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public static class SudokuGridInitializer
    {
        const int GRID_SIZE = 9;
        public static SudokuGrid InitGrid(string[,] partialValues)
        {
            List<SudokuCell> cells = InitCells();
            MapPeers(cells);
            List<List<SudokuCell>> units = InitUnits(cells);
            InitValues(partialValues, cells);
            SudokuGrid grid = new SudokuGrid
            {
                Cells = cells,
                Units = units
            };

            return grid;
        }

        private static List<SudokuCell> InitCells()
        {
            List<SudokuCell> cells = new List<SudokuCell>();

            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    cells.Add(new SudokuCell
                    {
                        Row = row,
                        Column = column
                    });
                }
            }

            return cells;
        }

        private static void MapPeers(List<SudokuCell> cells)
        {
            foreach (var cell in cells)
            {
                cell.Peers.UnionWith(cells.Where(
                    x => IsPeerOf(cell, x)));
            }
        }

        private static bool IsPeerOf(SudokuCell cell, SudokuCell other)
        {
            return IsRowPeerOf(cell, other)
                || IsColumnPeerOf(cell, other)
                || IsSquarePeerOf(cell, other);
        }

        private static bool IsRowPeerOf(SudokuCell cell, SudokuCell other)
        {
            return cell != other && other.Row == cell.Row;
        }

        private static bool IsColumnPeerOf(SudokuCell cell, SudokuCell other)
        {
            return cell != other && other.Column == cell.Column;
        }

        private static bool IsSquarePeerOf(SudokuCell cell, SudokuCell other)
        {
            return cell != other
                && other.Row / 3 == cell.Row / 3
                && other.Column / 3 == cell.Column / 3;
        }

        private static List<List<SudokuCell>> InitUnits(List<SudokuCell> cells)
        {
            List<List<SudokuCell>> units = new List<List<SudokuCell>>();

            for (int i = 0; i < GRID_SIZE; i++)
            {
                units.Add(cells.Where(x => x.Row == i).ToList());
                units.Add(cells.Where(x => x.Column == i).ToList());
            }

            for (int squareRow = 0; squareRow < 3; squareRow++)
            {
                for (int squareColumn = 0; squareColumn < 3; squareColumn++)
                {
                    units.Add(cells.Where(x => x.Row / 3 == squareRow && x.Column / 3 == squareColumn).ToList());
                }
            }

            return units;
        }

        private static void InitValues(string[,] partialValues, List<SudokuCell> cells)
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    string source = partialValues[row, column];
                    if (!source.Equals("."))
                    {
                        var cell = cells.Where(x => x.Row == row && x.Column == column).FirstOrDefault();
                        if (!cell.AssignValue(source))
                        {
                            throw new Exception("Invalid Puzzle");
                        }
                    }
                }
            }
        }
    }
}
