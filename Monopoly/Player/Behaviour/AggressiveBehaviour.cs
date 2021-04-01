using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class AggressiveBehaviour : INPCBehaviour
    {
        private Board board;
        public AggressiveBehaviour(Board board)
        {
            this.board = board;
        }

        public void PayAmount(NPCPlayer player, PlayerObject other, int amount)
        {
            if (new Random().Next(0, 5) == 1)
                Console.WriteLine($"{player.GetName()} weigerde te betalen aan {other.GetName()}.");
            else
                player.giveMoneyTo(amount, other);
        }

        public void ContemplateJail(NPCPlayer player)
        {
            Random rnd = new Random();
            int jailChange = rnd.Next(1, 11);

            if (jailChange > 5)
            {
                Console.WriteLine($"{player.GetName()} leek het een beter idee om vrijwillig naar de gevangenis te gaan.");
                player.SendToJail(board);
                return;
            }
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
            if (new Random().Next(0, 5) == 1)
                Console.WriteLine($"{player.GetName()} weigerde te betalen aan de bank.");
            else
                player.giveMoneyToBank(amount);
        }

        public void BuyCurrentTile(NPCPlayer player)
        {
            player.buyCurrentTile(this.board);
        }

        public void ThrowDice(NPCPlayer player, int alreadyThrown)
        {
            ContemplateJail(player);

            player.throwDice(board, alreadyThrown);
            Console.WriteLine($"{player.GetName()} gooide stiekem nog een keer.");
            player.throwDice(board, alreadyThrown);
        }
    }
}
