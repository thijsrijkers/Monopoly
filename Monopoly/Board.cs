using Monopoly.Player;
using System.Collections.Generic;

namespace Monopoly
{
    public class Board
    {
        private List<Tile> tiles;
        private Queue<PlayerObject> players;
        public PlayerObject current;

        public void TransactionPlayer(PlayerObject fromPlayer, PlayerObject ToPlayer)
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

        }

        public void RemoveTile(Tile value)
        {

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
