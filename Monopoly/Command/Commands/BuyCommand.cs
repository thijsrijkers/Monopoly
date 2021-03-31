using Monopoly.Player;
using Monopoly.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class BuyCommand : BaseCommand
    {
        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            executor.BuyCurrentTile(board);
        }
    }
}
