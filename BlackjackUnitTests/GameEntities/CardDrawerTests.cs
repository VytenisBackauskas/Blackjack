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
    public class CardDrawerTests
    {
        [TestMethod()]
        public void CreateDrawingForFrontSideTest()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            char cardIdentifier = 'K';
            testCardDrawer.CreateDrawingForFrontSide(cardIdentifier);

            char result = testCardDrawer.GetCardDrawings().First()[1,1];

            Assert.AreEqual(cardIdentifier, result);
        }

        [TestMethod()]
        public void CreateDrawingForBackSideTest()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            testCardDrawer.CreateDrawingForBackSide();

            char result = testCardDrawer.GetCardDrawings().First()[1, 1];

            Assert.AreEqual('\u2593', result);
        }

        [TestMethod()]
        public void ChangeCardDrawingTest()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            char cardIdentifier = 'K';
            testCardDrawer.CreateDrawingForBackSide();
            testCardDrawer.ChangeCardDrawing(0, cardIdentifier);

            char result = testCardDrawer.GetCardDrawings().First()[1, 1];

            Assert.AreEqual(cardIdentifier, result);
        }
    }
}
