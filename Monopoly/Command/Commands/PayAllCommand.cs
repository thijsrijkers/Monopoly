﻿using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class PayAllCommand : BaseCommand
    {
        private int amount;

        public PayAllCommand(int amount)
        {
            this.amount = amount;
        }

        public void Execute(Board board, PlayerObject executer, PlayerObject target = null)
        {
            board.TransactionToAllPlayers(executer, amount);
        }
    }
}