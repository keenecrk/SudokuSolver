using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Tests
{
    public class SudokuGridInitializerTests
    {
        SudokuGrid _grid;
        public SudokuGridInitializerTests()
        {
            string[,] values = new string[9, 9]
            {
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." },
                { ".", ".", ".",".", ".", ".",".", ".", "." }
            };

            _grid = SudokuGridInitializer.InitGrid(values);
        }

        [Fact]
        public void NewGridShouldHave81Cells()
        {
            int expected = 81;

            int actual = _grid.Cells.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EachCellInNewGridShouldHave20Peers()
        {
            int expected = 20;

            foreach (var cell in _grid.Cells)
            {
                int actual = cell.Peers.Count;
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void NewGridShouldHave27Units()
        {
            int expected = 27;

            int actual = _grid.Units.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EachUnitInNewGridShouldHave9Cells()
        {
            int expected = 9;

            foreach (var unit in _grid.Units)
            {
                int actual = unit.Count;
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void EachCellInNewGridShouldBelongTo3Units()
        {
            int expected = 3;

            foreach (var cell in _grid.Cells)
            {
                int unitCount = 0;
                foreach (var unit in _grid.Units)
                {
                    if (unit.Contains(cell))
                    {
                        unitCount += 1;
                    }
                }
                Assert.Equal(expected, unitCount);
            }
        }
    }
}
