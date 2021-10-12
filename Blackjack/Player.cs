using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        private List<char> cards;
        int cardSum;
        int aceUses;

        public Player()
        {
            this.cards = new List<char>();
            this.cardSum = 0;
            this.aceUses = 0;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Žaidėjo kortos: ");
            foreach (char card in this.cards)
            {
                Console.Write("{0} ", card);
            }
            Console.WriteLine("- {0}", this.cardSum);
        }

        public CardPack DrawCard(CardPack cardPack, Random cardPicker)
        {
            this.cards.Add(cardPack.GetCards()[cardPicker.Next(0, cardPack.GetCards().Count)]);
            cardPack.GetCards().Remove(this.cards[this.cards.Count - 1]);
            this.cardSum += cardPack.GetCardValues()[this.cards[this.cards.Count - 1]];
            return cardPack;
        }

        public bool CheckAce()
        {
            if (cardSum <= 21)
            {
                return false;
            }
            int aceCards = 0;
            foreach (char card in this.cards)
            {
                if (card == 'A')
                {
                    aceCards++;
                }
            }
            if (aceCards > aceUses)
            {
                this.cardSum -= 10;
                aceUses++;
                return true;
            }
            return false;
        }

        public bool CheckBlackjack()
        {
            if(cardSum == 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanDraw()
        {
            if(cardSum < 21)
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

        public void DrawAce()
        {
            this.cards.Add('A');
            this.cardSum += 11;
        }
    }
}
