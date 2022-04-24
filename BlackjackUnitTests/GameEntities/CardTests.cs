using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Blackjack.GameEntities;

namespace Blackjack.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void GetSymbolTest()
        {
            Card testCard = new Card('K', 'R');

            char result = testCard.GetSymbol();

            Assert.AreEqual('K', result);
        }

        [TestMethod()]
        public void GetColorTest()
        {
            Card testCard = new Card('K', 'R');

            char result = testCard.GetColor();

            Assert.AreEqual('R', result);
        }
    }
}
