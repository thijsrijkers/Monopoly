using Monopoly.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles.Variants
{
    public class StartTile : Tile
    {
        private const int PASS_START_REWARD = 200;
        public StartTile() : base(new GetMoneyCommand(PASS_START_REWARD))
        {

        }
    }
}
