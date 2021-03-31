using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class PayBankCommand : BaseCommand
    {
        private int amount;

        public PayBankCommand(int amount)
        {
            this.amount = amount;
        }

        public void Execute(Board board, PlayerObject executer, PlayerObject target = null)
        {
            Console.WriteLine($"{executer.GetName()} moest de bank {amount} betalen.");
            executer.GiveMoneyToBank(board, amount);
        }
    }
}
