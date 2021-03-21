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

        public HouseBuilt(Buildable tile) {
            this.tile = tile;
        }

        public double getPrice()
        {
            return this.tile.getPrice() * 2;
        }

        public int getAmountOfHouses() {
            return this.tile.getAmountOfHouses() + 1;
        }

        public Boolean hasHotel() {
            return this.tile.hasHotel();
        }
    }
}
