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
    public class Town : Tile, Buildable
    {
        private int price;
        private PlayerObject owner;

        public Town(int price) : base(new BuyCommand())
        {
            this.price = price;
        }

        public int getPrice()
        {
            return this.price;
        }

        public int getAmountOfHouses() {
            return 0;
        }

        public Boolean hasHotel() {
            return false;
        }

        public void SetOwner(PlayerObject value = null)
        {
            this.owner = value;
        }

        public PlayerObject GetOwner()
        {
            return this.owner;
        }
    }
}
