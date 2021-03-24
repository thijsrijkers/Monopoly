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
        public static Board Build()
        {
            // build the board here
            Board board = new Board();

       
            //for(int i = 0; i < maxNPCs; i++)
            //{
            //    // Randomization for NPC pawn figures
            //    var rng = new Random();

            //    // Get all types that implement Material
            //    var materials = Assembly.GetExecutingAssembly()
            //        .GetTypes()
            //        .Where(x => 
            //            x.IsAssignableTo(typeof(Material)))
            //        .ToArray();
            //    // Create a material with a randomly selected type
            //    Material mat = (Material)Activator.CreateInstance(materials[rng.Next(0, materials.Length)]);

            //    PawnShape shape = (PawnShape)rng.Next(0, (int)PawnShape.BramShape + 1); // BramShape is the highest possible value

            //    PawnFigure figure = new PawnFigure(shape, mat);
            //    board.AddPlayer(new NPCPlayer(startTile, figure, 0));
            //}



            return board;
        }
    }
}
