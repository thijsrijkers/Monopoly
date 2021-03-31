using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Monopoly.Tiles.Variants;
using Monopoly.Card;
using Monopoly.Command.Commands;
using Monopoly.Player;

namespace Monopoly
{
    public partial class Board
    {
        public static Board Build(int housing, HumanPlayer player)
        {
            // build the board here
            Board board = new Board();

            // Add start tile so we can assign it to players
            Tile startTile = new StartTile();
            board.AddTile(startTile);

            // Generate tiles
            for (int i = 0; i < housing; i++)
            {
                var rng = new Random();
                Buildable tile = new Town(rng.Next(200, 2000));
                board.AddTile((Tile)tile);
            }

            player.SetTile(startTile);
            // Generate NPC players
            //TODO

            // Add cards // USE CLONE METHOD TO CREATE MULTIPLES
            // Get 400
            var card = new CardObject(new GetMoneyCommand(200), "Je hebt de loterij gewonnen. Gezien er bijna niemand mee deed is de jackpot maar 200 euro.");
            board.AddChanceCard(card);
            for(int i = 0; i < 4; i++)
                board.AddChanceCard(card.Clone());

            // Pay 200
            card = new CardObject(new PayCommand(400), "Bij het inparkeren heb je het paaltje van je buurman omgereden. Je buurman weet zeker dat deze 400 euro waard was. Betaal 400 euro.");
            board.AddChanceCard(card);
            for (int i = 0; i < 5; i++)
                board.AddChanceCard(card.Clone());

            // Go to jail
            card = new CardObject(new JailPlayer(), "Je bent betrapt op het illegaal downloaden van dubstep. Je gaat naar de gevangenis.");
            board.AddChanceCard(card);
            for (int i = 0; i < 3; i++)
                board.AddChanceCard(card.Clone());

            // Pay all players 20
            card = new CardObject(new PayAllCommand(20), "In een dronken bui heb je al je makkers 20 euro beloofd. Betaal alle spelers 20 euro.");
            board.AddChanceCard(card);
            for (int i = 0; i < 2; i++)
                board.AddChanceCard(card.Clone());

            // move back 3
            card = new CardObject(new MoveCommand(-3), "Je bent je sleutels kwijt geraakt. Je loopt 3 plaatsen terug om ze te zoeken.");
            board.AddChanceCard(card);
            for (int i = 0; i < 3; i++)
                board.AddChanceCard(card.Clone());

            // move forward 5
            card = new CardObject(new MoveCommand(5), "Een makker geeft je een lift. Hij zet je 5 plaatsen verder af.");
            board.AddChanceCard(card);
            for (int i = 0; i < 2; i++)
                board.AddChanceCard(card.Clone());

            // Add community chest cards
            // pay all 50
            card = new CardObject(new PayAllCommand(50), "In een gulle bui geef je alle spelers 50 euro.");
            board.AddCommunityChestCard(card);
            for (int i = 0; i < 5; i++)
                board.AddCommunityChestCard(card.Clone());

            // get 1 money
            card = new CardObject(new GetMoneyCommand(1), "Wow! je hebt een euro gevonden op straat.");
            board.AddCommunityChestCard(card);
            for (int i = 0; i < 8; i++)
                board.AddCommunityChestCard(card.Clone());

            // pay 1 money
            card = new CardObject(new PayCommand(1), "Je hebt honger. Je koopt een frikandel van de snackmuur.");
            board.AddCommunityChestCard(card);
            for (int i = 0; i < 5; i++)
                board.AddCommunityChestCard(card.Clone());

            // get another card
            card = new CardObject(new GetCommunityChestCard(), "Oeps, deze kaart doet niks. Pak dr nog maar een.");
            board.AddCommunityChestCard(card);
            for (int i = 0; i < 1; i++)
                board.AddCommunityChestCard(card.Clone());

            // get 1500 money
            card = new CardObject(new GetMoneyCommand(1500), "Ding dong! je hebt de jackpot gewonnen. Deze keer doen er wel vele mensen mee dus de jackpot is 1500!");
            board.AddCommunityChestCard(card);

            // pay 600 money
            card = new CardObject(new PayCommand(600), "Oei! je staat verkeerd geparkeerd. Je krijgt een boeten van 600 euro.");
            board.AddCommunityChestCard(card);
            for (int i = 0; i < 2; i++)
                board.AddCommunityChestCard(card.Clone());

            // get 500 money
            card = new CardObject(new GetMoneyCommand(500), "Yes!! Je krijgt 500 euro terug door je belastingaangifte!");
            board.AddCommunityChestCard(card);
            for (int i = 0; i < 10; i++)
                board.AddCommunityChestCard(card.Clone());

            // Shuffle cards
            board.ShuffleCards();

            // Create more tiles

            return board;
        }
    }
}
