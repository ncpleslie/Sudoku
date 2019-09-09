using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sudoku;

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
                         "3,1,4,0";
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
        public void Restart_GameResetToInititalState()
        {
            var origArray = new int[] { 1, 0, 2, 0, 2, 4, 3, 1, 4, 2, 1, 3, 3, 1, 4, 0 };

            game.SetByColumn(3, 1, 0);
            game.Restart();

            Assert.AreEqual(origArray, game.ToArray());
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
            game.SetByColumn(newValue, 1, 0);
            bool result = game.CellValue[1] == newValue ? true : false;
            Assert.IsTrue(result);
        }

        [Test]
        public void SetByColumn_NumberIsValid_ReadOnly()
        {
            var newValue = 3;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetByColumn(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "this cell is readonly");
        }

        [Test]
        public void SetByColumn_NumberIsPositiveInvalid_OutOfRange()
        {
            var newValue = 10;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetByColumn(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "number out of range");
        }

        [Test]
        public void SetByColumn_NumberIsNegativeInvalid_OutOfRange()
        {
            var newValue = -10;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetByColumn(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "number out of range");
        }

        [Test]
        public void SetByRow_NumberIsValid_ChangesCellValue()
        {
            var newValue = 4;
            game.SetByRow(newValue, 0, 1);
            bool result = game.CellValue[1] == newValue ? true : false;
            Assert.IsTrue(result);
        }

        [Test]
        public void SetByRow_NumberIsValid_ReadOnly()
        {
            var newValue = 3;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetByRow(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "this cell is readonly");
        }

        [Test]
        public void SetByRow_NumberIsPositiveInvalid_OutOfRange()
        {
            var newValue = 10;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetByRow(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "number out of range");
        }

        [Test]
        public void SetByRow_NumberIsNegativeInvalid_OutOfRange()
        {
            var newValue = -10;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetByRow(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "number out of range");
        }

        [Test]
        public void SetBySquare_NumberIsValid_ChangesCellValue()
        {
            var newValue = 2;
            game.SetBySquare(newValue, 3, 3);
            var result = game.CellValue[15];
            Assert.AreEqual(newValue, result);
        }

        [Test]
        public void SetBySquare_NumberIsValid_ReadOnly()
        {
            var newValue = 3;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetByRow(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "this cell is readonly");
        }

        [Test]
        public void SetBySquare_NumberIsPositiveInvalid_OutOfRange()
        {
            var newValue = 10;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetBySquare(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "number out of range");
        }

        [Test]
        public void SetBySquare_NumberIsNegativeInvalid_OutOfRange()
        {
            var newValue = -10;
            var ex = Assert.Throws<InvalidOperationException>(() => game.SetBySquare(newValue, 0, 0));
            Assert.AreEqual(ex.Message, "number out of range");
        }

        // Get Tests
        [Test]
        public void GetByColumn_NumberIsValid_ReturnsFirstCell()
        {
            var value = game.GetByColumn(0, 0);
            var result = game.CellValue[0];
            Assert.AreEqual(result, value);
        }

        [Test]
        public void GetByColumn_NumberIsValid_ReturnsLastCell()
        {
            var value = game.GetByColumn(3, 3);
            var result = game.CellValue[15];
            Assert.AreEqual(result, value);
        }

        [Test]
        public void GetByRow_NumberIsValid_ReturnsSecondCell()
        {
            var value = game.GetByRow(0, 1);
            var result = game.CellValue[1];
            Assert.AreEqual(result, value);
        }

        [Test]
        public void GetByRow_NumberIsValid_ReturnsLastCell()
        {
            var value = game.GetByColumn(3, 3);
            var result = game.CellValue[15];
            Assert.AreEqual(result, value);
        }

        [Test]
        public void GetBySquare_NumberIsValid_ReturnsTwo()
        {
            var expectedResult = 2;
            var value = game.GetBySquare(1, 0);
            Assert.AreEqual(expectedResult, value);
        }
    }
}