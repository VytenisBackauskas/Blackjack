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

        public int CheckInitialGameState()
        {
            if(player.getCardSum() == 21 && dealer.getCardSum() == 21)
            {
                return 0;
            }
            else if (player.getCardSum() == 21)
            {
                return 1;
            }
            else if (dealer.getCardSum() == 21)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public int CheckGameState()
        {
            if (dealer.getCardSum() == player.getCardSum())
            {
                return 0;
            }
            else if (player.getCardSum() == 21 || (player.getCardSum() < 21 && dealer.getCardSum() > 21) || (player.getCardSum() < 21 && dealer.getCardSum() < 21 && player.getCardSum() > dealer.getCardSum()))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public void PrintGameStateMessage(int gameStateId)
        {
            switch (gameStateId)
            {
                case 0:
                    Console.WriteLine("Lygiosios");
                    break;
                case 1:
                    Console.WriteLine("Laimėjote");
                    break;
                case 2:
                    Console.WriteLine("Pralaimėjote");
                    break;
                default:
                    break;
            }
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
