using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BlackjackGameState;

namespace Blackjack.Tests
{
    [TestClass()]
    public class GameHandlerTests
    {
        [TestMethod()]
        public void CheckGameStateTest()
        {
            Mock<Dealer> dealerMock = new Mock<Dealer>();
            dealerMock.SetupGet(mock => mock.CardSum).Returns(18);
            Mock<Player> playerMock = new Mock<Player>();
            playerMock.SetupGet(mock => mock.CardSum).Returns(19);

            Dealer dealer = dealerMock.Object;
            Player player = playerMock.Object;
            GameHandler handler = new GameHandler(player, dealer);
            GameState state = handler.CheckGameState();

            Assert.AreEqual(GameState.Win, state);
        }

        [TestMethod()]
        public void CheckGameStateTest1()
        {
            Mock<Dealer> dealerMock = new Mock<Dealer>();
            dealerMock.SetupGet(mock => mock.CardSum).Returns(14);
            Mock<Player> playerMock = new Mock<Player>();
            playerMock.SetupGet(mock => mock.CardSum).Returns(22);

            Dealer dealer = dealerMock.Object;
            Player player = playerMock.Object;
            GameHandler handler = new GameHandler(player, dealer);
            GameState state = handler.CheckGameState();

            Assert.AreEqual(GameState.Lose, state);
        }

        [TestMethod()]
        public void CheckInitialGameStateTest()
        {
            Mock<Dealer> dealerMock = new Mock<Dealer>();
            dealerMock.Setup(mock => mock.CheckBlackjack()).Returns(true);
            Mock<Player> playerMock = new Mock<Player>();
            playerMock.Setup(mock => mock.CheckBlackjack()).Returns(true);

            Dealer dealer = dealerMock.Object;
            Player player = playerMock.Object;
            GameHandler handler = new GameHandler(player, dealer);
            GameState state = handler.CheckInitialGameState();

            Assert.AreEqual(GameState.Tie, state);
        }
    }
}