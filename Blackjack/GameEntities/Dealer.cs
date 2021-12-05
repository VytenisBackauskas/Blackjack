using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer : GameEntity, Revealable
    {
        public Dealer() : base()
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Dalintojo kortos: ");
            cardDrawer.PrintAllCardsDrawings();
        }

        public override CardPack PickCard(CardPack cardPack, Random cardPicker)
        {
            this.cards.Add(cardPack.GetCards()[cardPicker.Next(0, cardPack.GetCards().Count)]);
            cardPack.GetCards().Remove(this.cards[this.cards.Count - 1]);
            CardSum += cardPack.GetCardValues()[this.cards[this.cards.Count - 1]];
            if(this.cards.Count == 2)
            {
                cardDrawer.CreateDrawingForBackSide();
            }
            else
            {
                cardDrawer.CreateDrawingForFrontSide(this.cards[this.cards.Count - 1]);
            }
            return cardPack;
        }

        public override bool CanPick()
        {
            if (CardSum < 17)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RevealHiddenCard()
        {
            cardDrawer.ChangeCardDrawing(1, this.cards[1]);
        }
    }
}
