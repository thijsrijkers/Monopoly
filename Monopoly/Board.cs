using Monopoly.Player;
using System;
using System.Collections.Generic;

namespace Monopoly
{
    public partial class Board
    {
        private List<Tile> tiles;
        private Queue<PlayerObject> players;
        public PlayerObject current;

        public Board()
        {
            tiles = new List<Tile>();
            players = new Queue<PlayerObject>();
        }

        public List<Tile> GetTiles()
        {
            return tiles;
        }

        public void TransactionPlayer(PlayerObject fromPlayer, PlayerObject ToPlayer, int amount)
        {
        }

        public void TransactionToAllPlayers(PlayerObject value)
        {

        }

        public void TransactionToBank(PlayerObject value)
        {

        }

        public void AddTile(Tile value)
        {
            this.tiles.Add(value);
        }

        public void RemoveTile(Tile value)
        {
            this.tiles.Remove(value);
        }

        public void AddPlayer(PlayerObject value)
        {
            players.Enqueue(value);
        }

        public void RemovePlayer(PlayerObject value)
        {
            players.Dequeue();
        }

        public void DiceThrow(int value = 0)
        {
            int throwCounter = value;

            Random rnd = new Random();

            int diceOne = rnd.Next(0, 6);
            int diceTwo = rnd.Next(0, 6);

            throwCounter++;

            PlayerObject currentPlayer = players.Peek();
            Tile playerTile = currentPlayer.GetPosition();

            int index = GetTiles().FindIndex(a => a == currentPlayer.GetPosition());

            //Dice throw
            int amount = index + diceOne + diceTwo;
            int result = amount > tiles.Count ? amount - tiles.Count : amount;

            Console.WriteLine(diceOne + " + " + diceTwo + " = " + amount + ",  " +  result);

            currentPlayer.SetTile(tiles[result]);


            if (diceOne != diceTwo)
            {
                //this.RemovePlayer(currentPlayer);
                //this.AddPlayer(currentPlayer);

                currentPlayer.GetPosition().ExecuteStand(this, currentPlayer);
                return;
            }

            if (throwCounter > 3)
            {
                //TODO Ref the jail tile in the SetTile function
                currentPlayer.SetTile(GetTiles()[0]);
                return;
            }

            currentPlayer.GetPosition().ExecuteStand(this, currentPlayer);
            DiceThrow(throwCounter);
        }
    }
}
