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

        static void Main(string[] args)
        {

            ///Creation of materials and shapes
            Material gold = new Gold();
            Material plastic = new Plastic();
            Material wood = new Wood();

            PawnShape bramShape = PawnShape.BramShape;
            PawnShape shoe = PawnShape.Shoe;
            PawnShape ship = PawnShape.Battleship;

            PawnFigure shipFigure = new PawnFigure(ship, plastic);
            PawnFigure shoeFigure = new PawnFigure(shoe, wood);

            ///Creation of board
            Board board = Board.Build(15);

            board.AddPlayer(new NPCPlayer(board.GetTiles()[0], shipFigure, 1000));
            board.AddPlayer(new NPCPlayer(board.GetTiles()[0], shoeFigure, 1000));

            ///Player
            PawnFigure playerFigure = new PawnFigure(bramShape, gold);
            HumanPlayer humanPlayer = new HumanPlayer(board.GetTiles()[0], playerFigure, 1000);
            board.AddPlayer(humanPlayer);

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
                            $"\n    help: shows command help." +
                            $"\n    quit: quits the program." +
                            $"\n    throw: Let the player throw his dice when its his turn"
                            );
                        break;
                    case "quit":
                        quit = true;
                        Console.WriteLine("Shutting down...");
                        break;
                    case "throw":
 
                        foreach(PlayerObject current in board.GetPlayers().Where(x => x != humanPlayer))
                        {
                            board.NextTurn();
                        }

                        board.NextTurn();

                        break;
                }
            }
        }
    }
}
