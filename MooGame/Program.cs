using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            IDataStorage fileDataStorage = new FileDataStorage("result.txt");
            IUI ui = new ConsoleUI();
            
            GameController gameController = new GameController(fileDataStorage, ui);
            gameController.Play();
        }
    }
}