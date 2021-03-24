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

        /// <summary>
        /// Gives money to the invisible bank, if you die you are removed from the game
        /// </summary>
        /// <param name="board">The board</param>
        /// <param name="value">The amount of money needed from you</param>
        public virtual void GiveMoneyToBank(Board board, int value)
        {
            if (this.money >= value)
            {
                this.money -= value;
                return;
            }

            board.RemovePlayer(this);
        }

        public virtual void ReceiveMoney(int value)
        {
            this.money += value;
        }

        /// <summary>
        /// Gives money to another player, if you die you give all your money to the other player and your removed from the game
        /// </summary>
        /// <param name="board">The board</param>
        /// <param name="value">The amount of money needed from you</param>
        /// <param name="otherPlayer">The other player</param>
        public virtual void GiveMoneyTo(Board board, int value, PlayerObject otherPlayer)
        {
            if(this.money >= value)
            {
                this.money -= value;
                otherPlayer.ReceiveMoney(value);
                return;
            }
            otherPlayer.ReceiveMoney(this.money);
            board.RemovePlayer(this);
        }

        public virtual void ExecuteTile(Board value)
        {
            position.ExecuteStand(value, this);
        }

        public virtual void SetTile(Tile value)
        {
            this.position = value;
        }

        public Tile GetPosition()
        {
            return position;
        }
    }
}
