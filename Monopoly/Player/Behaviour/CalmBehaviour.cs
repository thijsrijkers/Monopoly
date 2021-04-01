using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class CalmBehaviour : INPCBehaviour
    {
        private const int threshold = 500;

        private Board board;
        public CalmBehaviour(Board board)
        {
            this.board = board;
        }

        public void PayAmount(NPCPlayer player, PlayerObject other, int amount)
        {
            int money = player.GetMoney();

            if (money > threshold)
            {
                player.giveMoneyTo(amount, other);
            }
            else
            {
                Console.WriteLine($"{player.GetName()} weigerde te betalen aan {other.GetName()}.");
            }
        }

        public void ContemplateJail(NPCPlayer player)
        {
        }

        public void DrawChanceCard(NPCPlayer player)
        {
            var card = board.DrawChanceCard();
            card.ExecuteCommand(board, player);
        }

        public void DrawCommunityChestCard(NPCPlayer player)
        {
            var card = board.DrawCommunityChestCard();
            card.ExecuteCommand(board, player);
        }

        public void PayBank(NPCPlayer player, int amount)
        {
            int money = player.GetMoney();

            if(money > threshold)
                player.giveMoneyToBank(amount);
            else
                Console.WriteLine($"{player.GetName()} weigerde te betalen aan de bank.");
        }

        public void BuyCurrentTile(NPCPlayer player)
        {
            int money = player.GetMoney();

            if (money > threshold)
            {
                player.buyCurrentTile(this.board);
            }
        }

        public void ThrowDice(NPCPlayer player, int alreadyThrown)
        {
            ContemplateJail(player);

            player.throwDice(board, alreadyThrown);
        }
    }
}
