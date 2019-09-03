namespace Sudoku
{
    public class Game : IGame
    {
        public int _maxValue;
        public int _squareWidth;
        public int _squareHeight;
        public int[] _cellValue;

        public Game()
        {

        }

        public Game(int maxValue, int squareWidth, int squareHeight, int[] cellValue)
        {
            _maxValue = maxValue;
            _squareWidth = squareWidth;
            _squareHeight = squareHeight;
            _cellValue = cellValue;
        }

        public void SetMaxValue(int maximum)
        {
            _maxValue = maximum;
        }

        public int GetMaxValue()
        {
            return _maxValue;

        }

        public int[] ToArray()
        {
            return _cellValue;
        }

        public void Set(int[] cellValues)
        {
            _cellValue = cellValues;
        }

        public void SetSquareWidth(int squareWidth)
        {
            _squareWidth = squareWidth;
        }

        public int GetSquareWidth()
        {
            return _squareWidth;
        }

        public void SetSquareHeight(int squareHeight)
        {
            _squareHeight = squareHeight;
        }

        public int GetSquareHeight()
        {
            return _squareHeight;
        }

        public void Restart()
        {
            _maxValue = 0;
            _squareWidth = 0;
            _squareHeight = 0;
            _cellValue = new int[] { };
        }
    }
}
