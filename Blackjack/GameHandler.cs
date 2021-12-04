﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackjackGameState;

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

        public void PrintInfo()
        {
            dealer.PrintInfo();
            player.PrintInfo();
        }

        public void DrawCard(string user)
        {
            if (user == "player")
            {
                cardPack = player.PickCard(cardPack, cardPicker);
            }
            else if (user == "dealer")
            {
                cardPack = dealer.PickCard(cardPack, cardPicker);
            }
        }

        public void CheckAce()
        {
            player.CheckAce();
            dealer.CheckAce();
        }

        public GameState CheckInitialGameState()
        {
            if(player.getCardSum() == 21 && dealer.getCardSum() == 21)
            {
                return GameState.Tie;
            }
            else if (player.getCardSum() == 21)
            {
                return GameState.Win;
            }
            else if (dealer.getCardSum() == 21)
            {
                return GameState.Lose;
            }
            else
            {
                return GameState.Continue;
            }
        }

        public GameState CheckGameState()
        {
            if (dealer.getCardSum() == player.getCardSum())
            {
                return GameState.Tie;
            }
            else if (player.getCardSum() == 21 || (player.getCardSum() < 21 && dealer.getCardSum() > 21) || (player.getCardSum() < 21 && dealer.getCardSum() < 21 && player.getCardSum() > dealer.getCardSum()))
            {
                return GameState.Win;
            }
            else
            {
                return GameState.Lose;
            }
        }

        public void PrintGameStateMessage(GameState currentGameState)
        {
            switch (currentGameState)
            {
                case GameState.Tie:
                    Console.WriteLine("Lygiosios");
                    break;
                case GameState.Win:
                    Console.WriteLine("Laimėjote");
                    break;
                case GameState.Lose:
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
                return player.CanPick();
            }
            else if (user == "dealer")
            {
                return dealer.CanPick();
            }
            else
            {
                return false;
            }
        }

        public void RevealDealerCard()
        {
            this.dealer.RevealHiddenCard();
        }
    }
}
