namespace Sudoku
{
    interface IView
    {
        void Show<T>(T message);
        int GetInt(string prompt);
        int[] GetIntArray(string prompt);
        string GetString(string prompt);
        void Clear();
    }
}
