using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    // This class is used check if a Row, Column, or Square are valid
    class ValidityChecker : IValidityChecker
    {
        private List<int> listToBeChecked;
        private readonly int maxValue;
        private readonly int squareWidth;
        private readonly int squareHeight;
        private readonly int[] cellValue;
        private readonly IGame game;

        public ValidityChecker(IGame game, List<int> listToBeChecked)
        {
            this.listToBeChecked = listToBeChecked;
            this.game = game;
            maxValue = game.GetMaxValue();
            squareWidth = 2;
            squareHeight = 2;
            cellValue = new int[] {1,0,2,0,2,4,3,1,4,2,1,3,3,1,4,2};
        }

        public List<int> GetListToBeChecked()
        {
            return listToBeChecked;
        }

        // Checks if 0 exists. 0 = blank values
        private bool CheckBlanks()
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

        // Checks if within 0 and max possible number
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

        // Checks if number is in the list more than once
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

        // CheckBlanks, CheckRange, CheckDuplicates is use to check
        // the list generated from Row, Column, or Square
        public bool ListValid()
        {
            if (!CheckBlanks() || !CheckRange() || !CheckDuplicates())
            {
                return false;
            }
            return true;
        }
    }
}
