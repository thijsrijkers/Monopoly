using Monopoly;
using Monopoly.Card;
using Monopoly.Command.Commands;
using Monopoly.Player;
using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using Monopoly.Tiles.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Monopoly.Test")] // Ensure internals are visible to test project

namespace Monopoly
{
    public class Program
    {
        static bool quit = false;
        static bool hasHumanPlayer = false;

        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Welkom bij command line monopoly. Typ 'help' voor een command listing.");

            string play = "";
            while (play != "j" && play != "n")
            {
                Console.Write("Wil je zelf mee spelen? (j/n) ");
                play = Console.ReadLine();
            }
            hasHumanPlayer = play == "j";
            ///Creation of board
            Board board = Board.Build(15, hasHumanPlayer);

            // ophalen van human player uit board.
            var humanPlayer = board.GetPlayers().FirstOrDefault(x => x.GetType() == typeof(HumanPlayer));

            while (!quit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("> ");
                var cmd = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                switch (cmd)
                {
                    case "help":
                        Console.WriteLine(
                            $"Command help:" +
                            $"\n    help: laat command help zien." +
                            $"\n    quit: sluit het programma." +
                            $"\n    throw: laat de speler gooien. Wordt ook uitgevoerd bij een leeg command (enter)." +
                            $"\n    complete: maakt het spel af zonder pauzes, behalve wanneer player input nodig is."
                            );
                        break;

                    case "quit":
                        quit = true;
                        Console.WriteLine("Aan het afsluiten...");
                        break;

                    case "throw":
                    case "":
                        for(int i = 0; i < board.GetPlayers().Count(); i++)
                        {
                            board.NextTurn();
                        }

                        break;

                    case "complete":
                        bool running = true;
                        while (running) 
                        {
                            Console.WriteLine("--------------------");
                            for (int i = 0; i < board.GetPlayers().Count(); i++)
                            {
                                running = board.NextTurn();
                            }
                        }
                        break;

                    case "reset":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Het spel is gereset.");
                        Console.WriteLine("--------------------");
                        board = Board.Build(15, hasHumanPlayer);
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
