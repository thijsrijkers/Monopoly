using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class CalmBehaviour : INPCBehaviour
    {
        private const int threshold = 500;

        public bool wantsToRush(NPCPlayer player)
        {
            return false;
        }

        public bool acceptsTransactions(NPCPlayer player)
        {
            int money = player.GetMoney();

            return money > threshold;
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
