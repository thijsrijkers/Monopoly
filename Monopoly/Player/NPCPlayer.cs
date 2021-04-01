using Monopoly.Player.Pawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class NPCPlayer : PlayerObject
    {
        private INPCBehaviour behaviour;

        public NPCPlayer(Board board, PawnFigure pawnValue, int moneyValue, string name) : base(pawnValue, moneyValue, name)
        {
            this.behaviour = new CalmBehaviour(board);
        }

        public void SwitchBehaviour(Board board)
        {
            Random rnd = new Random();
            bool isCheating = rnd.Next(1, 11) == 5;

            if (isCheating)
            {
                this.behaviour = new CheatingBehaviour(board);
                return;
            }

            if (this.GetMoney() < 200)
            {
                this.behaviour = new ShyBehaviour(board);
                return;
            }

            int index = board.GetTiles().FindIndex(a => a == GetPosition());

            if (index < (board.GetTiles().Count / 4))
            {
                this.behaviour = new AggressiveBehaviour(board);
                return;
            }

            this.behaviour = new CalmBehaviour(board);
        }

        public override void ThrowDice(Board board, int alreadyThrown)
        {
            INPCBehaviour oldBehaviour = behaviour;
            SwitchBehaviour(board);
            if(oldBehaviour.GetType() != behaviour.GetType())
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{GetName()} switchte naar {behaviour.GetType().ToString().Split('.').Last()}");
                Console.ResetColor();
            }
            behaviour.ThrowDice(this, alreadyThrown);
        }

        public override void GiveMoneyTo(int value, PlayerObject otherPlayer)
        {
            behaviour.PayAmount(this, otherPlayer, value);
        }

        public override void GiveMoneyToBank(int value)
        {
            behaviour.PayBank(this, value);
        }

        public override void BuyCurrentTile(Board board)
        {
            behaviour.BuyCurrentTile(this);
        }

    }
}
