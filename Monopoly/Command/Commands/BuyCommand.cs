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

        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            Buildable position = (Buildable)executor.GetPosition();
            int price = position.getPrice();
            int money = executor.GetMoney();

            if (money >= price)
            {
                executor.GiveMoneyToBank(board, price);
                position = new Owned(position);
                position.SetOwner(executor);
            }
        }
    }
}
