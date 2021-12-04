using System;
using System.Collections.Generic;
using BlackjackGameState;

namespace Blackjack
{
    class GameLauncher
    {
        static void Main(string[] args)
        {
            PointsHandler pointsHandler = new PointsHandler(10000);
            bool endGame = false;
            while (!pointsHandler.IsOutOfPoints() && !endGame)
            {
                pointsHandler.SetBet();

                GameRoundHandler gameHandler = new GameRoundHandler();

                gameHandler.PickCard("dealer", 2);

                gameHandler.PickCard("player", 2);

                gameHandler.CheckAce();

                pointsHandler.PrintPlayingPoints();
                gameHandler.PrintInfo();

                if (gameHandler.CheckInitialGameState() != GameState.Continue)
                {
                    Console.Clear();
                    gameHandler.RevealHiddenCard();
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
                    if (gameHandler.CanPick("player"))
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
                                gameHandler.PickCard("player");
                                gameHandler.CheckAce();
                                gameHandler.PrintInfo();
                                break;
                            case 2:
                                Console.Clear();
                                gameHandler.RevealHiddenCard();
                                pointsHandler.PrintPlayingPoints();
                                while (gameHandler.CanPick("dealer"))
                                {
                                    gameHandler.PickCard("dealer");
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
                        if(gameHandler.CheckGameState() != GameState.Lose)
                        {
                            Console.Clear();
                            gameHandler.RevealHiddenCard();
                            pointsHandler.PrintPlayingPoints();
                            while (gameHandler.CanPick("dealer"))
                            {
                                gameHandler.PickCard("dealer");
                                gameHandler.CheckAce();
                            }
                            gameHandler.PrintInfo();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            gameHandler.RevealHiddenCard();
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
                        char gameEnd = char.Parse(Console.ReadLine());
                        if (gameEnd == 'q' || gameEnd == 'Q')
                            endGame = true;
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
