using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    interface Buildable
    {
        public double getPrice();

        public int getAmountOfHouses();

        public Boolean hasHotel();
    }
}
