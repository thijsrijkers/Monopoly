using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Tiles
{
    interface Ownable
    {
        public void SetOwner(PlayerObject owner = null);

        public PlayerObject GetOwner();
    }
}
