using Monopoly.Command;
using Monopoly.Command.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles.Variants
{
    public class Chance : Tile
    {
        public Chance() : base(new GetChanceCard())
        {
        }
    }
}
