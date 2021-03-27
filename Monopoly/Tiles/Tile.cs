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
        private BaseCommand passCommand;

        public Tile(BaseCommand standCommand, BaseCommand passCommand)
        {
            this.standCommand = standCommand;
            this.passCommand = passCommand;
        }

        public void setName(string name = "Naamloos") // >:O
        {
            this.Name = name;
        }

        public void ExecuteStand(Board board, PlayerObject target)
        {
            if (standCommand != null)
                standCommand.Execute(board, target);
        }

        public void ExecutePass(Board board, PlayerObject target)
        {
            if (passCommand != null)
                passCommand.Execute(board, target);
        }
    }
}
