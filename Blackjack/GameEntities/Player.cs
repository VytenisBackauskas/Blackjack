using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player : GameEntity
    {
        public Player() : base()
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine("Žaidėjo kortos: ");
            cardDrawer.PrintAllCardsDrawings();
            Console.WriteLine("Žaidėjo suma: {0}", CardSum);
        }
    }
}
