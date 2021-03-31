using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    class TownVisitCommand : BaseCommand
    {
        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            Buildable pos = (Buildable)executor.GetPosition();

            // when the owner visits the tile, a new house is built.
            // when another visitor visits the tile, they pay rent
            if (pos.GetOwner().Equals(executor))
            {
                new BuildCommand().Execute(board, executor, target);
            }
            else 
            {
                new PayCommand(pos.getPrice()).Execute(board, executor, target);
            }
        }
    }
}
