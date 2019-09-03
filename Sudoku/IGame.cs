namespace Sudoku
{
    interface IGame
    {
        void SetMaxValue(int maximum);
        int GetMaxValue();
        int[] ToArray();
        void Set(int[] cellValues);
        void SetSquareWidth(int squareWidth);
        int GetSquareWidth();
        void SetSquareHeight(int squareHeight);
        int GetSquareHeight();
        void Restart();
    }
}
