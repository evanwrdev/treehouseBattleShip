using System;
using System.Collections.Generic;
using System.Text;

namespace treehouseBattleShip
{
    class TwoPlayerOrOnePlayer
    {
        public bool IsTwoPlayer()
        {
            try
            {
                Console.WriteLine($"Welcome to two player BattleShip. (true/false) Are you playing two player?");
                string userInput1 = Console.ReadLine();
                bool BooleanUserInput = Convert.ToBoolean(userInput1);
                return BooleanUserInput;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("I'm sorry! Please type either true or false all lower case.");
                return IsTwoPlayer();
            }
        }
    }
}
