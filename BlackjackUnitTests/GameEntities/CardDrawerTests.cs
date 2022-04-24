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
    public class CardDrawerTests
    {
        [TestMethod()]
        public void CreateDrawingForFrontSideTest()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            Card testCard = new Card('K', 'R');
            testCardDrawer.CreateDrawingForFrontSide(testCard);

            char result = testCardDrawer.GetCardDrawings().First()[1,1];

            Assert.AreEqual(testCard.getSymbol(), result);
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
            Card testCard = new Card('K', 'R');
            testCardDrawer.CreateDrawingForBackSide();
            testCardDrawer.ChangeCardDrawing(0, testCard);

            char result = testCardDrawer.GetCardDrawings().First()[1, 1];

            Assert.AreEqual(testCard.getSymbol(), result);
        }
    }
}
