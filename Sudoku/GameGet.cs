using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    // Get class will return an entire Row, Column, or Square based on a single user input
    // Or will return a select int found within a Row, Column, or Sqaure based on two inputs
    public partial class Game : IGet
    {

        private List<int> _listToBeChecked = new List<int> { };

        // Get individual elements
        public int GetByColumn(int columnIndex, int rowIndex)
        {
            return CellValue[rowIndex * MaxValue + columnIndex];
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            return GetByColumn(columnIndex, rowIndex);
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked[positionIndex];
        }

        private void SetSquareList(int squareIndex)
        {
            int height = GetSquareHeight();
            int width = GetSquareWidth();
            int length = width * width;
            int maxNum = GetMaxValue();

            // squareIndex = 0 row=0col=0
            // squareIndex = 1 row=0col=3
            // squareIndex = 2 row=0col=6
            // squareIndex = 3 row=3col=0
            // squareIndex = 4 row=3col=3
            // squareIndex = 5 row=3col=6
            // squareIndex = 6 row=6col=0
            // squareIndex = 7 row=6col=3
            // squareIndex = 8 row=6col=6

            int rowNum = squareIndex / (maxNum / width) * height;
            int colNum = squareIndex % (maxNum / width) * width;
            Console.WriteLine($"{rowNum} {colNum}");

            for (int row = rowNum; row < height + rowNum; row++)
            {
                for (int column = colNum; column < width + colNum; column++)
                {
                    Console.WriteLine(ToArray()[maxNum * row + column]);
                    _listToBeChecked.Add(ToArray()[maxNum * row + column]);
                }
            } 
        }

        // Get entire list
        // These will be used when validating user input becomes relevant
        // At this stage, out of scope of the assignment
        public List<int> GetByColumn(int columnIndex)
        {
            SetColumnList(columnIndex);
            return _listToBeChecked;
        }

        private void SetColumnList(int columnIndex)
        {
            int columnStart = columnIndex;
            int length = CellValue.Count();

            for (int i = columnStart; i <= length - 1; i += MaxValue)
            {
                _listToBeChecked.Add(CellValue[i]);
            }
        }

        public List<int> GetByRow(int rowIndex)
        {
            SetRowList(rowIndex);
            return _listToBeChecked;
        }

        private void SetRowList(int rowIndex)
        {
            int rowStart = rowIndex * MaxValue;
            for (int i = rowStart; i <= rowStart + MaxValue - 1; i++)
            {
                _listToBeChecked.Add(CellValue[i]);
            }
        }

        public List<int> GetBySquare(int squareIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked;
        }
    }
}
