using Monopoly.Player;
using Monopoly.Tiles.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class JailPlayer : BaseCommand
    {
        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            Console.WriteLine($"{executor.GetName()} ging naar de gevangenis.");
            executor.SendToJail(board);
        }
    }
}
