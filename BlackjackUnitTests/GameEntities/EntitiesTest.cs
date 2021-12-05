using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Blackjack.Tests
{
    [TestClass()]
    public class EntitiesTest
    {
        [TestMethod()]
        public void CheckAceTest()
        {
            Mock<GameEntity> entityMock = new Mock<GameEntity>();
            entityMock.Setup(mock => mock.CountAceCards()).Returns(2);
            entityMock.SetupGet(mock => mock.CardSum).Returns(22);

            GameEntity entity = entityMock.Object;
            bool result = entity.CheckAce();

            Assert.AreEqual(true, result);
        }
    }
}