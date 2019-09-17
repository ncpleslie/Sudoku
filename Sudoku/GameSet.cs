namespace Sudoku
{
    // Used to set the value of an empty spot to the user inputed value
    public partial class Game : ISet
    {
        /* 
         This is the method that makes it all work
         [i*maxNum+j]
         i = row
         j = column
        */
        private bool IsReadOnly(int cellContent) 
        {
            bool result = false;
            if (cellContent != 0)
            {
                result = true;
                throw new System.InvalidOperationException("this cell is readonly");
            }
            return result;
        }

        private bool IsUserInputNumValid(int userInput)
        {
            bool result = true;
            if (userInput < 1 || userInput > MaxValue)
            {
                result = false;
                throw new System.InvalidOperationException("number out of range");
            }
            return result;
        }

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
           if (IsUserInputNumValid(value))
            {
                int cellsContent = CellValue[rowIndex * MaxValue + columnIndex];

                if (!IsReadOnly(cellsContent))
                {
                    StorePreviousTurn();
                    CellValue[rowIndex * MaxValue + columnIndex] = value;
                    CountTurnsTaken();
                }
            }
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            SetByColumn(value, columnIndex, rowIndex);
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            if (IsUserInputNumValid(value))
            {
                int rowNum = squareIndex / (MaxValue / SquareWidth) * SquareHeight;
                int colNum = squareIndex % (MaxValue / SquareWidth) * SquareWidth;
                int cellContent = CellValue[MaxValue * (rowNum + (positionIndex % SquareWidth)) + (colNum + (positionIndex % SquareWidth))];
                
                if (!IsReadOnly(cellContent))
                {
                    StorePreviousTurn();
                    CellValue[MaxValue * (rowNum + (positionIndex % SquareWidth)) + (colNum + (positionIndex % SquareWidth))] = value;
                    CountTurnsTaken();
                }
            }
        }
    }
}
