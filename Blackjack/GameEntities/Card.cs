using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.GameEntities
{
    public class Card
    {
        private char symbol;
        private char color;

        public Card(char symbol, char color)
        {
            this.symbol = symbol;
            this.color = color;
        }

        public char getSymbol()
        {
            return this.symbol;
        }

        public char getColor()
        {
            return this.color;
        }
    }
}
