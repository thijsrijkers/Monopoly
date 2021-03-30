using Monopoly.Command;
using Monopoly.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles.Variants
{
    public class ChanceTile : Tile
    {
        public ChanceTile() : base(new GetChanceCard())
        {
        }
    }
}
