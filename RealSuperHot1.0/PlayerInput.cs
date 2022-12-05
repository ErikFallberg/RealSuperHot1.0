using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class PlayerInput : IInputComponent
    {
        public bool TakeInput(out Direction direction)
        {
            ConsoleKey input = Console.ReadKey().Key;

            direction = (Direction)input;

            return input == ConsoleKey.Spacebar;
        }
    }
}
