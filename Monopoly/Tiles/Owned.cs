using Monopoly.Command.Commands;
using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    class Owned : Tile, Buildable
    {
        private Buildable tile;

        public Owned(Buildable tile) : base(null)
        {
            this.tile = tile;

            base.SetCommand(new PayCommand(100));
        }

        public int getPrice()
        {
            return this.tile.getPrice();
        }

        public int getAmountOfHouses()
        {
            return this.tile.getAmountOfHouses();
        }

        public Boolean hasHotel()
        {
            return this.tile.hasHotel();
        }

        public void SetOwner(PlayerObject value)
        {
            this.tile.SetOwner(value);
        }

        public PlayerObject GetOwner()
        {
            return this.tile.GetOwner();
        }
    }
}
