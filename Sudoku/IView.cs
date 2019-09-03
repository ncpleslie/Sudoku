namespace Sudoku
{
    interface IView
    {
        void Show<T>(T message);
        int GetInt(string prompt);
        string GetString(string prompt);
    }
}
