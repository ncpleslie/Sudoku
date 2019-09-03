using System.Collections.Generic;

namespace Sudoku
{
    interface IGet
    {
        List<int> GetByColumn(int columnIndex);
        int GetByColumn(int columnIndex, int rowIndex);
        List<int> GetByRow(int rowIndex);
        int GetByRow(int rowIndex, int columnIndex);
        List<int> GetBySquare(int squareIndex);
        int GetBySquare(int squareIndex, int positionIndex);
    }
}
