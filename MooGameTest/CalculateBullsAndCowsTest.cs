using MooGame;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTest
{
    public class CalculateBullsAndCowsTest
    {
        [InlineData("1234", "1234", "BBBB")]
        [InlineData("9345", "9346", "BBB")]
        [InlineData("4537", "5374", "CCCC")]
        [InlineData("5374", "5374ab", "BBBB")]
        [InlineData("5374", "5347", "BB,CC")]
        [Theory]
        public void CalculateBullsAndCows_ShouldReturnCorrectResult(string goal, string guess, string expected)
        {
            var uiMock = new Mock<IUI>();
            var fileHandler = new Mock<IDataStorage>();
            PlayerData playerData = new PlayerData("Evgeny", 0);
            GameMoo game = new GameMoo(uiMock.Object, playerData);
            GameController gc = new GameController(fileHandler.Object, uiMock.Object);

            var actual = game.CalculateBullsAndCows(goal, guess);
            Assert.Equal(expected, actual);
        }
    }
}
