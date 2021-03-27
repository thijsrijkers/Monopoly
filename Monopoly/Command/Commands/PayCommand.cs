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
        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            executor.GiveMoneyTo(board, 500, target); // set amount or param?
        }
    }
}
