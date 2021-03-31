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
        private string name { get; set; } = "Naamloos";
        protected BaseCommand standCommand;

        public Tile(BaseCommand standCommand)
        {
            this.standCommand = standCommand;
        }

        public void SetCommand(BaseCommand command) {
            this.standCommand = command;
        }

        public void setName(string name = "Naamloos") // >:O
        {
            this.name = name;
        }

        public virtual string getName()
        {
            return this.name;
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
