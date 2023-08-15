//using MooGame;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MooGameTest
//{
//    public class PlayBullsAndCowsGameTest
//    {
//        [Fact]
//        public void PlayBullsAndCows_ShouldReturnCorrectResult()
//        {
//            var uiMock = new Mock<IUI>();
//            var fileHandler = new Mock<IDataStorage>();
//            PlayerData playerData = new PlayerData("John", 0);
//            GameMoo game = new GameMoo(uiMock.Object, playerData);
//            string goal = "1234";
//            string bullsAndCows = "";
//            int numberOfGuesses = 0;
//            string allBulls = "BBBB";

//            uiMock.SetupSequence(ui => ui.GetUserInput())
//            .Returns("5678")
//            .Returns("1234");

//            // Act
//            string result = game.PlayBullsAndCowsGame(goal, ref numberOfGuesses, ref bullsAndCows, allBulls);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Matches(@"^\d{4}$", result);
//            uiMock.Verify(ui => ui.Print("Enter your guess:\n"), Times.Exactly(2));
//            uiMock.Verify(ui => ui.GetUserInput(), Times.Exactly(2));
//        }
//    }
//}
