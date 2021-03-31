using Monopoly.Card;
using Monopoly.Player;
using Monopoly.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public partial class Board
    {
        private List<Tile> tiles;
        private Queue<PlayerObject> players;
        public PlayerObject current;
        private Cardlist chance;
        private Cardlist communityChest;

        public Board()
        {
            tiles = new List<Tile>();
            players = new Queue<PlayerObject>();
            this.chance = new Cardlist();
            this.communityChest = new Cardlist();
        }

        public void AddChanceCard(CardObject card)
        {
            chance.AddCard(card);
        }

        public void AddCommunityChestCard(CardObject card)
        {
            communityChest.AddCard(card);
        }

        public void ShuffleCards()
        {
            chance.Shuffle();
            communityChest.Shuffle();
        }

        public CardObject DrawChanceCard() => chance.DrawCard();

        public CardObject DrawCommunityChestCard() => communityChest.DrawCard();

        public List<Tile> GetTiles()
        {
            return tiles;
        }

        public int GetNumberOfOwnables(PlayerObject value)
        {
            int returnAmount = 0;

            foreach(Tile tile in tiles)
            {
                if (tile is Buildable)
                {
                    if(((Buildable)tile).GetOwner() == value)
                    {
                        returnAmount++;
                    }
                }
            }
            return returnAmount;
        }

        public void TransactionPlayer(PlayerObject fromPlayer, PlayerObject ToPlayer, int amount)
        {
        }

        public void TransactionToAllPlayers(PlayerObject value, int amount)
        {

        }

        public void TransactionToBank(PlayerObject value)
        {

        }

        public Queue<PlayerObject> GetPlayers()
        {
            return players;
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
            players = new Queue<PlayerObject>(players.Where(s => s != value));
        }

        public void NextTurn()
        {
            PlayerObject currentPlayer = players.Dequeue();
            currentPlayer.ThrowDice(this, 0);
            Console.WriteLine(currentPlayer + "  " + currentPlayer.GetPosition().Name);
            AddPlayer(currentPlayer);
        }
    }
}
