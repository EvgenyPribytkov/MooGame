using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public class GameController
    {
        private readonly IDataStorage fileHandler;
        private readonly IUI ui = new ConsoleUI();
        private PlayerData playerData;
        private readonly IGame game;

        public GameController(IDataStorage fileHandler, IUI ui)
        {
            this.fileHandler = fileHandler;
            this.ui = ui;
            PlayerData playerData = new PlayerData("", 0);
            game = new GameMoo(ui, playerData);
        }

        public string GetUsername()
        {
            string username;
            do
            {
                ui.Print("Enter your user name:\n");
                username = ui.GetUserInput();
                if (String.IsNullOrEmpty(username))
                {
                    ui.Print("Invalid user name. Please try again.\n");
                }
            }
            while (String.IsNullOrEmpty(username));
            return username;
        }

        private void WriteResultToFile(PlayerData playerData)
        {
            fileHandler.SavePlayerScore("TopScores.txt", playerData);
        }

        public void Play()
        {
            string username = GetUsername();
            int numberOfGuesses = game.Play();
            playerData = new PlayerData(username, numberOfGuesses);
            WriteResultToFile(playerData);
            showTopList();
        }

        public void showTopList()
        {
            List<PlayerData> results = new List<PlayerData>();

            string fileContent = fileHandler.GetHighScore();

            string[] lines = fileContent.Split(Environment.NewLine);
            UpdatePlayerData(results, lines);

            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            ui.Print("Player games average");
            foreach (PlayerData p in results)
            {
                ui.Print(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
            }
        }

        private static void UpdatePlayerData(List<PlayerData> results, string[] lines)
        {
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string line = lines[i];
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }
            }
        }
    }
}
