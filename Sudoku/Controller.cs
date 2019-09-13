using System.Collections.Generic;

namespace Sudoku
{
    class Controller
    {
        private readonly IView view;
        private readonly Game game;

        public Controller(IView view, Game game)
        {
            this.view = view;
            this.game = game;
        }
        public void Run()
        {
            game.SetMaxValue(9);
            game.SetSquareWidth(3);
            game.SetSquareHeight(3);

            // 4 x 4 
            string csv = "1,0,2,0,2,4,3,1,4,2,1,3,3,1,4,2";

            // 9 x 9
            csv = "0,3,5,6,1,4,8,9,2,8,4,2,9,7,3,5,6,1,9,6,1,2,8,5,3,7,4,2,8,6,3,4,9,1,5,7,4,1,3,8,5,7,9,2,6,5,7,9,1,2,6,4,3,8,1,5,7,4,9,2,6,8,3,6,9,4,7,3,8,2,1,5,3,2,8,5,6,1,7,4,0";
            game.FromCSV(csv);
            view.Show(game.ToPrettyString());
            //  game.GetBySquare(8, 1);
            List<int> listToCheck = game.GetByRow(8);


            //Timer timer = new Timer();
            //timer.Start();
            //view.Show("Timer Started");
            view.Show(game.CountAllBlanksRemaining());
            int[] changeCellValue = view.GetIntArray("Please enter a square, index, and new value");

            game.SetByRow(changeCellValue[2], changeCellValue[0], changeCellValue[1]);
             changeCellValue = view.GetIntArray("Please enter a square, index, and new value");

            game.SetByRow(changeCellValue[2], changeCellValue[0], changeCellValue[1]);

            view.Show(game.ToPrettyString());

            System.Console.WriteLine("Going Back");
            game.GoBack();
            game.GoBack();
            view.Show(game.ToPrettyString());
            System.Console.WriteLine("Going Forward");
            game.GoForward();
            game.GoForward();
            view.Show(game.ToPrettyString());
            //timer.Stop();
            //view.Show($"Final Game Time: {timer.GetTime()}");
        }
    }

}
