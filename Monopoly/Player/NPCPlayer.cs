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

        public NPCPlayer(PawnFigure pawnValue, int moneyValue, string name) : base(pawnValue, moneyValue, name)
        {
            this.behaviour = new CalmBehaviour();
        }

        public void SwitchBehaviour(Board board)
        {
            Random rnd = new Random();
            bool isCheating = rnd.Next(1, 11) == 5;
            
            if(isCheating)
            {
                this.behaviour = new CheatingBehaviour();
                return;
            }

            if (this.GetMoney() < 200)
            {
                this.behaviour = new ShyBehaviour();
                return;
            }

            int index = board.GetTiles().FindIndex(a => a == GetPosition());

            if (index < (board.GetTiles().Count / 4))
            {
                this.behaviour = new AggressiveBehaviour();
                return;
            }

            this.behaviour = new CalmBehaviour();
        }

        public override void ThrowDice(Board board, int alreadyThrown)
        {
            SwitchBehaviour(board);

            Random rnd = new Random();
            int jailChange = rnd.Next(1, 11);

            if (behaviour.prefersJail(this) && jailChange > 5)
            {
                Console.WriteLine($"{GetName()} leek het een beter idee om vrijwillig naar de gevangenis te gaan.");
                this.SendToJail(board);
                return;
            }

            if(behaviour.wantsToRush(this))
            {
                base.ThrowDice(board, alreadyThrown);
                Console.WriteLine($"{GetName()} gooide stiekem nog een keer.");
                base.ThrowDice(board, alreadyThrown);
                return;
            }

            base.ThrowDice(board, alreadyThrown);
        }

        public override void GiveMoneyTo(Board board, int value, PlayerObject otherPlayer)
        {
            bool accepts = behaviour.acceptsTransactions(this);

            if (accepts) 
            {
                base.GiveMoneyTo(board, value, otherPlayer);
            }
            else
            {
                Console.WriteLine($"{GetName()} weigerde te betalen aan {otherPlayer.GetName()}.");
            }
        }

        public override void GiveMoneyToBank(Board board, int value) {
            bool accepts = behaviour.acceptsTransactions(this);

            if (accepts)
            {
                base.GiveMoneyToBank(board, value);
            }
            else
            {
                Console.WriteLine($"{GetName()} weigerde te betalen aan de bank.");
            }
        }

        public void BuyCurrentTile(Board board)
        {
            bool accepts = behaviour.acceptsTransactions(this);

            if (accepts) 
            {
                base.BuyCurrentTile(board);
            }
        }

    }
}
