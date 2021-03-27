using Monopoly;
using Monopoly.Player;
using Monopoly.Player.Behaviour;
using Monopoly.Player.Pawn;
using Monopoly.Tiles.Variants;
using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Gevangenis
            //Bouwbaar
            //Stations
            //Electriciteitbedrijven
            //kans
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

            board.AddPlayer(new NPCPlayer(board.GetTiles()[0], shipFigure, 1000));
            board.AddPlayer(new NPCPlayer(board.GetTiles()[0], shoeFigure, 1000));

            ///Player
            PawnFigure playerFigure = new PawnFigure(bramShape, gold);
            HumanPlayer player = new HumanPlayer(board.GetTiles()[0], playerFigure, 1000);
        
            for(int i = 0; i < board.GetTiles().Count; i++)
            {
                Console.WriteLine(board.GetTiles()[i]);
            }

            board.AddPlayer(player);
        }
    }
}
