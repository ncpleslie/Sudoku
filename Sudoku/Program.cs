using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            new Controller(new ConsoleView(), new Game()).Run();
        }
    }

    class Controller
    {
        private readonly IView view;
        private readonly IGame game;

        public Controller(IView view, IGame game)
        {
            this.view = view;
            this.game = game;
        }
        public void Run()
        {
            game.SetMaxValue(view.GetInt("Enter the max possible number: 4"));
            game.SetSquareWidth(view.GetInt("Enter the width: 2"));
            game.SetSquareHeight(view.GetInt("Enter the height: 2"));

            // Will be used for user input string
            // User will be able to set the game values here
            view.GetInt("Enter cell values");
            int[] cellValue = new int[]
            {
                1,0,2,0,
                2,4,3,1,
                4,2,1,3,
                3,1,4,2
            };
            game.Set(cellValue);
            
            IGet get = new Get(game);
            List<int> listToCheck = get.GetByRow(view.GetInt("Which row would you like to check?"));
            bool validityCheckerStatus = new ValidityChecker(game, listToCheck).ListValid();

            if (validityCheckerStatus)
            {
                view.Show("Check Passed");
            }
            else
            {
                view.Show("Check Failed");
            }
        }
    }

    // Used to set the value of an empty spot to the user inputed value
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

    interface ISerialize
    {
        void FromCSV(string csv);
        string ToCSV();
        void SetCell(int value, int gridIndex);
        int GetCell(int gridIndex);
        string ToPrettyString();
    }
}
