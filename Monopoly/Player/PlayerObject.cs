using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;

namespace Monopoly.Player
{
    public abstract class PlayerObject
    {
        private Tile position;
        private PawnFigure pawn;
        private int money;

        public PlayerObject(Tile positionValue, PawnFigure pawnValue, int moneyValue)
        {
            this.position = positionValue;
            this.pawn = pawnValue;
            this.money = moneyValue;
        }

        public virtual void GiveMoneyToBank(int value)
        {
            if (this.money >= value)
            {
                this.money -= value;
                //TODO wait for implementation of the bank aka the board class with a singleton
            }
        }

        public virtual void ReceiveMoney(int value)
        {
            this.money += value;
        }

        public virtual void GiveMoneyTo(int value, PlayerObject otherPlayer)
        {
            if(this.money >= value)
            {
                this.money -= value;
                otherPlayer.ReceiveMoney(value);
                return;
            }
            //TODO discuss a implementation for the else clause
        }

        public virtual void ExecuteTile()
        {
            //TODO Wait for implementation of execute function of tiles;
        }

        public virtual void SetTile(Tile value)
        {
            this.position = value;
        }
    }
}
