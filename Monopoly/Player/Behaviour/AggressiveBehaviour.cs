using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class AggressiveBehaviour : INPCBehaviour
    {
        public bool acceptsTransactions(NPCPlayer player) {
            return true;
        }
    }
}
