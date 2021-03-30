using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class CheatingBehaviour : INPCBehaviour
    {
        private const int cheatingAmount = 10;

        public bool wantsToRush(NPCPlayer player)
        {
            return false;
        }

        public bool acceptsTransactions(NPCPlayer player)
        {
            int money = player.GetMoney();

            return true;
        }

        public bool prefersJail(NPCPlayer player)
        {
            return true;
        }

        public bool pullsCard(NPCPlayer player)
        {
            return false;
        }
    }
}
