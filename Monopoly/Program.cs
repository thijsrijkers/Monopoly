using Monopoly;
using System;

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

            Console.WriteLine(town.getPrice());
            Console.WriteLine(town.getAmountOfHouses());
            Console.WriteLine(town.hasHotel());
        }
    }
}
