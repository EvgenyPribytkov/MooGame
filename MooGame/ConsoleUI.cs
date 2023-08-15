using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public class ConsoleUI : IUI
    {
        public string GetUserInput()
        {
            return Console.ReadLine()?.Trim() ?? String.Empty;
        }

        public void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
