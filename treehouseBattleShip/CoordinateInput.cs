using System;
using System.Collections.Generic;
using System.Text;

namespace treehouseBattleShip
{
    public class CoordinateInput
    {
        public int GetCoordinate(int dimensions, string player, string axis, string otherPlayer)
        {
            Console.WriteLine($"{player}, on a {dimensions} by {dimensions} grid, where would you like to place your battleship on the {axis}? {otherPlayer} DONT LOOK!");
            string userInputStr = Console.ReadLine();
            int userInput = Convert.ToInt32(userInputStr);
            if (CoordinateNotOnMap(userInput, dimensions))
            {
                Console.WriteLine("I'm sorry! Your choice was not on the board!");
                return GetCoordinate(dimensions, player, axis, otherPlayer);
            }
            else
            {
                return userInput;
            }
        }

        public int GetCoordinateVsComputer(int dimensions, string player, string axis)
        {
            Console.WriteLine($"{player}, on a {dimensions} by {dimensions} grid, where would you like to place your battleship on the {axis}?");
            string userInputStr = Console.ReadLine();
            int userInput = Convert.ToInt32(userInputStr);
            if (CoordinateNotOnMap(userInput, dimensions))
            {
                Console.WriteLine("I'm sorry! Your choice was not on the board!");
                return GetCoordinateVsComputer(dimensions, player, axis);
            }
            else
            {
                return userInput;
            }
        }


        public int GetCoordinateToFire(int dimensions, string player, string axis)
        {
            Console.WriteLine($"{player}, on a {dimensions} by {dimensions} grid, where would you like to fire on the {axis}?");
            string userInputStr = Console.ReadLine();
            int userInput = Convert.ToInt32(userInputStr);
            if (CoordinateNotOnMap(userInput, dimensions))
            {
                Console.WriteLine("I'm sorry! Your choice was not on the board!");
                return GetCoordinateToFire(dimensions, player, axis);
            }
            else
            {
                return userInput;
            }
        }



        public bool CoordinateNotOnMap(int Coordinate, int dimensions)
        {
            return Coordinate > dimensions || Coordinate < 0;
        }
    }
}
