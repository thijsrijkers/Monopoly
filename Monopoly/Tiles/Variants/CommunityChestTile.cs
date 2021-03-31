using Monopoly.Command;
using Monopoly.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles.Variants
{
    public class CommunityChestTile : Tile
    {
        public CommunityChestTile() : base(new GetCommunityChestCard())
        {
            setName("Community Chest Tile");
        }
    }
}
