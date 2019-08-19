using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Solver
    {
        public string[,] Solve(string[,] sudokuGrid)
        {
            return new string[9, 9]
            {
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" },
                { "9", "8", "7", "6", "5", "4", "3", "2", "1" }
            };
        }
    }
}
