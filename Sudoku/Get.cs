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
        private readonly IGame _game;
        private readonly int _maxValue;
        private readonly int _squareWidth;
        private int[] _cellValue;
        private List<int> _listToBeChecked = new List<int> { };

        public Get()
        {

        }

        public Get( IGame game )
        {
            _game = game;
            _maxValue = game.GetMaxValue();
            _squareWidth = game.GetSquareWidth();
            _cellValue = game.ToArray();
        }
        
        // Get entire list
        public List<int> GetByColumn(int columnIndex)
        {
            SetColumnList(columnIndex);
            return _listToBeChecked;
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
            int length = _cellValue.Count();

            for (int i = columnStart; i <= length - 1; i += _maxValue)
            {
                _listToBeChecked.Add(_cellValue[i]);
            }
        }

        public List<int> GetByRow(int rowIndex)
        {
            SetRowList(rowIndex);
            return _listToBeChecked;
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
                rowStart = (rowIndex - 1) * _maxValue;
            }

            for (int i = rowStart; i <= rowStart + _maxValue - 1; i++)
            {
                _listToBeChecked.Add(_cellValue[i]);
            }
        }

        public List<int> GetBySquare(int squareIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked;
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked[positionIndex];
        }

        private void SetSquareList(int squareIndex)
        {
            int start;
            if (squareIndex == 1 || squareIndex == 2)
            {
                start = (squareIndex - 1) * _squareWidth;
            }
            else
            {
                start = (squareIndex + 1) * _squareWidth;
            }

            for (int i = start; i < start + _squareWidth; i++)
            {
                _listToBeChecked.Add(_cellValue[i]);
            }

            int nextRow = start + _maxValue;
            for (int i = nextRow; i < nextRow + _squareWidth; i++)
            {
                _listToBeChecked.Add(_cellValue[i]);
            }
        }
    }
}
