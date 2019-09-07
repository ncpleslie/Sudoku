using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Game : IGame, ISet, IGet, ISerialize
    {
        Set set;
        Get get;
        Serialize serialize;

        public int[] CellValue { get; set; }
        public int SquareHeight { get; set; }
        public int SquareWidth { get; set; }
        public int MaxValue { get; set; }

        public Game()
        {
            serialize = new Serialize(this);
            get = new Get(this);
            set = new Set(this);
        }

        public void SetMaxValue(int maximum)
        {
            MaxValue = maximum;
        }

        public int GetMaxValue()
        {
            return MaxValue;
        }

        public int[] ToArray()
        {
            return CellValue;
        }

        public void Set(int[] cellValues)
        {
            CellValue = cellValues;
        }

        public void SetSquareWidth(int squareWidth)
        {
            SquareWidth = squareWidth;
        }

        public int GetSquareWidth()
        {
            return SquareWidth;
        }

        public void SetSquareHeight(int squareHeight)
        {
            SquareHeight = squareHeight;
        }

        public int GetSquareHeight()
        {
            return SquareHeight;
        }

        public void Restart()
        {
            MaxValue = 0;
            SquareWidth = 0;
            SquareHeight = 0;
            CellValue = new int[] { };
        }


        // Implement Set
        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            set.SetByColumn(value, columnIndex, rowIndex);
        }
        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            set.SetByRow(value, rowIndex, columnIndex);
        }
        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            set.SetBySquare(value, squareIndex, positionIndex);
        }

        // Implement Get
        public int GetByColumn(int columnIndex, int rowIndex)
        {
            return get.GetByColumn(columnIndex, rowIndex);
        }
        public int GetByRow(int rowIndex, int columnIndex)
        {
            return get.GetByRow(rowIndex, columnIndex);
        }
        public int GetBySquare(int squareIndex, int positionIndex)
        {
            return get.GetBySquare(squareIndex, positionIndex);
        }

        // Implement Serialize
        public void FromCSV(string csv)
        {
            serialize.FromCSV(csv);
        }
        public string ToCSV()
        {
            return serialize.ToCSV();
        }
        public void SetCell(int value, int gridIndex)
        {
            serialize.SetCell(value, gridIndex);
        }
        public int GetCell(int gridIndex)
        {
            return serialize.GetCell(gridIndex);
        }
        public string ToPrettyString()
        {
            return serialize.ToPrettyString();
        }

    }
}
