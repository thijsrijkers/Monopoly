using Monopoly.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles.Variants
{
    public class GoToJail : Tile
    {
        public GoToJail() : base(new JailPlayer()) { }
    }
}
