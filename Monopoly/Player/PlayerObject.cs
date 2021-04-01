using Monopoly.Command.Commands;
using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using Monopoly.Tiles;
using Monopoly.Tiles.Variants;
using System;
using System.Linq;

namespace Monopoly.Player
{
    public abstract class PlayerObject
    {
        private Tile position;
        private PawnFigure pawn;
        private int money;
        private bool jailed = false;
        private string name;
        private const int MONEYCAP = 2000;

        public PlayerObject(PawnFigure pawnValue, int moneyValue, string name)
        {
            this.pawn = pawnValue;
            this.money = moneyValue;
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Gives money to the invisible bank, if you die you are removed from the game
        /// </summary>
        /// <param name="board">The board</param>
        /// <param name="value">The amount of money needed from you</param>
        public virtual void GiveMoneyToBank(int value) => giveMoneyToBank(value);
        internal void giveMoneyToBank(int value)
        {
            if (this.money >= value)
            {
                this.money -= value;
                return;
            }
        }

        public virtual void ReceiveMoney(int value) => receiveMoney(value);
        internal void receiveMoney(int value)
        {
            if (this.money < MONEYCAP)
            {
                this.money += value;
            }
        }

        /// <summary>
        /// Gives money to another player, if you die you give all your money to the other player and your removed from the game
        /// </summary>
        /// <param name="board">The board</param>
        /// <param name="value">The amount of money needed from you</param>
        /// <param name="otherPlayer">The other player</param>
        public virtual void GiveMoneyTo(int value, PlayerObject otherPlayer) => giveMoneyTo(value, otherPlayer);
        internal void giveMoneyTo(int value, PlayerObject otherPlayer)
        {
            if (this.money >= value)
            {
                this.money -= value;
                otherPlayer.ReceiveMoney(value);
                return;
            }
            otherPlayer.ReceiveMoney(this.money);
        }

        public virtual void ExecuteTile(Board value)
        {
            position.ExecuteStand(value, this);
        }

        public virtual void SetTile(Tile value)
        {
            this.position = value;
        }

        public virtual void Move(Board board, int steps)
        {
            int index = board.GetTiles().FindIndex(a => a == GetPosition());

            //Dice throw
            int amount = index - steps;

            if (amount <= 0)
            {
                amount += board.GetTiles().Count;
            }
            else if (amount >= board.GetTiles().Count)
            {
                amount -= board.GetTiles().Count;
                ReceiveMoney(200);
            }

            SetTile(board.GetTiles()[amount]);

            GetPosition().ExecuteStand(board, this);
        }

        public Tile GetPosition()
        {
            return position;
        }

        public int GetMoney()
        {
            return this.money;
        }

        public void SetMoney(int amount)
        {
            this.money = amount;
        }

        public virtual void ThrowDice(Board board, int alreadyThrown)
        {
            throwDice(board, alreadyThrown);
        }

        internal void throwDice(Board board, int alreadyThrown)
        {
            if (!jailed)
            {
                int throwCounter = alreadyThrown;

                Random rnd = new Random();

                int diceOne = rnd.Next(1, 7);
                int diceTwo = rnd.Next(1, 7);

                Console.WriteLine($"{GetName()} gooide {diceOne} en {diceTwo}.");

                throwCounter++;

                int index = board.GetTiles().FindIndex(a => a == GetPosition());

                //Dice throw
                int amount = index + diceOne + diceTwo;
                while(amount >= board.GetTiles().Count) // Imagine, you can magically throw enough to pass start multiple times
                {
                    Console.WriteLine($"{GetName()} kwam langs start en kreeg 200 euro.");
                    if(money < MONEYCAP)
                    {
                        money += 200;
                    }
                    amount -= board.GetTiles().Count;
                }

                SetTile(board.GetTiles()[amount]);


                if (diceOne != diceTwo)
                {
                    GetPosition().ExecuteStand(board, this);
                    return;
                }

                if (throwCounter > 2)
                {
                    SendToJail(board);
                    return;
                }

                GetPosition().ExecuteStand(board, this);
                ThrowDice(board, throwCounter);
            }
            jailed = false;
        }

        public void SendToJail(Board board)
        {
            SetTile(board.GetTiles().First(x => x.GetType() == typeof(JailTile)));
            jailed = true;
        }

        public virtual void BuyCurrentTile(Board board) => buyCurrentTile(board);
        internal void buyCurrentTile(Board board)
        {
            Buildable position = (Buildable)this.GetPosition();
            int price = position.getPrice();

            if (this.money >= price)
            {
                Console.WriteLine($"{GetName()} heeft {this.GetPosition().getName()} gekocht.");
                this.money -= price;
                position = new Owned(position);
                position.SetOwner(this);

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
                Console.WriteLine($"{GetName()} probeerde {position.getName()} te kopen, maar had niet genoeg geld.");
            }
        }
    }
}
