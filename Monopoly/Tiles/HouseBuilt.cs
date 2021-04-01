using Monopoly.Command.Commands;
using Monopoly.Player;
using Monopoly.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class HouseBuilt : Tile, Buildable
    {
        private Buildable tile;

        public HouseBuilt(Buildable tile) : base(new PayCommand(tile.getPrice()))
        {
            this.tile = tile;
        }

        public int getPrice()
        {
            return this.tile.getPrice() + 20;
        }

        public int getAmountOfHouses() {
            return this.tile.getAmountOfHouses() + 1;
        }

        public Boolean hasHotel() {
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

        public override string getName()
        {
            return tile.getName();
        }

        public Town GetTown()
        {
            return tile.GetTown();
        }
    }
}
