﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Walltile : Tile
    {
        public Walltile(Coordinate coord) : base(coord)
        {
            base.Id = '#';
            base.Passable = false;
        }

        public override void Attacked(Direction direction)
        {
            Id = 'x';
        }

        public override void ResetId()
        {
            Id = '#';
        }
    }
}
