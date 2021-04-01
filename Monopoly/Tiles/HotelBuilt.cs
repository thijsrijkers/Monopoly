using Monopoly.Command.Commands;
using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class HotelBuilt : Tile, Buildable
    {
        private Buildable tile;

        public HotelBuilt(Buildable tile) : base(new PayCommand(tile.getPrice()))
        {
            this.tile = tile;
        }

        public int getPrice()
        {
            return this.tile.getPrice() + 150;
        }

        public int getAmountOfHouses()
        {
            return this.tile.getAmountOfHouses();
        }

        public Boolean hasHotel() {
            return true;
        }

        public void SetOwner(PlayerObject value)
        {
            tile.SetOwner(value);
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
