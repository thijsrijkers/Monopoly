using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    class BuildCommand : BaseCommand
    {
        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            Buildable tile = (Buildable)executor.GetPosition();
            int idx = board.GetTiles().FindIndex(x => x.Equals(tile));

            board.GetTiles()[idx] = new HouseBuilt(tile);

            //Change the position to the new housebuilt tile
            foreach (PlayerObject player in board.GetPlayers())
            {
                if (player.GetPosition().Equals(tile)) 
                { 
                    player.SetTile(board.GetTiles()[idx]);
                }
            }
        }
    }
}
