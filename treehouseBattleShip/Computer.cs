using System;
using System.Collections.Generic;
using System.Text;

namespace treehouseBattleShip
{
    class Computer
    {
        public int ComputerXAxis;
        public int ComputerYAxis;
        public int ComputerXAxisToFire;
        public int ComputerYAxisToFire;

        public void ComputerCoordinates()
        {
            Random random = new Random();
            ComputerXAxis = random.Next(6); //x coordinate value between 0 and 5
            ComputerYAxis = random.Next(6);
        }

        public void GetComputerToFire()
        {
            Random random = new Random();
            ComputerXAxisToFire = random.Next(6); //x coordinate value between 0 and 5
            ComputerYAxisToFire = random.Next(6);
        }
    }
}
