using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class ShyBehaviour : INPCBehaviour
    {
        public bool wantsToRush(NPCPlayer player)
        {
            return false;
        }

        public bool acceptsTransactions(NPCPlayer player)
        {
            return new Random().Next(0, 2) == 0; // 50/50 chance to accept
        }

        public bool prefersJail(NPCPlayer player)
        {
            return false;
        }

        public bool pullsCard(NPCPlayer player) 
        {
            return false;
        }
    }
}
