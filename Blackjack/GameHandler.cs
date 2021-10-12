using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class GameHandler
    {
        private CardPack cardPack;
        private Random cardPicker;

        private Player player;
        private Dealer dealer;

        public GameHandler()
        {
            this.cardPack = new CardPack(2);
            this.cardPicker = new Random();
            this.player = new Player();
            this.dealer = new Dealer();
        }

        public void PrintInfo(string user)
        {
            if(user == "player")
            {
                player.PrintInfo();
            }
            else if(user == "dealer")
            {
                dealer.PrintInfo();
            }
        }

        public void DrawCard(string user)
        {
            if (user == "player")
            {
                cardPack = player.DrawCard(cardPack, cardPicker);
            }
            else if (user == "dealer")
            {
                cardPack = dealer.DrawCard(cardPack, cardPicker);
            }
        }

        public void CheckAce()
        {
            player.CheckAce();
            dealer.CheckAce();
        }

        public int CheckBlackjack()
        {
            if(player.CheckBlackjack() && dealer.CheckBlackjack())
            {
                Tie();
                return 1;
            }
            else if (player.CheckBlackjack())
            {
                Win();
                return 2;
            }
            else if (dealer.CheckBlackjack())
            {
                Lose();
                return 3;
            }
            return 0;
        }

        public int CheckGameState()
        {
            int blackjackState = CheckBlackjack();
            if (dealer.getCardSum() == player.getCardSum())
            {
                Tie();
                return 1;
            }
            else if (blackjackState == 2 || (player.getCardSum() <= 21 && player.getCardSum() > dealer.getCardSum()) || player.getCardSum() <= 21 && dealer.getCardSum() > 21)
            {
                Win();
                return 2;
            }
            else
            {
                Lose();
                return 0;
            }
        }

        public void Win()
        {
            Console.WriteLine("Laimėjote");
        }

        public void Lose()
        {
            Console.WriteLine("Pralaimėjote");
        }

        public void Tie()
        {
            Console.WriteLine("Lygiosios");
        }

        public bool CanDraw(string user)
        {
            if (user == "player")
            {
                return player.CanDraw();
            }
            else if (user == "dealer")
            {
                return dealer.CanDraw();
            }
            else
            {
                return false;
            }
        }
    }
}
