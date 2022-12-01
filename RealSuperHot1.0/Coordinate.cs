using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Coordinate
    {
        int x, y;

        public Coordinate (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinate(Coordinate other)
            => CopyFrom(other);

        public Coordinate(Coordinate other, Direction direction) : this(other)
            => IncrementCoordinate(direction);
            
        


        public void CopyFrom(Coordinate other)
        {
            this.x = other.x;
            this.y = other.y;
        }

        public bool Compare(Coordinate other)
            =>  (x, y) == (other.x, other.y);
        
        public void IncrementCoordinate(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                default:
                    throw new Exception("Increment Coordinate got an invalid direction");
            }
        }
    }
}
