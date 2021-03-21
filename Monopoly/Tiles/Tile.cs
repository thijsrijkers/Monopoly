using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Tile
    {
        private PlayerObject owner;
        private String name;

        public void setOwner(PlayerObject owner = null)
        {
            this.owner = owner;
        }

        public void setName(String name = "Naamloos") 
        {
            this.name = name;
        }
    }
}
