using System;
using System.Collections.Generic;
using BlackjackGameState;

namespace Blackjack
{
    class GameLauncher
    {
        private static PointsHandler pointsHandler = new PointsHandler(10000);
        private static bool stopGame = false;
        static void Main(string[] args)
        {
            while (!pointsHandler.IsOutOfPoints() && !stopGame)
            {
                pointsHandler.SetBet();
                GameHandler gameHandler = new GameHandler();

                if (DidGameEndAfterFirstPart(gameHandler))
                {
                    continue;
                }

                LaunchSecondGamePart(gameHandler);
            }
            PrintGameEndMessage();
        }

        public static void PrintGameEndMessage()
        {
            if (pointsHandler.IsOutOfPoints())
            {
                Console.WriteLine("Pralaimėjote žaidimą. Maksimaliai buvo surinkta {0} taškų", pointsHandler.GetMaximumPoints());
            }
            else
            {
                Console.WriteLine("Žaidimas baigtas. Surinkta {0} taškų. Maksimaliai buvo surinkta {1} taškų", pointsHandler.GetPoints(), pointsHandler.GetMaximumPoints());
            }
        }

        public static bool DidGameEndAfterFirstPart(GameHandler gameHandler)
        {
            gameHandler.PickCard("dealer", 2);
            gameHandler.PickCard("player", 2);
            PrintInfoDuringRound(gameHandler, false);

            if (gameHandler.CheckInitialGameState() != GameState.Continue)
            {
                Console.Clear();
                PrintInfoDuringRound(gameHandler, true);
                PrintInfoAfterRound(gameHandler);
                CheckGameStop();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void LaunchSecondGamePart(GameHandler gameHandler)
        {
            bool loopSecondGamePart = true;
            while (loopSecondGamePart)
            {
                if (gameHandler.CanPick("player"))
                {
                    AskForPlayerAction(gameHandler, ref loopSecondGamePart);
                }
                else
                {
                    DoDealerAction(gameHandler, ref loopSecondGamePart);
                }
            }
            PrintInfoAfterRound(gameHandler);
            CheckGameStop();
        }

        public static void AskForPlayerAction(GameHandler gameHandler, ref bool loopSecondGamePart) {
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
            DoPlayerAction(gameHandler, choice, ref loopSecondGamePart);
        }

        public static void DoPlayerAction(GameHandler gameHandler, int chosenAction, ref bool loopSecondGamePart)
        {
            switch (chosenAction)
            {
                case 1:
                    Console.Clear();
                    gameHandler.PickCard("player");
                    PrintInfoDuringRound(gameHandler, false);
                    break;
                case 2:
                    Console.Clear();
                    DoDealerAction(gameHandler, ref loopSecondGamePart);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Negalimas veiksmas");
                    break;
            }
        }

        public static void DoDealerAction(GameHandler gameHandler, ref bool loopSecondGamePart)
        {
            if (gameHandler.CheckGameState() != GameState.Lose)
            {
                Console.Clear();
                while (gameHandler.CanPick("dealer"))
                {
                    gameHandler.PickCard("dealer");
                    gameHandler.CheckAces();
                }
                PrintInfoDuringRound(gameHandler, true);
            }
            else
            {
                Console.Clear();
                PrintInfoDuringRound(gameHandler, true);
            }
            loopSecondGamePart = false;
        }

        public static void CheckGameStop()
        {
            Console.WriteLine("Norėdami baigti žaidimą įveskite Q, kitu atveju spauskite Enter");
            try
            {
                char gameEnd = char.Parse(Console.ReadLine());
                if (gameEnd == 'q' || gameEnd == 'Q')
                {
                    stopGame = true;
                }
            }
            catch
            {
                stopGame = false;
            }
        }

        public static void PrintInfoAfterRound(GameHandler gameHandler)
        {
            gameHandler.PrintGameStateMessage(gameHandler.CheckGameState());
            pointsHandler.CountPoints(gameHandler.CheckGameState());
        }

        public static void PrintInfoDuringRound(GameHandler gameHandler, bool reveal)
        {
            if (reveal)
            {
                gameHandler.RevealHiddenCard();
            }
            else
            {
                gameHandler.CheckAces();
            }
            pointsHandler.PrintPlayingPoints();
            gameHandler.PrintInfo();
        }
    }
}
