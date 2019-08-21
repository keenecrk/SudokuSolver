using System.Collections.Generic;

namespace Backend
{
    public class SudokuCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string CellValue { get; private set; }

        public List<string> PossibleValues { get; } = new List<string>
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

        public bool AssignValue(string value)
        {
            if (!PossibleValues.Contains(value))
            {
                return false;
            }

            CellValue = value;
            PossibleValues.Clear();

            foreach (var cell in Peers)
            {
                if (!cell.EliminatePossibleValue(value))
                {
                    return false;
                }
            }

            return true;
        }

        public bool EliminatePossibleValue(string value)
        {
            PossibleValues.Remove(value);
            if (PossibleValues.Count == 1)
            {
                return AssignValue(value);
            }
            else if (PossibleValues.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}