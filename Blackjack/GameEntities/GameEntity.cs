using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    abstract class GameEntity
    {
        protected CardDrawer cardDrawer;
        protected List<char> cards;
        protected int cardSum;
        protected int aceUses;

        public GameEntity()
        {
            this.cardDrawer = new CardDrawer();
            this.cards = new List<char>();
            this.cardSum = 0;
            this.aceUses = 0;
        }

        public virtual void PrintInfo()
        {
            cardDrawer.PrintAllCardsDrawings();
        }

        public virtual CardPack PickCard(CardPack cardPack, Random cardPicker)
        {
            this.cards.Add(cardPack.GetCards()[cardPicker.Next(0, cardPack.GetCards().Count)]);
            cardPack.GetCards().Remove(this.cards[this.cards.Count - 1]);
            this.cardSum += cardPack.GetCardValues()[this.cards[this.cards.Count - 1]];
            cardDrawer.CreateDrawingForFrontSide(this.cards[this.cards.Count - 1]);
            return cardPack;
        }

        public bool CheckAce()
        {
            if (CountAceCards() > aceUses && cardSum > 21)
            {
                this.cardSum -= 10;
                aceUses++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckBlackjack()
        {
            if (cardSum == 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool CanPick()
        {
            if (cardSum < 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getCardSum()
        {
            return this.cardSum;
        }

        private int CountAceCards()
        {
            int aceCards = 0;
            foreach (char card in this.cards)
            {
                if (card == 'A')
                {
                    aceCards++;
                }
            }
            return aceCards;
        }
    }
}
