using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class PayCommand : BaseCommand
    {
        private int amount;

        public PayCommand(int amount)
        {
            this.amount = amount;
        }

        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            executor.GiveMoneyTo(board, amount, target);
        }
    }
}
