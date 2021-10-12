using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            PointsHandler pointsHandler = new PointsHandler(5000);
            
            while (!pointsHandler.IsOutOfPoints())
            {
                pointsHandler.SetBet();

                GameHandler gameHandler = new GameHandler();

                gameHandler.DrawCard("dealer");
                gameHandler.DrawCard("dealer");

                gameHandler.DrawCard("player");
                gameHandler.DrawCard("player");

                gameHandler.CheckAce();

                pointsHandler.PrintPlayingPoints();
                gameHandler.PrintInfo("dealer");
                gameHandler.PrintInfo("player");

                if (gameHandler.CheckBlackjack() == 1)
                {
                    pointsHandler.Tie();
                    Console.ReadLine();
                    continue;
                }
                else if (gameHandler.CheckBlackjack() == 2)
                {
                    pointsHandler.Win();
                    Console.ReadLine();
                    continue;
                }
                else if (gameHandler.CheckBlackjack() == 3)
                {
                    Console.ReadLine();
                    continue;
                }

                bool loop = true;
                while (loop)
                {
                    if (gameHandler.CanDraw("player"))
                    {
                        Console.WriteLine();
                        int choice;
                        Console.WriteLine("Pasirinkite tolimesnį žingsnį: ");
                        Console.WriteLine("1 - traukti kortą");
                        Console.WriteLine("2 - fiksuoti kortas");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                pointsHandler.PrintPlayingPoints();
                                gameHandler.DrawCard("player");
                                gameHandler.CheckAce();
                                gameHandler.PrintInfo("dealer");
                                gameHandler.PrintInfo("player");
                                break;
                            case 2:
                                Console.Clear();
                                pointsHandler.PrintPlayingPoints();
                                while (gameHandler.CanDraw("dealer"))
                                {
                                    gameHandler.DrawCard("dealer");
                                    gameHandler.CheckAce();
                                }
                                loop = false;
                                gameHandler.PrintInfo("dealer");
                                gameHandler.PrintInfo("player");
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Negalimas pasirinkimas");
                                break;
                        }
                    }
                    else
                    {
                        if(gameHandler.CheckGameState() != 0)
                        {
                            Console.Clear();
                            pointsHandler.PrintPlayingPoints();
                            while (gameHandler.CanDraw("dealer"))
                            {
                                gameHandler.DrawCard("dealer");
                                gameHandler.CheckAce();
                            }
                            loop = false;
                            gameHandler.PrintInfo("dealer");
                            gameHandler.PrintInfo("player");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if(gameHandler.CheckGameState() == 1)
                {
                    pointsHandler.Tie();
                    Console.ReadLine();
                }
                else if(gameHandler.CheckGameState() == 2)
                {
                    pointsHandler.Win();
                    Console.ReadLine();
                }
                else
                {
                    Console.ReadLine();
                    continue;
                }
            }
            if (pointsHandler.IsOutOfPoints())
            {
                Console.WriteLine("Pralaimėjote žaidimą. Maksimaliai buvo surinkta {0} taškų", pointsHandler.GetMaximumPoints());
            }
            else
            {
                Console.WriteLine("Žaidimas baigtas. Surinkta {0} taškų. Maksimaliai buvo surinkta {1} taškų", pointsHandler.GetPoints(), pointsHandler.GetMaximumPoints());
            }
        }

    }
}
