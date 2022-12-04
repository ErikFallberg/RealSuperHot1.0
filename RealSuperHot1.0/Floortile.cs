using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Floortile : Tile
    {
        public Floortile(Coordinate coord) : base(coord)
        {
            base.Id = '.';
            base.Passable = true;
        }

        public override void Attacked(Direction direction)
        {
            if (direction == Direction.Right || direction == Direction.Left)
            {
                Id = '-';
            }
            else
            {
                Id = '|';
            }
        }

        public override void ResetId()
        {
            Id = '.';
        }
    }
}
