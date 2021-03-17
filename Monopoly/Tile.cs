using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Tile
    {
        private double standardPrice;
        private PlayerObject owner;

        public void AddPlayer(PlayerObject value)
        {
            this.owner = value;
        }
    }
}
