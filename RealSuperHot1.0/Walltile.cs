using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Walltile : Tile
    {
        
        public Walltile(Coordinate coord) : base(coord)
        {
            base.defaultId = '#';
            base.Id = defaultId;
        }

        public override void Attacked(Direction direction)
        {
            Id = 'x';
        }
    }
}
