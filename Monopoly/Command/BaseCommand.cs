using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command
{
    public interface BaseCommand
    {
        public void Execute(Board board, PlayerObject executer, PlayerObject target = null);
    }
}
