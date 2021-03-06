using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class GetCommunityChestCard : BaseCommand
    {
        public void Execute(Board board, PlayerObject executer, PlayerObject target = null)
        {
            Console.WriteLine($"{executer.GetName()} kreeg een Community Chest kaart.");
            var card = board.DrawCommunityChestCard();
            card.ExecuteCommand(board, executer);
        }
    }
}
