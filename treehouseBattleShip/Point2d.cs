using System;
using System.Collections.Generic;
using System.Text;

namespace treehouseBattleShip
{
    class Point2d
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2d(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool Equals(Point2d obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return (this.X == obj.X && this.Y == obj.Y);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
