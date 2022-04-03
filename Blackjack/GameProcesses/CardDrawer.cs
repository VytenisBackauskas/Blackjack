using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class CardDrawer
    {
        private List<char[,]> cardDrawings;
        public CardDrawer()
        {
            this.cardDrawings = new List<char[,]>();
        }

        public void CreateDrawingForFrontSide(char cardIdentifier)
        {
            char[,] cardDrawing =
            {
                {'\u250c', '\u2500', '\u2500', '\u2500', '\u2510'},
                {'\u2502', cardIdentifier, ' ', ' ', '\u2502'},
                {'\u2502', ' ', ' ', ' ', '\u2502'},
                {'\u2502', ' ', ' ',  cardIdentifier, '\u2502'},
                {'\u2514', '\u2500', '\u2500', '\u2500', '\u2518'}
            };
            cardDrawings.Add(cardDrawing);
        }

        public void CreateDrawingForBackSide()
        {
            char[,] cardDrawing =
            {
                {'\u250c', '\u2500', '\u2500', '\u2500', '\u2510'},
                {'\u2502', '\u2593', '\u2593', '\u2593', '\u2502'},
                {'\u2502', '\u2593', '\u2593', '\u2593', '\u2502'},
                {'\u2502', '\u2593', '\u2593', '\u2593', '\u2502'},
                {'\u2514', '\u2500', '\u2500', '\u2500', '\u2518'}
            };
            cardDrawings.Add(cardDrawing);
        }

        public void PrintAllCardsDrawings()
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < cardDrawings.Count; j++)
                {
                    for(int k = 0; k < 5; k++)
                    {
                        Console.Write(cardDrawings[j][i,k]);
                    }
                }
                Console.Write("\n");
            }

        }

        public void ChangeCardDrawing(int index, char cardIdentifier)
        {
            char[,] cardDrawing =
            {
                {'\u250c', '\u2500', '\u2500', '\u2500', '\u2510'},
                {'\u2502', cardIdentifier, ' ', ' ', '\u2502'},
                {'\u2502', ' ', ' ', ' ', '\u2502'},
                {'\u2502', ' ', ' ',  cardIdentifier, '\u2502'},
                {'\u2514', '\u2500', '\u2500', '\u2500', '\u2518'}
            };
            this.cardDrawings[index] = cardDrawing;
        }
    }
}
