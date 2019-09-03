using System;

namespace Sudoku
{
    public class ConsoleView : IView
    {
        public void Show<T>(T message)
        {
            Console.WriteLine(message);
        }

        public int GetInt(string prompt)
        {
            Console.WriteLine(prompt);
            return int.Parse(Console.ReadLine());
        }

        public string GetString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
