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
    public class CardPackTest
    {
        [TestMethod()]
        public void GetCardsTest()
        {
            CardPack testCardPack = new CardPack(2);
            int result = testCardPack.GetCards().Count;

            Assert.AreEqual(104, result);
        }

        [TestMethod()]
        public void GetCardsTest1()
        {
            CardPack testCardPack = new CardPack(-10);
            int result = testCardPack.GetCards().Count;

            Assert.AreEqual(52, result);
        }

        [TestMethod()]
        public void GetCardValuesTest()
        {
            CardPack testCardPack = new CardPack(1);
            int result = testCardPack.GetCardValues().Count;

            Assert.AreEqual(13, result);
        }
    }
}