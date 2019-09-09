using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Clear()
        {
            Console.Clear();
        }

        public void ShowList<T>(List<int> list)
        {
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }

        public int[] GetIntArray(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        }
    }
}
