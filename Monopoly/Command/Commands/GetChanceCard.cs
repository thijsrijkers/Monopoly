using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class GetChanceCard : BaseCommand
    {
        public void Execute(Board board, PlayerObject executer, PlayerObject target = null)
        {
            Console.WriteLine($"{executer.GetName()} kreeg een kanskaart.");
            var card = board.DrawChanceCard();
            card.ExecuteCommand(board, executer);
        }
    }
}
