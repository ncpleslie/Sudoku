using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Sudoku
{

    class Program
    {
        static void Main(string[] args)
        {
            new Controller(new ConsoleView(), new Game()).Run();
        }
    }
}
