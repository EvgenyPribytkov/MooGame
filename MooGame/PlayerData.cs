using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public class PlayerData
    {
        public string Name { get; private set; }
        public int NumberOfGames { get; private set; }
        public int _totalGuess { get; private set; }

        public PlayerData(string name, int totalGuess)
        {
            this.Name = name;
            NumberOfGames = 1;
            _totalGuess = totalGuess;
        }

        public void Update(int guesses)
        {
            _totalGuess += guesses;
            NumberOfGames++;
        }

        public double Average()
        {
            return (double)_totalGuess / NumberOfGames;
        }


        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
