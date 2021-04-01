using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface Buildable
    {
        public int getPrice();

        public int getAmountOfHouses();

        public Boolean hasHotel();

        public void SetOwner(PlayerObject owner);

        public PlayerObject GetOwner();

        public string getName();

        public Town GetTown();
    }
}
