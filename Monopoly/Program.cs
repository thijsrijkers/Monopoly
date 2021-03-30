﻿using Monopoly;
using Monopoly.Card;
using Monopoly.Command.Commands;
using Monopoly.Player;
using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using Monopoly.Tiles.Variants;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Monopoly.Test")] // Ensure internals are visible to test project

namespace Monopoly
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Start
            //Gevangenis
            //GoToJail
            //kans
            //Algemeen fonds
            //belasting
            //Free parking

            Buildable town = new Town(10);
            town = new HouseBuilt(town);
            town = new HouseBuilt(town);
            town = new HouseBuilt(town);
            town = new HouseBuilt(town);
            town = new HotelBuilt(town); //Hotel 

            //Console.WriteLine(town.getPrice());
            //Console.WriteLine(town.getAmountOfHouses());
            //Console.WriteLine(town.hasHotel());















            ///Creation of materials and shapes
            Material gold = new Gold();
            Material plastic = new Plastic();
            Material wood = new Wood();

            PawnShape bramShape = PawnShape.BramShape;
            PawnShape shoe = PawnShape.Shoe;
            PawnShape ship = PawnShape.Battleship;

            PawnFigure shipFigure = new PawnFigure(ship, plastic);
            PawnFigure shoeFigure = new PawnFigure(shoe, wood);

            ///Creation of board
            Board board = Board.Build(15);

            AggressiveBehaviour boos = new AggressiveBehaviour();
            NPCPlayer bozeman = new NPCPlayer(board.GetTiles()[0], shipFigure, 1000);
            bozeman.SwitchBehaviour(boos);
            board.AddPlayer(bozeman);

            //board.AddPlayer(new NPCPlayer(board.GetTiles()[0], shipFigure, 1000));
            //board.AddPlayer(new NPCPlayer(board.GetTiles()[0], shoeFigure, 1000));

            ///Player
            PawnFigure playerFigure = new PawnFigure(bramShape, gold);
            HumanPlayer humanPlayer = new HumanPlayer(board.GetTiles()[0], playerFigure, 1000);

            //for(int i = 0; i < board.GetTiles().Count; i++)
            //{
            //    Console.WriteLine(board.GetTiles()[i]);
            //}

            board.AddPlayer(humanPlayer);

            Console.WriteLine(humanPlayer.GetPosition());

            board.NextTurn();
            board.NextTurn();
            board.NextTurn();

            Console.WriteLine(humanPlayer.GetPosition());

            //Console.WriteLine(board.GetNumberOfOwnables(player));







            Cardlist fundCards = new Cardlist();
            JailPlayer jailPlayerCommand = new JailPlayer();
            CardObject card = new CardObject(jailPlayerCommand);

            fundCards.AddCard(card);

            Cardlist chanceCards = (Cardlist)fundCards.Clone();

            fundCards.RemoveCard(card);
        }
    }
}
