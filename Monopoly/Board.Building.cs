using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Monopoly.Tiles.Variants;

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

            // Create more tiles

            return board;
        }
    }
}
