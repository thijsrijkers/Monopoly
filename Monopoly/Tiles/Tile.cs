using Monopoly.Command;
using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Tile
    {
        public string Name { get; private set; }
        private BaseCommand standCommand;

        public Tile(BaseCommand standCommand)
        {
            this.standCommand = standCommand;
        }

        public void setName(string name = "Naamloos") // >:O
        {
            this.Name = name;
        }

        public void ExecuteStand(Board board, PlayerObject target)
        {
            if (standCommand != null)
            {
                standCommand.Execute(board, target);
            }
        }
    }
}
