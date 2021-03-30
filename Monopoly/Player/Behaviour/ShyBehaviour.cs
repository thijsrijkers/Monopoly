﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class ShyBehaviour : INPCBehaviour
    {
        public bool acceptsTransactions(NPCPlayer player)
        {
            return false;
        }

        public bool pullsCard(NPCPlayer player) {
            return false;
        }
    }
}