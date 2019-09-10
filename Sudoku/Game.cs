using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public partial class Game : IGame, ISet, IGet, ISerialize
    {
        public string OriginalGame { get; set; }
        public int[] CellValue { get; set; }
        public int SquareHeight { get; set; }
        public int SquareWidth { get; set; }
        public int MaxValue { get; set; }
        

        public void SetMaxValue(int maximum)
        {
            MaxValue = maximum;
        }

        public int GetMaxValue()
        {
            return MaxValue;
        }

        public int[] ToArray()
        {
            return CellValue;
        }

        public void Set(int[] cellValues)
        {
            CellValue = cellValues;
        }

        public void SetSquareWidth(int squareWidth)
        {
            SquareWidth = squareWidth;
        }

        public int GetSquareWidth()
        {
            return SquareWidth;
        }

        public void SetSquareHeight(int squareHeight)
        {
            SquareHeight = squareHeight;
        }

        public int GetSquareHeight()
        {
            return SquareHeight;
        }

        public void Restart()
        {
            FromCSV(OriginalGame);
        }

        // Back functionality
        private Stack<int[]> previousTurns = new Stack<int[]>();

        private void StorePreviousTurn()
        {
            int[] array = new int[CellValue.Length];
            CellValue.CopyTo(array, 0);
            previousTurns.Push(array);
        }

        public void GoBack()
        {
            int[] replacement = previousTurns.Pop();
            replacement.CopyTo(CellValue, 0);
        }
    }
}
