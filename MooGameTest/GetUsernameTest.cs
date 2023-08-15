//using MooGame;
//using Moq;

//namespace MooGameTest
//{
//    ////[TestClass]
//    public class GetUsernameTest
//    {

//        //private Mock<IDataStorage>() _mockHandler;
//        //[TestInitialize]
//        //public void CreateDependencies()
//        //{
//        //    mockHandler
//        //}

//        [Fact]
//        //[DataTestMethod]
//        //[DataRow()]
//        public void GetUsernameTest_ShouldHandleEmptyUserInput()
//        {
//            var uiMock = new Mock<IUI>();
//            var fileHandler = new Mock<IDataStorage>();
//            PlayerData playerData = new PlayerData("Evgeny", 0);
//            GameMoo game = new GameMoo(uiMock.Object, playerData);
//            GameController gc = new GameController(fileHandler.Object, uiMock.Object);

//            uiMock.SetupSequence(ui => ui.GetUserInput())
//            .Returns("").
//            Returns("Evgeny");

//            string actualUserName = gc.GetUsername();
//            string expectedUserName = "Evgeny";

//            uiMock.Verify(ui => ui.Print("Enter your user name:\n"), Times.Exactly(2)); // Verify the prompt is printed twice
//            uiMock.Verify(ui => ui.Print("Invalid user name. Please try again.\n"), Times.Once); // Verify the error message is printed once
//            Assert.Equal(expectedUserName, actualUserName); // Verify that the valid username is returned
//        }
//    }
//}