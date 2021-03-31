using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Command.Commands
{
    public class PayCommand : BaseCommand
    {
        private int amount;

        public PayCommand(int amount)
        {
            this.amount = amount;
        }

        public void Execute(Board board, PlayerObject executor, PlayerObject target = null)
        {
            PlayerObject paytarget = target;

            if (target == null)
            {
                Tile tile = executor.GetPosition();
                if (tile.GetType().IsAssignableTo(typeof(Buildable)))
                {
                    Buildable btile = (Buildable)tile;
                    PlayerObject owner = btile.GetOwner();
                    if (owner != null && executor != owner)
                    {
                        Console.WriteLine($"{executor.GetName()} moest {owner.GetName()} {amount} euro betalen.");
                        executor.GiveMoneyTo(board, amount, owner);
                    }
                }
            }
            else
            {
                if (executor != target)
                {
                    Console.WriteLine($"{executor.GetName()} moest {target.GetName()} {amount} euro betalen.");
                    executor.GiveMoneyTo(board, amount, target);
                }
            }
        }
    }
}
