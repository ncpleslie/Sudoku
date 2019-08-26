﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static public int maxValue = 4;
        static public int squareWidth = 2;
        static public int squareHeight = 2;
        static public int[] cellValue = new int[]
        {
                1,0,2,0,
                2,4,3,1,
                4,2,1,3,
                3,1,4,3
        };

        static void Main(string[] args)
        {
            if (new ValidityChecker(maxValue, squareWidth, squareHeight, cellValue).SquareValid(4))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Not valid");
            }
        }
    }

    class ValidityChecker : IValidityChecker
    {
        private List<int> lineToBeChecked = new List<int> { };
        private readonly int maxValue;
        private readonly int squareWidth;
        private readonly int squareHeight;
        private readonly int[] cellValue;

        public ValidityChecker(int maxValue, int squareWidth, int squareHeight, int[] cellValue)
        {
            this.maxValue = maxValue;
            this.squareWidth = squareWidth;
            this.squareHeight = squareHeight;
            this.cellValue = cellValue;
        }

        public int RowPossibleValues(int rowNumber)
        {
            SetRow(rowNumber);
            // check numbers and return whats missing
            // if nums = 1, 2, 4
            // return 3

            return 1;
        }

        private bool CheckBlanks()
        {
            bool isValid = false;
            foreach (int num in lineToBeChecked)
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
            foreach (int num in lineToBeChecked)
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
            if (lineToBeChecked.Count == lineToBeChecked.Distinct().Count())
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

        private void SetRow(int rowNumber)
        {
            int rowStart = 0;
            if (rowNumber != 1)
            {
                rowStart = (rowNumber - 1) * maxValue;
            }

            for (int i = rowStart; i <= rowStart + maxValue - 1; i++)
            {
                lineToBeChecked.Add(cellValue[i]);
                Console.WriteLine(cellValue[i]);
            }
        }

        private void SetColumn(int columnNumber)
        {
            int columnStart = columnNumber - 1;
            int length = cellValue.Count();

            for (int i = columnStart; i <= length - 1; i += maxValue)
            {
                lineToBeChecked.Add(cellValue[i]);
                Console.WriteLine(cellValue[i]);
            }
        }
        
        private void SetSquare(int squareNumber)
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

                lineToBeChecked.Add(cellValue[i]);
                Console.WriteLine(cellValue[i]);
            }

            int nextRow = start + maxValue;
            for (int i = nextRow; i < nextRow + squareWidth; i++)
            {
                lineToBeChecked.Add(cellValue[i]);
                Console.WriteLine(cellValue[i]);
            }
        }

        public bool RowValid(int rowNumber)
        {
            bool isValid = false;
            SetRow(rowNumber);

            isValid = CheckBlanks();
            if (isValid == false)
            {
                return isValid;
            }
            isValid = CheckRange();
            if (isValid == false)
            {
                return isValid;
            }
            isValid = CheckDuplicates();
            if (isValid == false)
            {
                return isValid;
            }
            return isValid;
        }

        public bool SquareValid(int squareNumber)
        {
            bool isValid = false;

            SetSquare(squareNumber);

            isValid = CheckBlanks();
            if (isValid == false)
            {
                return isValid;
            }
            isValid = CheckRange();
            if (isValid == false)
            {
                return isValid;
            }
            isValid = CheckDuplicates();
            if (isValid == false)
            {
                return isValid;
            }
            return isValid;
        }

        public bool ColumnValid(int columnNumber)
        {
            bool isValid = false;

            SetColumn(columnNumber);

            isValid = CheckBlanks();
            if (isValid == false)
            {
                return isValid;
            }
            isValid = CheckRange();
            if (isValid == false)
            {
                return isValid;
            }
            isValid = CheckDuplicates();
            if (isValid == false)
            {
                return isValid;
            }
            return isValid;
        }
    }

    interface IValidityChecker
    {
        bool RowValid(int rowNumber);
        bool ColumnValid(int columnNumber);
        bool SquareValid(int squareNumber);
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
