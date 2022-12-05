using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Floortile : Tile
    {
        public Floortile(Coordinate coord) : base(coord)
        {
            defaultId = '.';
            base.Id = defaultId;
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
    }
}
