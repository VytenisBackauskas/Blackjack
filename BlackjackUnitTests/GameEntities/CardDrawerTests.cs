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
            Card testCard1 = new Card('A', 'W');
            testCardDrawer.CreateDrawingForFrontSide(testCard);
            testCardDrawer.CreateDrawingForFrontSide(testCard1);

            char result = testCardDrawer.GetCardDrawings().First()[1,1];

            Assert.AreEqual(testCard.GetSymbol(), result);
        }

        [TestMethod()]
        public void CreateDrawingForBackSideTest()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            Card testCard = new Card('K', 'R');
            testCardDrawer.CreateDrawingForFrontSide(testCard);
            testCardDrawer.CreateDrawingForBackSide();

            char result = testCardDrawer.GetCardDrawings().Last()[1, 1];

            Assert.AreEqual('\u2593', result);
        }

        [TestMethod()]
        public void ChangeCardDrawingTest()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            Card testCard = new Card('K', 'R');
            testCardDrawer.CreateDrawingForFrontSide(testCard);
            testCardDrawer.CreateDrawingForBackSide();
            testCardDrawer.ChangeCardDrawing(1, testCard);

            char result = testCardDrawer.GetCardDrawings().Last()[1, 1];

            Assert.AreEqual(testCard.GetSymbol(), result);
        }

        [TestMethod()]
        public void CreateDrawingForFrontSideTest1()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            Card testCard = new Card('K', 'R');
            Card testCard1 = new Card('A', 'W');
            testCardDrawer.CreateDrawingForFrontSide(testCard);
            testCardDrawer.CreateDrawingForFrontSide(testCard1);

            char result = testCardDrawer.GetCardColors().First();

            Assert.AreEqual(testCard.GetColor(), result);
        }

        [TestMethod()]
        public void CreateDrawingForBackSideTest1()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            Card testCard = new Card('K', 'R');
            testCardDrawer.CreateDrawingForFrontSide(testCard);
            testCardDrawer.CreateDrawingForBackSide();

            char result = testCardDrawer.GetCardColors().Last();

            Assert.AreEqual('W', result);
        }

        [TestMethod()]
        public void ChangeCardDrawingTest1()
        {
            CardDrawer testCardDrawer = new CardDrawer();
            Card testCard = new Card('K', 'R');
            testCardDrawer.CreateDrawingForFrontSide(testCard);
            testCardDrawer.CreateDrawingForBackSide();
            testCardDrawer.ChangeCardDrawing(1, testCard);

            char result = testCardDrawer.GetCardColors().Last();

            Assert.AreEqual(testCard.GetColor(), result);
        }
    }
}
