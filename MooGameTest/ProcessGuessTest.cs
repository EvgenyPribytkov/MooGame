//using MooGame;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MooGameTest
//{
//    public class ProcessGuessTest
//    {
//        [InlineData("1234", "123A", "BBBB")]
//        [InlineData("9345", "AAAA", "BBB")]
//        [InlineData("4537", "*-*/**", "CCCC")]
//        [Theory]
//        public void ProcessGuess_InvalidGuess_PrintsErrorMessage(string goal, string guess, string bullsAndCows)
//        {
//            // Arrange
//            var uiMock = new Mock<IUI>();
//            var fileHandler = new Mock<IDataStorage>();
//            PlayerData playerData = new PlayerData("John", 0);
//            GameMoo game = new GameMoo(uiMock.Object, playerData);

//            string expected = "Invalid guess. Please try again.\n";

//            // Assert
//            uiMock.Verify(ui => ui.Print(expected));
//        }
//    }
//}
