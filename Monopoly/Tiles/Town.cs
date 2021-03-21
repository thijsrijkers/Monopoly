using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Town : Tile, Buildable
    {
        private double price;

        public Town(double price)
        {
            this.price = price;
        }

        public double getPrice()
        {
            return this.price;
        }

        public int getAmountOfHouses() {
            return 0;
        }

        public Boolean hasHotel() {
            return false;
        }
    }
}
