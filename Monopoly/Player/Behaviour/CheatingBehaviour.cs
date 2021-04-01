using Monopoly.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class CheatingBehaviour : INPCBehaviour
    {
        private const int threshold = 500;

        private Board board;
        public CheatingBehaviour(Board board)
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
            if (new Random().Next(0, 2) == 1)
                Console.WriteLine($"{player.GetName()} weigerde een chance kaart te pakken.");
            else
            {
                var card = board.DrawChanceCard();
                card.ExecuteCommand(board, player);
            }
        }

        public void DrawCommunityChestCard(NPCPlayer player)
        {
            if (new Random().Next(0, 2) == 1)
                Console.WriteLine($"{player.GetName()} weigerde een community chest te pakken.");
            else
            {
                var card = board.DrawCommunityChestCard();
                card.ExecuteCommand(board, player);
            }
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
            Buildable position = (Buildable)player.GetPosition();
            int price = position.getPrice() / 2;
            int money = player.GetMoney();

            if (money >= price / 2)
            {
                Console.WriteLine($"{player.GetName()} heeft {player.GetPosition().getName()} gekocht, en heeft stiekem maar de helft betaald.");
                player.SetMoney(money - price);
                position = new Owned(position);
                position.SetOwner(player);

                //randomly assign a hotel or a few houses.
                int rdm = new Random().Next(1, 10);

                if (rdm == 5)
                {
                    position = new HotelBuilt(position);
                }
                else if (rdm < 5)
                {
                    for (int i = 0; i < rdm; i++)
                    {
                        position = new HouseBuilt(position);
                    }
                }

                board.UpdateTile(position);
            }
            else
            {
                Console.WriteLine($"{player.GetName()} probeerde {position.getName()} te kopen, maar had niet genoeg geld.");
            }
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
