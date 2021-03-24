using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;

namespace Monopoly.Player
{
    public abstract class PlayerObject
    {
        private Tile position;
        private PawnFigure pawn;
        private BehaviourType behaviour;
        private int money;

        public PlayerObject(Tile positionValue, PawnFigure pawnValue, BehaviourType behaviourValue, int moneyValue)
        {
            this.position = positionValue;
            this.pawn = pawnValue;
            this.behaviour = behaviourValue;
            this.money = moneyValue;
        }

        public void GiveMoneyToBank(int value)
        {
            if (this.money >= value)
            {
                this.money -= value;
                //TODO wait for implementation of the bank aka the board class with a singleton
            }
        }

        public void ReceiveMoney(int value)
        {
            this.money += value;
        }

        public void GiveMoneyTo(int value, PlayerObject otherPlayer)
        {
            if(this.money >= value)
            {
                this.money -= value;
                otherPlayer.ReceiveMoney(value);
                return;
            }
            //TODO discuss a implementation for the else clause
        }

        public void ExecuteTile()
        {
            //TODO Wait for implementation of execute function of tiles;
        }

        public void SetTile(Tile value)
        {
            this.position = value;
        }
    }
}
