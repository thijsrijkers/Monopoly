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

        public NPCPlayer(Tile positionValue, PawnFigure pawnValue, int moneyValue) : base(positionValue, pawnValue, moneyValue)
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

        public void ToggleBehaviour()
        {
            
        }

        public override void ThrowDice(Board board, int alreadyThrown)
        {
            SwitchBehaviour(board);

            Random rnd = new Random();
            int jailChange = rnd.Next(1, 11);

            if (behaviour.prefersJail(this) && jailChange > 5)
            {
                this.SendToJail(board);
                return;
            }

            if(behaviour.wantsToRush(this))
            {
                base.ThrowDice(board, 0);
                base.ThrowDice(board, 0);
                return;
            }

            base.ThrowDice(board, 0);
        }

        public override void GiveMoneyTo(Board board, int value, PlayerObject otherPlayer)
        {
            bool accepts = behaviour.acceptsTransactions(this);

            if (accepts) 
            {
                base.GiveMoneyTo(board, value, otherPlayer);
            }
        }

        public override void GiveMoneyToBank(Board board, int value) {
            bool accepts = behaviour.acceptsTransactions(this);

            if (accepts)
            {
                base.GiveMoneyToBank(board, value);
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
