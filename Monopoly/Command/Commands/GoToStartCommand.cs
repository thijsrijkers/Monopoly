using Monopoly.Player;
using Monopoly.Tiles.Variants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class GoToStartCommand : BaseCommand
    {
        public void Execute(Board board, PlayerObject executer, PlayerObject target = null)
        {
            Console.WriteLine($"{executer.GetName()} ging terug naar start.");
            var start = board.GetTiles().FirstOrDefault(x => x.GetType() == typeof(StartTile));
            executer.SetTile(start);
        }
    }
}
