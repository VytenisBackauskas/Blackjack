using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class CardPack
    {
        private List<char> cards;
        private Dictionary<char, int> cardValues;

        public CardPack(int deckCount)
        {
            if(deckCount <= 0)
            {
                deckCount = 1;
            }
            List<char> cardDeck = new List<char>
            {
                '2', '2', '2', '2',
                '3', '3', '3', '3',
                '4', '4', '4', '4',
                '5', '5', '5', '5',
                '6', '6', '6', '6',
                '7', '7', '7', '7',
                '8', '8', '8', '8',
                '9', '9', '9', '9',
                'T', 'T', 'T', 'T',
                'J', 'J', 'J', 'J',
                'Q', 'Q', 'Q', 'Q',
                'K', 'K', 'K', 'K',
                'A', 'A', 'A', 'A'
            };
            this.cards = new List<char>();
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

        public List<char> GetCards()
        {
            return this.cards;
        }

        public Dictionary<char, int> GetCardValues()
        {
            return this.cardValues;
        }
    }
}
