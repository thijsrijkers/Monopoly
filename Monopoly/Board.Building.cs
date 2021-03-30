using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Monopoly.Tiles.Variants;
using Monopoly.Card;
using Monopoly.Command.Commands;

namespace Monopoly
{
    public partial class Board
    {
        public static Board Build(int housing)
        {
            // build the board here
            Board board = new Board();

            // Add start tile so we can assign it to players
            Tile startTile = new StartTile();
            board.AddTile(startTile);

            // Generate players
            for (int i = 0; i < housing; i++)
            {
                var rng = new Random();
                Buildable tile = new Town(rng.Next(200, 2000));
                board.AddTile((Tile)tile);
            }

            // Add cards // USE CLONE METHOD TO CREATE MULTIPLES
            var chance1 = new CardObject(new GetMoneyCommand(200));
            var chance2 = new CardObject(new PayCommand(400));
            var chance3 = new CardObject(new JailPlayer());
            var chance4 = new CardObject(new PayAllCommand(20));
            // Get 400
            board.AddChanceCard(chance1);
            for(int i = 0; i < 5; i++)
            {
                board.AddChanceCard(chance1.Clone());
            }
            // Pay 200
            board.AddChanceCard(chance2);
            for (int i = 0; i < 5; i++)
            {
                board.AddChanceCard(chance2.Clone());
            }
            // Go to jail
            board.AddChanceCard(chance3);
            for (int i = 0; i < 3; i++)
            {
                board.AddChanceCard(chance3.Clone());
            }
            // Pay all players 20
            board.AddChanceCard(chance4);
            for (int i = 0; i < 3; i++)
            {
                board.AddChanceCard(chance4.Clone());
            }

            // Add community chest cards


            // Create more tiles

            return board;
        }
    }
}
