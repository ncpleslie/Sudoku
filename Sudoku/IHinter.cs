using System.Collections.Generic;

namespace Sudoku
{
    interface IHinter
    {
        List<int> ListPossibleValues();
    }
}
