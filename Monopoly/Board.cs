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
        private Cardlist chance;
        private Cardlist communityChest;

        public Board()
        {
            tiles = new List<Tile>();
            players = new Queue<PlayerObject>();
            this.chance = new Cardlist();
            this.communityChest = new Cardlist();
        }

        public void UpdateTile(Buildable tile)
        {
            // Update tile in list
            Tile old = tiles.First(x => x.getName() == tile.getName());
            int index = tiles.IndexOf(old);
            tiles[index] = (Tile)tile;

            // update tile for players that are on this tile.
            List<PlayerObject> players = this.players.ToList();
            players.Add(tile.GetOwner()); // Owner is at this moment not in the queue.
            foreach(PlayerObject player in players)
            {
                if (player.GetPosition() == old)
                    player.SetTile((Tile)tile);
            }
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

        public bool NextTurn()
        {
            PlayerObject currentPlayer = players.Dequeue();
            if (players.Count() == 0)
            {
                Console.WriteLine($"{currentPlayer.GetName()} heeft gewonnen.");
                return false;
            }
            else
            {
                currentPlayer.ThrowDice(this, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;

                string housesHotels = "";
                var tile = currentPlayer.GetPosition();
                if (tile.GetType().IsAssignableTo(typeof(Buildable)))
                {
                    var buildable = (Buildable)tile;
                    housesHotels = $", houses: {buildable.getAmountOfHouses()} hotel: {buildable.hasHotel()}";
                }

                Console.WriteLine($"{currentPlayer.GetName()}: {currentPlayer.GetPosition().getName()}, {currentPlayer.GetMoney()} euro{housesHotels}");
                Console.ResetColor();
            }

            if (currentPlayer.GetMoney() > 0)
                AddPlayer(currentPlayer);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{currentPlayer.GetName()} is blut, dus doet niet meer mee.");
                List<Buildable> buildables = tiles.Where(x => x.GetType().IsAssignableTo(typeof(Buildable))).Cast<Buildable>().ToList();
                buildables = buildables.Where(x => x.GetOwner() == currentPlayer).ToList();
                Console.WriteLine($"De volgende towns zijn vrij gekomen: {string.Join(", ", buildables.Select(x => x.getName()))}");
                // Update tiles owned by this player to become regular towns again.
                foreach(var buildable in buildables)
                {
                    UpdateTile(buildable.GetTown());
                }
                Console.ResetColor();
            }
            Console.WriteLine();
            return true;
        }
    }
}
