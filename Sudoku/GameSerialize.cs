using System;
using System.Linq;

namespace Sudoku
{
    public partial class Game : ISerialize
    {
        public void FromCSV(string csv)
        {
            Set(csv.Split(',').Select(x => int.Parse(x)).ToArray());
            OriginalGame = csv;
        }
        public string ToCSV()
        {
            return string.Join(",", CellValue);
        }
        public void SetCell(int value, int gridIndex)
        {
            CellValue[gridIndex] = value;
        }
        
        public int GetCell(int gridIndex)
        {
            return CellValue[gridIndex];
        }
        public string ToPrettyString()
        {

            string result = $"SUDOKU{Environment.NewLine}";
            int counter = 0;
            foreach (int i in CellValue)
            {

                counter++;
                if (i == 0)
                {
                    result += $"  | ";
                } else
                {
                    result += $"{i} | ";
                }
                
                if (counter % MaxValue == 0)
                {
                    result += Environment.NewLine + Environment.NewLine;

                }
            }

            return result;
        }
    }
}
