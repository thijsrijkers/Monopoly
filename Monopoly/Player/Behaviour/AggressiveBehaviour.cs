using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class AggressiveBehaviour : INPCBehaviour
    {
        public bool wantsToRush(NPCPlayer player)
        {
            return true;
        }

        public bool acceptsTransactions(NPCPlayer player) 
        {
            return true;
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
