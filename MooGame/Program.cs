using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            IDataStorage fileDataStorage = new FileDataStorage("HighScores.txt");
            IUI ui = new ConsoleUI();
            
            GameController gameController = new GameController(fileDataStorage, ui);
            gameController.Play();
            //string username = gameController.GetUsername();
            //PlayerData playerData = new PlayerData(username, 0);
            //GameMoo mooGame = new GameMoo(ui, playerData);
            //mooGame.Play();
        }
    }
}