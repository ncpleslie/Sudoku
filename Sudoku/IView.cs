using System.Collections.Generic;

namespace Sudoku
{
    interface IView
    {
        void Show<T>(T message);
        int GetInt(string prompt);
        int[] GetIntArray(string prompt);
        string GetString(string prompt);
        void ShowList<T>(List<int> list);
        void Clear();
    }
}
