using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class MoveCommand : BaseCommand
    {
        private int steps;
        public MoveCommand(int steps)
        {
            this.steps = steps;
        }

        public void Execute(Board board, PlayerObject executer, PlayerObject target = null)
        {
            executer.Move(board, steps);
        }
    }
}
