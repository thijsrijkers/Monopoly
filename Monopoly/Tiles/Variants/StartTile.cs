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
        public StartTile() : base(null)
        {
            setName("Start Tile");
        }
    }
}
