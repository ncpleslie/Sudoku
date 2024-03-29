﻿using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public partial class Game : IGame, ISet, IGet, ISerialize
    {
        public string OriginalGame { get; set; }
        public int[] CellValue { get; set; }
        public int SquareHeight { get; set; }
        public int SquareWidth { get; set; }
        public int MaxValue { get; set; }
        

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
            FromCSV(OriginalGame);
        }

        // Back/Forward(undo/redo) functionality
        private Stack<int[]> _previousTurns = new Stack<int[]>();
        private Stack<int[]> _redoTurns = new Stack<int[]>();

        private void StorePreviousTurn()
        {
            int[] array = new int[CellValue.Length];
            CellValue.CopyTo(array, 0);
            _previousTurns.Push(array);
        }

        public void GoBack()
        {
            int[] replacement = _previousTurns.Pop();
            replacement.CopyTo(CellValue, 0);
            _redoTurns.Push(replacement);
            CountTurnsUndo();
        }

        public void GoForward()
        {
            int[] replacement = _redoTurns.Pop();
            replacement.CopyTo(CellValue, 0);
            _previousTurns.Push(replacement);
            CountTurnsTaken();
        }

        // used to check a Row, Column, or Square,
        // and return any possible numbers that are missing from
        // the Row, Column, or Square

        // Range is 1 to the max possible number
        // If there are missing spaces then it will
        // return any possible number that is between 
        // 1 and the max number
        public List<int> ListPossibleValues()
        {
            return Enumerable.Range(1, MaxValue).Except(_listToBeChecked).ToList();
        }

        // A function to count how many more more you have left until you win
        // AKA count the blank spaces
        public int CountAllBlanksRemaining()
        {
           return CellValue.Count(i => i == 0);
        }

        // Count how many turns the play has made
        private int _countTurns = 0;
        public int CountTurnsTaken()
        {
            return _countTurns++;
        }

        public int CountTurnsUndo()
        {
            return _countTurns--;
        }
    }
}
