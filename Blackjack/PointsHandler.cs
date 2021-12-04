using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class PointsHandler
    {
        private int points;
        private int bet;
        private int maximumPoints;

        public PointsHandler(int points)
        {
            this.points = points;
            this.maximumPoints = points;
        }

        public int GetPoints()
        {
            return this.points;
        }

        public void SetBet()
        {
            int chosenBet = -1;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Įveskite taškų kiekį ({0}): ", this.points);
                    chosenBet = int.Parse(Console.ReadLine());
                }
                catch
                {
                    continue;
                }
            } while (chosenBet > this.points || chosenBet <= 0);
            this.bet = chosenBet;
            this.points -= chosenBet;
            PrintPlayingPoints();
        }

        public void CountPoints(int gameStateId)
        {
            switch (gameStateId)
            {
                case 0:
                    this.points += this.bet;
                    break;
                case 1:
                    this.points += 2 * this.bet;
                    if (this.points > this.maximumPoints)
                    {
                        this.maximumPoints = this.points;
                    }
                    break;
                default:
                    break;
            }
        }

        public bool IsOutOfPoints()
        {
            if(this.points == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintPlayingPoints()
        {
            Console.Clear();
            Console.WriteLine("Žaidžiama iš {0} taškų", this.bet);
        }

        public int GetMaximumPoints()
        {
            return maximumPoints;
        }
    }
}
