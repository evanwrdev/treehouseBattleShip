using System;
using System.Collections.Generic;

namespace treehouseBattleShip
{
    class Program
    {
        const int mapSize = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to 1-Ship BattleShip.");

            Map map = new Map(mapSize);
            Player1 player1 = new Player1();
            Player2 player2 = new Player2();

            TwoPlayerOrOnePlayer twoPlayerOrOne = new TwoPlayerOrOnePlayer();
            bool IsTwoPlayerOrOne = twoPlayerOrOne.IsTwoPlayer();

            CoordinateInput coordinateInput = new CoordinateInput();

            if (IsTwoPlayerOrOne)
            {
                player1.Player1XAxis = coordinateInput.GetCoordinate(map.dimensions, "player 1", "X-axis", "player 2");
                player1.Player1YAxis = coordinateInput.GetCoordinate(map.dimensions, "player 1", "Y-axis", "player 2");

                player2.Player2XAxis = coordinateInput.GetCoordinate(map.dimensions, "player 2", "X-axis", "player 1");
                player2.Player2YAxis = coordinateInput.GetCoordinate(map.dimensions, "player 2", "Y-axis", "player 1");
            }
            else
            {
                player1.Player1XAxis = coordinateInput.GetCoordinateVsComputer(map.dimensions, "player 1", "X-axis");
                player1.Player1YAxis = coordinateInput.GetCoordinateVsComputer(map.dimensions, "player 1", "Y-axis");
            }

            //List<Ship> player1Ships = new List<Ship>();
            //player1Ships.Add(new Ship(player1.Player1XAxis, player1.Player1YAxis));
            Point2d player1Ship = new Point2d(player1.Player1XAxis, player1.Player1YAxis);
            Console.WriteLine("Player1's ship has been created a secret location.");

            //List<Ship> player2Ships = new List<Ship>();
            //player2Ships.Add(new Ship(player2.Player2XAxis, player2.Player2YAxis));
            Point2d player2Ship = new Point2d(player2.Player2XAxis, player2.Player2YAxis);

            Computer computer = new Computer();
            computer.ComputerCoordinates();
            //List<Ship> computerShips = new List<Ship>();
            //computerShips.Add(new Ship(computer.ComputerXAxis, computer.ComputerYAxis));
            Point2d computerShip = new Point2d(computer.ComputerXAxis, computer.ComputerYAxis);

            if (IsTwoPlayerOrOne)
            {
                Console.WriteLine("Player2's ship has been created at a secret location.");
            }
            else
            {
                Console.WriteLine("The computer's ship has been created at a secret location.");
            }

            if (IsTwoPlayerOrOne)
            {
                bool Player1Turn = true;
                bool Player2Turn = false;

                List<Point2d> player1FiredOn = new List<Point2d>();
                List<Point2d> player2FiredOn = new List<Point2d>();

                bool winConditionIsNotMet = true;

                while (winConditionIsNotMet)
                {
                    if (Player1Turn)
                    {
                        int Player1FireOnX = coordinateInput.GetCoordinateToFire(map.dimensions, "player1", "X-axis");
                        int Player1FireOnY = coordinateInput.GetCoordinateToFire(map.dimensions, "player1", "Y-axis");

                        Point2d firedOn = new Point2d(Player1FireOnX, Player1FireOnY);

                        foreach (Point2d firedOnPoint in player1FiredOn)
                        {
                            firedOn.Equals(firedOnPoint);
                            Console.WriteLine("You've shot here before!");
                        }

                        Console.WriteLine($"Player1 fired on {Player1FireOnX}, {Player1FireOnY}. POW!");
                        player1FiredOn.Add(firedOn);

                        if (player2Ship.Equals(firedOn))
                        {
                            Console.WriteLine("Player 1 shot up Player 2's ship and won!");
                            winConditionIsNotMet = false;
                            break;
                        }

                        Player1Turn = false;
                        Player2Turn = true;
                    }
                    if (Player2Turn)
                    {
                        int Player2FireOnX = coordinateInput.GetCoordinateToFire(map.dimensions, "player2", "X-axis");
                        int Player2FireOnY = coordinateInput.GetCoordinateToFire(map.dimensions, "player2", "Y-axis");

                        Point2d firedOn = new Point2d(Player2FireOnX, Player2FireOnY);

                        foreach (Point2d firedOnPoint in player1FiredOn)
                        {
                            firedOn.Equals(firedOnPoint);
                            Console.WriteLine("You've shot here before!");
                        }

                        player2FiredOn.Add(firedOn);

                        Console.WriteLine($"Player2 fired on {Player2FireOnX}, {Player2FireOnY}. POW!");

                        if (player1Ship.Equals(firedOn))
                        {
                            Console.WriteLine("Player 2 shot up Player 1's ship and won!");
                            winConditionIsNotMet = false;
                            break;
                        }

                        Player2Turn = false;
                        Player1Turn = true;
                    }
                }
            }
            else
            {
                bool Player1Turn = true;
                bool ComputerTurn = false;

                List<Point2d> player1FiredOn = new List<Point2d>();
                List<Point2d> computerFiredOn = new List<Point2d>();

                bool winConditionIsNotMet = true;

                while (winConditionIsNotMet)
                {
                    if (Player1Turn)
                    {
                        int Player1FireOnX = coordinateInput.GetCoordinateToFire(map.dimensions, "player1", "X-axis");
                        int Player1FireOnY = coordinateInput.GetCoordinateToFire(map.dimensions, "player1", "Y-axis");

                        Point2d firedOn = new Point2d(Player1FireOnX, Player1FireOnY);

                        foreach (Point2d firedOnPoint in player1FiredOn)
                        {
                            firedOn.Equals(firedOnPoint);
                            Console.WriteLine("You've shot here before!");
                        }

                        player1FiredOn.Add(firedOn);

                        Console.WriteLine($"Player has fired on {Player1FireOnX}, {Player1FireOnY}. POW!");

                        bool computerShipShipGotHit = computerShip.Equals(firedOn);
                        if (computerShipShipGotHit)
                        {
                            Console.WriteLine("You win! The computer's ship is sunk.");
                            winConditionIsNotMet = false;
                            break;
                        }

                        Player1Turn = false;
                        ComputerTurn = true;
                    }
                    if (ComputerTurn)
                    {
                        computer.GetComputerToFire();
                        int ComputerFireOnX = computer.ComputerXAxisToFire;
                        int ComputerFireOnY = computer.ComputerYAxisToFire;

                        Point2d firedOn = new Point2d(ComputerFireOnX, ComputerFireOnY);

                        foreach (Point2d firedOnPoint in computerFiredOn)
                        {
                            firedOn.Equals(firedOnPoint);
                            Console.WriteLine("You've shot here before!");
                        }

                        computerFiredOn.Add(firedOn);

                        Console.WriteLine($"Computer has fired on {ComputerFireOnX}, {ComputerFireOnY}. POW!");

                        bool player1ShipShipGotHit = player1Ship.Equals(firedOn);
                        if (player1ShipShipGotHit)
                        {
                            Console.WriteLine("You lose. The computer found and sank your ship.");
                            winConditionIsNotMet = false;
                            break;
                        }

                        ComputerTurn = false;
                        Player1Turn = true;
                    }
                }
            }
        }
    }
}
