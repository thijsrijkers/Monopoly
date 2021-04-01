using Monopoly.Player.Pawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player
{
    public class HumanPlayer : PlayerObject
    {
        public HumanPlayer(PawnFigure pawnValue, int moneyValue, string name) : base(pawnValue, moneyValue, name)
        {
        }

        public override void GiveMoneyTo(int value, PlayerObject otherPlayer)
        {
            if (GetResponse($"{value} euro betalen aan {otherPlayer.GetName()}? (je hebt {GetMoney()} euro)"))
                base.GiveMoneyTo(value, otherPlayer);
            else
                Console.WriteLine($"Je weigerde te betalen aan {otherPlayer.GetName()}");
        }

        public override void BuyCurrentTile(Board board)
        {
            Buildable tile = (Buildable)this.GetPosition();
            if (GetResponse($"Wil je de tile {tile.getName()} kopen? Deze tile kost {tile.getPrice()} euro, je hebt momenteel {GetMoney()} euro."))
                base.BuyCurrentTile(board);
            else
                Console.WriteLine($"Je hebt {this.GetPosition().getName()} niet gekocht");
        }

        public bool GetResponse(string question)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{question} (ja/nee)>");
            Console.ForegroundColor = ConsoleColor.White;
            string response = Console.ReadLine();
            if (response.Length > 0)
            {
                char responsechar = response.ToLower().Trim()[0];
                if (responsechar == 'y' || responsechar == 'j')
                    return true;
            }
            return false;
        }
    }
}
