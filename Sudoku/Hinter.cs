using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    // This class is used to check a Row, Column, or Square,
    // and return any possible numbers that are missing from
    // the Row, Column, or Square
    public class Hinter : IHinter
    {
        private readonly Game _game;
        private readonly List<int> _listToBeChecked;
        public Hinter(List<int> listToBeChecked, Game game)
        {
            _game = game;
            _listToBeChecked = listToBeChecked;
        }

        // Range is 1 to the max possible number
        // If there are missing spaces then it will
        // return any possible number that is between 
        // 1 and the max number
        public List<int> ListPossibleValues()
        {
            List<int> missingNums = new List<int> { };
            IEnumerable<int> range = Enumerable.Range(start: 1, count: _game.MaxValue);

            missingNums = range.Except(_listToBeChecked).ToList();

            return missingNums;
        }
    }
}
