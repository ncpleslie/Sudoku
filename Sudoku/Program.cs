using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System;

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
            List<int> listToCheck = game.GetByRow(1);

            Timer timer = new Timer();
            timer.Start();
            view.Show("Timer Started");

            int[] changeCellValue = view.GetIntArray("Please enter a row, column, and new value");
            while (changeCellValue[0] != -1)
            {
                game.SetByRow(changeCellValue[2], changeCellValue[0], changeCellValue[1]);
                view.Show(game.ToPrettyString());
                changeCellValue = view.GetIntArray("Please enter a row, column, and new value");
            }

            timer.Stop();
            view.Show($"Final Game Time: {timer.GetTime()}");


        }
    }

    class Timer
    {
        private DateTime _startTime = new DateTime();
        private DateTime _stopTime = new DateTime();
        private TimeSpan _time = new TimeSpan();
        private bool _running;

        public void Start()
        {
            if (_running)
                throw new InvalidOperationException("Stopwatch is already running");

            _startTime = DateTime.Now;
            _running = true;
        }

        public void Stop()
        {
            if (!_running)
                throw new InvalidOperationException("Stopwatch is not running");

            _stopTime = DateTime.Now;
            _running = false;
        }

        private void CalcTime()
        {
            if (_stopTime == DateTime.MinValue || _startTime == DateTime.MinValue)
                throw new InvalidOperationException("Stopwatch time failed to record");

            _time = _stopTime - _startTime;
        }

        private void ResetTime()
        {
            _stopTime = new DateTime();
            _startTime = new DateTime();
        }

        public string GetTime()
        {
            CalcTime();
            ResetTime();
            return _time.ToString();
        }
    }
}
