using System;
using System.Linq;

namespace Sudoku
{
    public class Serialize : ISerialize
    {
        private readonly Game game;

        public Serialize(Game game)
        {
            this.game = game;
        }

        public void FromCSV(string csv)
        {
            game.Set(csv.Split(',').Select(x => int.Parse(x)).ToArray());
        }
        public string ToCSV()
        {
            return string.Join(",", game.CellValue);
        }
        public void SetCell(int value, int gridIndex)
        {
            game.CellValue[gridIndex] = value;
        }
        
        public int GetCell(int gridIndex)
        {
            return game.CellValue[gridIndex];
        }
        public string ToPrettyString()
        {

            string result = $"SUDOKU{Environment.NewLine}";
            int counter = 0;
            foreach (int i in game.CellValue)
            {

                counter++;
                if (i == 0)
                {
                    result += $"  | ";
                } else
                {
                    result += $"{i} | ";
                }
                
                if (counter % game.MaxValue == 0)
                {
                    result += Environment.NewLine + Environment.NewLine;

                }
            }

            return result;
        }
    }
}
