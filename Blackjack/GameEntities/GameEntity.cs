using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public abstract class GameEntity
    {
        protected CardDrawer cardDrawer;
        protected List<char> cards;
        protected int aceUses;
        public virtual int CardSum { get; set; }

        public GameEntity()
        {
            this.cardDrawer = new CardDrawer();
            this.cards = new List<char>();
            this.CardSum = 0;
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
            CardSum += cardPack.GetCardValues()[this.cards[this.cards.Count - 1]];
            cardDrawer.CreateDrawingForFrontSide(this.cards[this.cards.Count - 1]);
            return cardPack;
        }

        public bool CheckAce()
        {
            if (CountAceCards() > aceUses && CardSum > 21)
            {
                CardSum -= 10;
                aceUses++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckBlackjack()
        {
            if (CardSum == 21)
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
            if (CardSum < 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual int CountAceCards()
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
