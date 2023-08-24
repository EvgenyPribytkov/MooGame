using MooGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MooGame
{
    public class GameMoo : IGame
    {
        private readonly IUI ui = new ConsoleUI();
        private readonly PlayerData playerData;

        public GameMoo(IUI ui, PlayerData playerData)
        {
            this.ui = ui;
            this.playerData = playerData;
        }

        public int Play()
        {
            bool playOn = true;
            int numberOfGuesses = 0;


            while (playOn) 
            {
                numberOfGuesses += PlayOneRound(ref playOn);
            }
                return numberOfGuesses;
        }

        private int PlayOneRound(ref bool playOn)
        {
            string goal = MakeGoal();
            PrintNewGameMessage(goal);

            string guess;
            int numberOfGuesses = 0;
            string bullsAndCows = "";
            string allBulls = "BBBB";
            guess = PlayBullsAndCowsGame(goal, ref numberOfGuesses, ref bullsAndCows, allBulls);

            PrintNumberOfGuesses(numberOfGuesses);
            PromptContinue();
            string? answer = ui.GetUserInput();
            playOn = CheckAndSetPlayOnStatus(playOn, answer);
            return numberOfGuesses;
        }

        private static bool CheckAndSetPlayOnStatus(bool playOn, string answer)
        {
            if (ValidateAnswer(answer))
            {
                playOn = false;
            }

            return playOn;
        }

        private static bool ValidateAnswer(string answer)
        {
            return answer != null && answer != "" && answer.Substring(0, 1) == "n";
        }

        private void PromptContinue()
        {
            ui.Print("Continue? (y/n)");
        }

        private void PrintNumberOfGuesses(int numberOfGuesses)
        {
            ui.Print("Correct, it took " + numberOfGuesses + " guesses\n");
        }


        public string PlayBullsAndCowsGame(string goal, ref int numberOfGuesses, ref string bullsAndCows, string allBulls)
        {
            string guess;
            do
            {
                numberOfGuesses++;
                EnterGuess();
                guess = ui.GetUserInput();
                bullsAndCows = ProcessGuess(goal, bullsAndCows, guess);
            }
            while ((bullsAndCows != allBulls) || (String.IsNullOrEmpty(guess) || !Regex.IsMatch(guess, @"^\d{4}$")));
            return guess;
        }

        private void EnterGuess()
        {
            ui.Print("Enter your guess:\n");
        }

        public string ProcessGuess(string goal, string bullsAndCows, string guess)
        {
            if (ValidateGuess(guess))
            {
                ui.Print("Invalid guess. Please try again.\n");
            }
            else
            {
                bullsAndCows = CalculateBullsAndCows(goal, guess);
                ui.Print(bullsAndCows + "\n" + "Try again" + "\n");
            }

            return bullsAndCows;
        }

        private static bool ValidateGuess(string guess)
        {
            return String.IsNullOrEmpty(guess) || !Regex.IsMatch(guess, @"^\d{4}$");
        }

        private void PrintNewGameMessage(string goal)
        {
            ui.Print("New game:\n");
            //comment out or remove next line to play real games!
            ui.Print("For practice, number is: " + goal + "\n");
        }

        public string MakeGoal()
        {
            Random randomGenerator = new Random();
            List<int> uniqueNumbers = new List<int>();
            while (uniqueNumbers.Count < 4)
            {
                int randomNumber = randomGenerator.Next(0, 10);
                if (!uniqueNumbers.Contains(randomNumber))
                {
                    uniqueNumbers.Add(randomNumber);
                }
            }

            string goal = string.Concat(uniqueNumbers);
            return goal;
        }

        public string CalculateBullsAndCows(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            if (bulls <= 0)
            {
                return new string('C', cows);
            }
            else if (cows <= 0)
            {
                return new string('B', bulls);
            }
            else
            {
                return new string('B', bulls) + "," + new string('C', cows);
            }
        }
    }
}
