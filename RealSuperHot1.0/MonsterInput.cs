using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class MonsterInput : IInputComponent 
    {
        Coordinate self;
        Coordinate player;

        public MonsterInput(Coordinate self, Coordinate player)
        {
            this.self = self;
            this.player = player;
        }

        public bool TakeInput(out Direction direction)
        {

            Random rand = new Random();
            bool r = rand.Next(0, 2) == 0;

            if (self.DifferenceY(player) < 0 && self.DifferenceX(player) > 0)
                direction = (r ? Direction.Up : Direction.Right);
            else if (self.DifferenceY(player) < 0 && self.DifferenceX(player) < 0)
                direction = (r ? Direction.Up : Direction.Left);
            else if (self.DifferenceY(player) > 0 && self.DifferenceX(player) > 0)
                direction = (r ? Direction.Down : Direction.Right);
            else if (self.DifferenceY(player) > 0 && self.DifferenceX(player) < 0)
                direction = (r ? Direction.Down : Direction.Left);
            else if (self.DifferenceY(player) < 0)
                direction = Direction.Up;
            else if (self.DifferenceY(player) > 0)
                direction = Direction.Down;
            else if (self.DifferenceX(player) > 0)
                direction = Direction.Right;
            else
                direction = Direction.Left;           

            return false;
        }
    }
}
