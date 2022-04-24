using Blackjack.GameEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class CardPack
    {
        private List<Card> cards;
        private Dictionary<char, int> cardValues;

        public CardPack(int deckCount)
        {
            if(deckCount <= 0)
            {
                deckCount = 1;
            }
            List<Card> cardDeck = new List<Card>
            {
                new Card('2', 'W'), new Card('2', 'W'), new Card('2', 'R'), new Card('2', 'R'),
                new Card('3', 'W'), new Card('3', 'W'), new Card('3', 'R'), new Card('3', 'R'),
                new Card('4', 'W'), new Card('4', 'W'), new Card('4', 'R'), new Card('4', 'R'),
                new Card('5', 'W'), new Card('5', 'W'), new Card('5', 'R'), new Card('5', 'R'),
                new Card('6', 'W'), new Card('6', 'W'), new Card('6', 'R'), new Card('6', 'R'),
                new Card('7', 'W'), new Card('7', 'W'), new Card('7', 'R'), new Card('7', 'R'),
                new Card('8', 'W'), new Card('8', 'W'), new Card('8', 'R'), new Card('8', 'R'),
                new Card('9', 'W'), new Card('9', 'W'), new Card('9', 'R'), new Card('9', 'R'),
                new Card('T', 'W'), new Card('T', 'W'), new Card('T', 'R'), new Card('T', 'R'),
                new Card('J', 'W'), new Card('J', 'W'), new Card('J', 'R'), new Card('J', 'R'),
                new Card('Q', 'W'), new Card('Q', 'W'), new Card('Q', 'R'), new Card('Q', 'R'),
                new Card('K', 'W'), new Card('K', 'W'), new Card('K', 'R'), new Card('K', 'R'),
                new Card('A', 'W'), new Card('A', 'W'), new Card('A', 'R'), new Card('A', 'R'),
            };
            this.cards = new List<Card>();
            for(int i = 0; i < deckCount; i++)
            {
                cards.AddRange(cardDeck);
            }
            this.cardValues = new Dictionary<char, int>
            {
                {'2', 2 },
                {'3', 3 },
                {'4', 4 },
                {'5', 5 },
                {'6', 6 },
                {'7', 7 },
                {'8', 8 },
                {'9', 9 },
                {'T', 10 },
                {'J', 10 },
                {'Q', 10 },
                {'K', 10 },
                {'A', 11 }
            };
        }

        public List<Card> GetCards()
        {
            return this.cards;
        }

        public Dictionary<char, int> GetCardValues()
        {
            return this.cardValues;
        }
    }
}
