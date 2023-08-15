using MooGame;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTest
{
    public class MakeGoalTest
    {
        private readonly GameMoo game;
        public MakeGoalTest()
        {
            var fileDataStorage = new Mock<IDataStorage>();
            var ui = new Mock<IUI>();
            PlayerData playerData = new PlayerData("Evgeny", 0);
            game = new GameMoo(ui.Object, playerData);
        }
        [Fact]
        public void MakeGoal_ShouldContainUniqueNumbers()
        {
            string number = game.MakeGoal();
            char[] digits = number.ToCharArray();
            List<char> seenDigits = new List<char>();
            bool isUnique = true;
            foreach (char digit in digits)
            {
                if (seenDigits.Contains(digit))
                {
                    isUnique = false; break;
                }
                seenDigits.Add(digit);
            }

            Assert.True(isUnique);
        }

        [Fact]
        public void MakeGoal_ShouldReturnFourDigitNumber()
        {
            string number = game.MakeGoal();
            
            Assert.Equal(number.Length, 4);
        }
    }
}
