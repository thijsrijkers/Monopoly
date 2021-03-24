
using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class GetMoneyCommand : BaseCommand
    {
        private int amount;

        public GetMoneyCommand(int amount)
        {
            this.amount = amount;
        }

        public void Execute(Board board, PlayerObject target)
        {
            target.ReceiveMoney(amount);
        }
    }
}
