﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Item : Tile
    {
        public Item(Coordinate coord, char id) : base(coord)
        {
            this.Id = id;
        }

        public override void Attacked(Direction direction)
        {
            throw new NotImplementedException();
        }

        public override void ResetId()
        {
            throw new NotImplementedException();
        }
    }
}
