using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        private Game game = new Game();
        [SetUp]
        public void Setup()
        {
            game.SetMaxValue(4);
            game.SetSquareWidth(2);
            game.SetSquareHeight(2);
            string csv = "1,0,2,0," +
                         "2,4,3,1," +
                         "4,2,1,3," +
                         "3,1,4,2";
            game.FromCSV(csv);
        }

        // Game Tests
        [Test]
        public void SetMaxValue_NumberIsValid_MaxValueEqualsInput()
        {
            var maxNum = 5;
            game.SetMaxValue(maxNum);
            Assert.AreEqual(maxNum, game.MaxValue);
        }

        [Test]
        public void SetSquareWidth_NumberIsValid_ValueEqualsInput()
        {
            var value = 5;
            game.SetSquareWidth(value);
            Assert.AreEqual(value, game.SquareWidth);
        }

        [Test]
        public void SetSquareHeight_NumberIsValid_ValueEqualsInput()
        {
            var value = 5;
            game.SetSquareHeight(value);
            Assert.AreEqual(value, game.SquareHeight);
        }

        [Test]
        public void GetSquareWidth_NumberIsValid_ValueEqualsSetState()
        {
            var value = 2;
            Assert.AreEqual(value, game.GetSquareWidth());
        }

        [Test]
        public void GetSquareHeight_NumberIsValid_ValueEqualsSetState()
        {
            var value = 2;
            Assert.AreEqual(value, game.GetSquareHeight());
        }

        [Test]
        public void ToArrayAndSet_NumberIsValid_CellValuesEqualCelLValues()
        {
            var value = new int[] { 1, 2, 7, 2, 2, 4, 4, 5, 4, 2, 1, 3, 3, 1, 2, 2 };
            game.Set(value);
            Assert.AreEqual(value, game.ToArray());
        }

        [Test]
        public void Restart_AllValuesEqualNullOrZero()
        {
            game.Restart();
            var emptyArr = new int[] { };
            Assert.AreEqual(emptyArr, game.ToArray());
            Assert.AreEqual(0, game.GetSquareHeight());
            Assert.AreEqual(0, game.GetSquareWidth());
            Assert.AreEqual(0, game.GetMaxValue());
        }

        // Serialize tests
        /* FromCSV
        ToCSV
        SetCell
        GetCell
        ToPrettyString */
        [Test]
        public void FromCSV_StringCommaSeperated_ReturnArrayOfInt()
        {
            string csv = "1,0,2,0," +
              "2,4,3,1," +
              "4,2,1,3," +
              "0,0,0,0";
            game.FromCSV(csv);
            int[] value = new int[] { 1,0,2,0,2,4,3,1,4,2,1,3,0,0,0,0};
            var returned = game.ToArray();
            Assert.AreEqual(value, returned);
        }

        [Test]
        public void ToCSV_ArrayOfInt_ReturnString()
        {
            string csv = "1,0,2,0," +
                    "2,4,3,1," +
              "4,2,1,3," +
              "0,0,0,0";
            game.FromCSV(csv);
            var returned = game.ToCSV();
            Assert.AreEqual(csv, returned);
        }

        [Test]
        public void SetCellAndGetCell_ValidInt_ReturnInt()
        {
            var value = 10;
            var cellNum = 10;
            game.SetCell(value, cellNum);
            var result = game.GetCell(cellNum);
            Assert.AreEqual(value, result);
        }

        [Test]
        public void ToPrettyString_ReturnString()
        {
            var result = game.ToPrettyString();
            Assert.IsInstanceOf<string>(result);
        }

        // Set tests
        [Test]
        public void SetByColumn_NumberIsValid_ChangesCellValue()
        {
            var newValue = 3;
            game.SetByColumn(newValue, 2, 1);
            bool result = game.CellValue[1] == newValue ? true : false;
            Assert.IsTrue(result);
        }

        [Test]
        public void SetByRow_NumberIsValid_ChangesCellValue()
        {
            var newValue = 4;
            game.SetByRow(newValue, 1, 2);
            bool result = game.CellValue[1] == newValue ? true : false;
            Assert.IsTrue(result);
        }

        [Test]
        public void SetBySquare_NumberIsValid_ChangesCellValue()
        {
            var newValue = 2;
            game.SetBySquare(newValue, 0, 1);
            var result = game.CellValue[1];
            Assert.AreEqual(newValue, result);
            
        }

        // Get Tests
        [Test]
        public void GetByColumn_NumberIsValid_ReturnsFirstCell()
        {
            var value = game.GetByColumn(1, 1);
            Assert.AreEqual(1, value);
        }

        [Test]
        public void GetByRow_NumberIsValid_ReturnsSecondCell()
        {
            var value = game.GetByRow(1, 2);
            Assert.AreEqual(0, value);
        }

        [Test]
        public void GetBySquare_NumberIsValid_ReturnsTwo()
        {
            var expectedResult = 2;
            var value = game.GetBySquare(1, 0);
            Assert.AreEqual(expectedResult, value);
        }
    }

    public class Game
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

    public class Set
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

    class Get
    {
        private readonly Game game;
        private List<int> _listToBeChecked = new List<int> { };

        public Get(Game game)
        {
            this.game = game;
        }

        // Get individual elements
        public int GetByColumn(int columnIndex, int rowIndex)
        {
            columnIndex--;
            rowIndex--;

            return game.CellValue[rowIndex * game.MaxValue + columnIndex];
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            return GetByColumn(columnIndex, rowIndex);
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked[positionIndex];
        }

        private void SetSquareList(int squareIndex)
        {
            int height = game.GetSquareHeight();
            int width = game.GetSquareWidth();
            int length = width * width;
            int maxNum = game.GetMaxValue();

            // squareIndex = 0 row=0col=0
            // squareIndex = 1 row=0col=3
            // squareIndex = 2 row=0col=6
            // squareIndex = 3 row=3col=0
            // squareIndex = 4 row=3col=3
            // squareIndex = 5 row=3col=6
            // squareIndex = 6 row=6col=0
            // squareIndex = 7 row=6col=3
            // squareIndex = 8 row=6col=6

            int rowNum = squareIndex / (maxNum / width) * height;
            int colNum = squareIndex % (maxNum / width) * width;
            Console.WriteLine($"{rowNum} {colNum}");

            for (int row = rowNum; row < height + rowNum; row++)
            {
                for (int column = colNum; column < width + colNum; column++)
                {
                    Console.WriteLine(game.ToArray()[maxNum * row + column]);
                    _listToBeChecked.Add(game.ToArray()[maxNum * row + column]);
                }
            }
        }

            // Get entire list
            // These will be used when validating user input becomes relevant
            // At this stage, out of scope of the assignment
            public List<int> GetByColumn(int columnIndex)
        {
            SetColumnList(columnIndex);
            return _listToBeChecked;
        }

        private void SetColumnList(int columnIndex)
        {
            int columnStart = columnIndex - 1;
            int length = game.CellValue.Count();

            for (int i = columnStart; i <= length - 1; i += game.MaxValue)
            {
                _listToBeChecked.Add(game.CellValue[i]);
            }
        }

        public List<int> GetByRow(int rowIndex)
        {
            SetRowList(rowIndex);
            return _listToBeChecked;
        }

        private void SetRowList(int rowIndex)
        {
            int rowStart = 0;
            if (rowIndex != 1)
            {
                rowStart = (rowIndex - 1) * game.MaxValue;
            }

            for (int i = rowStart; i <= rowStart + game.MaxValue - 1; i++)
            {
                _listToBeChecked.Add(game.CellValue[i]);
            }
        }

        public List<int> GetBySquare(int squareIndex)
        {
            SetSquareList(squareIndex);
            return _listToBeChecked;
        }
    }

    public class Serialize
    {
        private readonly Game game;

        public Serialize(Game game)
        {
            this.game = game;
        }

        public void FromCSV(string csv)
        {
            game.CellValue = csv.Split(',').Select(x => int.Parse(x)).ToArray();
        }
        public string ToCSV()
        {
            return string.Join(",", game.CellValue);
        }
        public void SetCell(int value, int gridIndex)
        {
            game.CellValue[gridIndex] = value;
        }

        public int GetCell(int gridIndex)
        {
            return game.CellValue[gridIndex];
        }
        public string ToPrettyString()
        {

            string result = $"SUDOKU{Environment.NewLine}";
            int counter = 0;
            foreach (int i in game.CellValue)
            {

                counter++;
                if (i == 0)
                {
                    result += $"  | ";
                }
                else
                {
                    result += $"{i} | ";
                }

                if (counter % game.MaxValue == 0)
                {
                    result += Environment.NewLine + Environment.NewLine;

                }
            }

            return result;
        }
    }
}