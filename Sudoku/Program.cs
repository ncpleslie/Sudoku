using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class Globals
    {
        public const int maxValue = 4;
        public const int squareWidth = 2;
        public const int squareHeight = 2;
        static public int[] cellValue = new int[]
        {
                1,0,2,0,
                2,4,3,1,
                4,2,1,3,
                3,1,4,2
        };
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> possibleNums = new Hinter(new ValidityChecker()).RowPossibleValues(1);
            foreach(int i in possibleNums)
            {
                Console.WriteLine(i);
            }

            if (new ValidityChecker().ColumnValid(2))
            {
                Console.WriteLine("Valid");
            } else
            {
                Console.WriteLine("Failed");
            }
        }
    }

    class Hinter
    {
        private readonly IValidityChecker validityChecker;
        private List<int> listToBeChecked;
        public Hinter(IValidityChecker validityChecker)
        {
            this.validityChecker = validityChecker;
        }

        public List<int> RowPossibleValues(int rowNumber)
        {
            validityChecker.SetRow(rowNumber);
            listToBeChecked = validityChecker.GetListToBeChecked();
            return PossibleValues();
        }

        public List<int> ColumnPossibleValues(int columnNumber)
        {
            validityChecker.SetColumn(columnNumber);
            listToBeChecked = validityChecker.GetListToBeChecked();
            return PossibleValues();
        }

        public List<int> SquarePossibleValues(int squareNumber)
        {
            validityChecker.SetSquare(squareNumber);
            listToBeChecked = validityChecker.GetListToBeChecked();
            return PossibleValues();
        }

        private List<int> PossibleValues()
        {
            List<int> missingNums = new List<int> { };
            var range = Enumerable.Range(1, Globals.maxValue);

            if (!validityChecker.CheckBlanks())
            {
                missingNums = range.Except(listToBeChecked).ToList();
            }
            return missingNums;
        }
    }

    class ValidityChecker : IValidityChecker
    {
        private List<int> listToBeChecked = new List<int> { };
        private readonly int maxValue;
        private readonly int squareWidth;
        private readonly int squareHeight;
        private readonly int[] cellValue;

        public ValidityChecker()
        {
            maxValue = Globals.maxValue;
            squareWidth = Globals.squareWidth;
            squareHeight = Globals.squareHeight;
            cellValue = Globals.cellValue;
        }

        public List<int> GetListToBeChecked()
        {
            return listToBeChecked;
        }

        public bool CheckBlanks()
        {
            bool isValid = false;
            foreach (int num in listToBeChecked)
            {
                if (num != 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }

        private bool CheckRange()
        {
            bool isValid = false;
            foreach (int num in listToBeChecked)
            {
                if (num < maxValue || num > 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    return isValid;
                }
            }
            return isValid;
        }

        private bool CheckDuplicates()
        {
            bool isValid = false;
            if (listToBeChecked.Count == listToBeChecked.Distinct().Count())
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                return isValid;
            }
            return isValid;
        }

        public void SetRow(int rowNumber)
        {
            int rowStart = 0;
            if (rowNumber != 1)
            {
                rowStart = (rowNumber - 1) * maxValue;
            }

            for (int i = rowStart; i <= rowStart + maxValue - 1; i++)
            {
                listToBeChecked.Add(cellValue[i]);
            }
        }

        public void SetColumn(int columnNumber)
        {
            int columnStart = columnNumber - 1;
            int length = cellValue.Count();

            for (int i = columnStart; i <= length - 1; i += maxValue)
            {
                listToBeChecked.Add(cellValue[i]);
            }
        }

        public void SetSquare(int squareNumber)
        {
            int start;
            if (squareNumber == 1 || squareNumber == 2)
            {
                start = (squareNumber - 1) * squareWidth;
            }
            else
            {
                start = (squareNumber + 1) * squareWidth;
            }

            for (int i = start; i < start + squareWidth; i++)
            {
                listToBeChecked.Add(cellValue[i]);
            }

            int nextRow = start + maxValue;
            for (int i = nextRow; i < nextRow + squareWidth; i++)
            {
                listToBeChecked.Add(cellValue[i]);
            }
        }

        public bool RowValid(int rowNumber)
        {
            SetRow(rowNumber);

            if (!CheckBlanks() || !CheckRange() || !CheckDuplicates())
            {
                return false;
            }
            return true;
        }

        public bool SquareValid(int squareNumber)
        {
            SetSquare(squareNumber);

            if (!CheckBlanks() || !CheckRange() || !CheckDuplicates())
            {
                return false;
            }
            return true;
        }

        public bool ColumnValid(int columnNumber)
        {

            SetColumn(columnNumber);

            if (!CheckBlanks() || !CheckRange() || !CheckDuplicates())
            {
                return false;
            }
            return true;
        }
    }

    interface IValidityChecker
    {
        bool RowValid(int rowNumber);
        bool ColumnValid(int columnNumber);
        bool SquareValid(int squareNumber);
        void SetRow(int rowNumber);
        void SetColumn(int columnNumber);
        void SetSquare(int squareNumber);
        bool CheckBlanks();
        List<int> GetListToBeChecked();
    }

    class Set : ISet
    {
        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            int squareSize = 4;
            int num = columnIndex + rowIndex * squareSize;
            Console.WriteLine(num);
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            // TODO
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            // TODO
        }
    }

    interface ISet
    {
        void SetByColumn(int value, int columnIndex, int rowIndex);
        void SetByRow(int value, int rowIndex, int columnIndex);
        void SetBySquare(int value, int squareIndex, int positionIndex);
    }

    interface IGet
    {
        int GetByColumn(int columnIndex, int rowIndex);
        int GetByRow(int rowIndex, int columnIndex);
        int GetBySquare(int squareIndex, int positionIndex);

    }

    interface IGame
    {
        void SetMaxValue(int maximum);
        int GetMaxValue();
        int[] ToArray();
        void Set(int[] cellValues);
        void SetSquareWidth(int squareWidth);
        void SetSquareHeight(int squareHeight);
        void Restart();
    }

    interface ISerialize
    {
        void FromCSV(string csv);
        string ToCSV();
        void SetCell(int value, int gridIndex);
        int GetCell(int gridIndex);
        string ToPrettyString();
    }
}
