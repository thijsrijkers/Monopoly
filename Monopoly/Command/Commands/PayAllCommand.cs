using Monopoly.Player;
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
            Console.WriteLine($"{executer.GetName()} moest iedereen {amount} betalen.");
            List<PlayerObject> players = board.GetPlayers().ToList();
            players.Remove(executer);

            int fullamount = players.Count() * amount;
            if (executer.GetMoney() <= fullamount)
            {
                fullamount = executer.GetMoney();
            }

            foreach (var player in players)
            {
                executer.GiveMoneyTo(fullamount / players.Count(), player);
            }
            board.TransactionToAllPlayers(executer, amount);
        }
    }
}
