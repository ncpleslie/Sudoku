using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    // Used to set the value of an empty spot to the user inputed value
    public partial class Game : ISet
    {
        /* 
         
             const raw sudoku data = 
            {1,2,3,0,
            2,2,3,0}

            for loop = i = 0 to < maxNum
            var row
            for loop = j = 0 to < maxNum
            var value = raw[i*maxNum+j]
            var col = value

            0*4+0 = 0 index
            0*4+1 = 1 index
            ...
            0*4+4 = 3 index

            next row
            1*4+0 = 4 index

            put row and column num 

            row = 2
            col = 2
            row -1
            col -1

            var value = raw[i*maxNum+j]

            1*4+1 = 5 index
            ans = 4

            row = 1
            col = 2
            row -1
            col -1

            var value = raw[i*maxNum+j]

            0*4+1 = 1 index
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
                }
            }
        }
    }
}
