using System.Collections.Generic;
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
        private readonly Game game;

        public Controller(IView view, Game game)
        {
            this.view = view;
            this.game = game;
        }
        public void Run()
        {
            game.SetMaxValue(4);
            game.SetSquareWidth(2);
            game.SetSquareHeight(2);

            string csv = "1,0,2,0,2,4,3,1,4,2,1,3,3,1,4,2";
            game.FromCSV(csv);
            view.Show(game.ToPrettyString());
            
            while (true)
            {
                int[] changeCellValue = view.GetIntArray("Please enter a row, column, and new value");
                game.SetByRow(changeCellValue[2], changeCellValue[0], changeCellValue[1]);
                view.Show(game.ToPrettyString());
            }
        }
    }
}
