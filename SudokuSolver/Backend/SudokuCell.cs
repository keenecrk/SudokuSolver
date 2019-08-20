using System.Collections.Generic;

namespace Backend
{
    internal class SudokuCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string CellValue { get; set; } = "";
        public List<string> PossibleValues { get; set; } = new List<string>
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
        };
        public HashSet<SudokuCell> Peers { get; set; } = new HashSet<SudokuCell>();
    }
}