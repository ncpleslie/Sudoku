using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    // Used to set the value of an empty spot to the user inputed value
    public class Set : ISet
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

        private readonly Game game;

        public Set(Game game)
        {
            this.game = game;
        }

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            if (value < 1 || value > game.MaxValue)
                throw new System.InvalidOperationException("number out of range");

            columnIndex--;
            rowIndex--;

            int cellsContent = game.CellValue[rowIndex * game.MaxValue + columnIndex];
            if (cellsContent != 0)
                throw new System.InvalidOperationException("this cell is readonly");

            game.CellValue[rowIndex * game.MaxValue + columnIndex] = value;
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            SetByColumn(value, columnIndex, rowIndex);
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            if (value < 1 || value > game.MaxValue)
                throw new System.InvalidOperationException("number out of range");

            int rowNum = squareIndex / (game.MaxValue / game.SquareWidth) * game.SquareHeight;
            int colNum = squareIndex % (game.MaxValue / game.SquareWidth) * game.SquareWidth;
            game.CellValue[game.MaxValue * rowNum + colNum] = value;
        }
    }
}
