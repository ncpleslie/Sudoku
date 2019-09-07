using System.Collections.Generic;

namespace Sudoku
{
    interface IGet
    {
        int GetByColumn(int columnIndex, int rowIndex);
        int GetByRow(int rowIndex, int columnIndex);
        int GetBySquare(int squareIndex, int positionIndex);
    }
}
