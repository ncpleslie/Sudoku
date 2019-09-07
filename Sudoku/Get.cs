using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    // Get class will return an entire Row, Column, or Square based on a single user input
    // Or will return a select int found within a Row, Column, or Sqaure based on two inputs
    class Get : IGet
    {
        private readonly Game game;
        private List<int> _listToBeChecked = new List<int> { };

        public Get(Game game)
        {
            this.game = game;
        }

        // Get individual elements
        public int GetByColumn(int columnIndex, int rowIndex)
        {
            SetColumnList(columnIndex);
            return _listToBeChecked[rowIndex];
        }

        private void SetColumnList(int columnIndex)
        {
            int columnStart = columnIndex - 1;
            int length = game.CellValue.Count();

            for (int i = columnStart; i <= length - 1; i += game.MaxValue)
            {
                _listToBeChecked.Add(game.CellValue[i]);
            }
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            SetRowList(rowIndex);
            return _listToBeChecked[columnIndex];
        }

        private void SetRowList(int rowIndex)
        {
            int rowStart = 0;
            if (rowIndex != 1)
            {
                rowStart = (rowIndex - 1) * game.MaxValue;
            }

            for (int i = rowStart; i <= rowStart + game.MaxValue - 1; i++)
            {
                _listToBeChecked.Add(game.CellValue[i]);
            }
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked[positionIndex];
        }

        private void SetSquareList(int squareIndex)
        {

            // To be improved

            int start;
            if (squareIndex == 1 || squareIndex == 2)
            {
                start = (squareIndex - 1) * game.SquareWidth;
            }
            else
            {
                start = (squareIndex + 1) * game.SquareWidth;
            }

            for (int i = start; i < start + game.SquareWidth; i++)
            {
                _listToBeChecked.Add(game.CellValue[i]);
            }

            int nextRow = start + game.MaxValue;
            for (int i = nextRow; i < nextRow + game.SquareWidth; i++)
            {
                _listToBeChecked.Add(game.CellValue[i]);
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

        public List<int> GetByRow(int rowIndex)
        {
            SetRowList(rowIndex);
            return _listToBeChecked;
        }

        public List<int> GetBySquare(int squareIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked;
        }
    }
}
