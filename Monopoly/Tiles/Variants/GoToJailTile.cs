using Monopoly.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles.Variants
{
    public class GoToJailTile : Tile
    {
        public GoToJailTile() : base(new JailPlayer()) 
        {
            setName("Go To Jail Tile");
        }
    }
}
