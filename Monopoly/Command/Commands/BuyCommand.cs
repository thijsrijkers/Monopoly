using Monopoly.Player;
using Monopoly.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    class BuyCommand : BaseCommand
    {
        private int amount;
        private bool bought;

        public BuyCommand(int amount)
        {
            this.amount = amount;
        }

        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            executor.ReceiveMoney(amount);

            //executor.get
            
            
            Buildable position = (Buildable)executor.GetPosition();
            position = new Owned(position);


            //board.GetTiles().Find(x => x.getPlayer == typeof(JailTile)));
            //new Owned();
            //.First(x => x.GetType() == typeof(JailTile))
        }
    }
}
