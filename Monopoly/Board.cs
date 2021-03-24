using Monopoly.Player;
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

        public void DiceThrow()
        {

        }
    }
}
