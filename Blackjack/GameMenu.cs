using System;
using System.Collections.Generic;

namespace Blackjack
{
    class GameMenu
    {
        static void Main(string[] args)
        {
            PointsHandler pointsHandler = new PointsHandler(5000);
            char gameEnd = 'a';
            while (!pointsHandler.IsOutOfPoints() && gameEnd != 'q' && gameEnd != 'Q')
            {
                pointsHandler.SetBet();

                GameHandler gameHandler = new GameHandler();

                gameHandler.DrawCard("dealer");
                gameHandler.DrawCard("dealer");

                gameHandler.DrawCard("player");
                gameHandler.DrawCard("player");

                gameHandler.CheckAce();

                pointsHandler.PrintPlayingPoints();
                gameHandler.PrintInfo();

                if (gameHandler.CheckInitialGameState() != 3)
                {
                    Console.Clear();
                    gameHandler.RevealDealerCard();
                    pointsHandler.PrintPlayingPoints();
                    gameHandler.PrintInfo();
                    gameHandler.PrintGameStateMessage(gameHandler.CheckInitialGameState());
                    pointsHandler.CountPoints(gameHandler.CheckInitialGameState());
                    Console.ReadLine();
                    continue;
                }

                bool loop = true;
                while (loop)
                {
                    if (gameHandler.CanDraw("player"))
                    {
                        Console.WriteLine();
                        int choice = 0;
                        Console.WriteLine("Pasirinkite tolimesnį žingsnį: ");
                        Console.WriteLine("1 - traukti kortą");
                        Console.WriteLine("2 - fiksuoti kortas");
                        do
                        {
                            try
                            {
                                Console.SetCursorPosition(0, 18);
                                Console.WriteLine(new String(' ', Console.WindowWidth));
                                Console.SetCursorPosition(0, 18);
                                choice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                continue;
                            }
                        } while (choice == 0);

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                pointsHandler.PrintPlayingPoints();
                                gameHandler.DrawCard("player");
                                gameHandler.CheckAce();
                                gameHandler.PrintInfo();
                                break;
                            case 2:
                                Console.Clear();
                                gameHandler.RevealDealerCard();
                                pointsHandler.PrintPlayingPoints();
                                while (gameHandler.CanDraw("dealer"))
                                {
                                    gameHandler.DrawCard("dealer");
                                    gameHandler.CheckAce();
                                }
                                loop = false;
                                gameHandler.PrintInfo();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Negalimas pasirinkimas");
                                break;
                        }
                    }
                    else
                    {
                        if(gameHandler.CheckGameState() != 2)
                        {
                            Console.Clear();
                            gameHandler.RevealDealerCard();
                            pointsHandler.PrintPlayingPoints();
                            while (gameHandler.CanDraw("dealer"))
                            {
                                gameHandler.DrawCard("dealer");
                                gameHandler.CheckAce();
                            }
                            gameHandler.PrintInfo();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            gameHandler.RevealDealerCard();
                            pointsHandler.PrintPlayingPoints();
                            gameHandler.PrintInfo();
                            break;
                        }
                    }
                }
                
                gameHandler.PrintGameStateMessage(gameHandler.CheckGameState());
                pointsHandler.CountPoints(gameHandler.CheckGameState());
                Console.WriteLine("Norėdami baigti žaidimą įveskite Q, kitu atveju spauskite Enter");
                do
                {
                    try
                    {
                        gameEnd = char.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        break;
                    }
                } while (true);
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
