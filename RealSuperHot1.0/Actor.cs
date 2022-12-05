using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Actor
    {
        IInputComponent inputComponent;
        Coordinate tempCoordinate;
        Direction direction = Direction.Up;

        public char Id { get; private set; }
        public int Hp { get; set; }
        public Coordinate ActorCoordinate { get; private set; }

        public Actor(IInputComponent inputComponent, Coordinate coord, int hp, char id)
        {
            this.inputComponent = inputComponent;
            this.Hp = hp;
            this.Id = id;
            this.ActorCoordinate = coord;
            tempCoordinate = new Coordinate(ActorCoordinate);
        }
            
        public int Attack(World world)
        {
            int kills = 0;
            tempCoordinate.IncrementCoordinate(direction);
            if (world.ActorCollision(tempCoordinate, out Actor target))
            {
                target.Hp--;
                kills++;
            }
            try
            {
                world.FindTile(tempCoordinate).Attacked(direction);
            }
            catch
            {
                CancelMove();
            }
            CancelMove();
            return kills;
        }
        public void Move(World world, Direction movedirection)
        {
            if (!CheckDirection(movedirection))
                return;
            else
            {
                tempCoordinate.IncrementCoordinate(movedirection);
                    if (world.WallCollision(tempCoordinate) || world.ActorCollision(tempCoordinate))
                    CancelMove();
                else
                    PerformMove();
            }
        }

        public bool TakeInput(out Direction direction)
             => inputComponent.TakeInput(out direction);
        
        public bool CheckDirection(Direction direction)
        {
            if (direction == Direction.Up || direction == Direction.Down || direction == Direction.Left || direction == Direction.Right)
            {
                if (this.direction != direction) 
                {
                    this.direction = direction;
                    return false;
                }

                return true;
            }
            return false;
        }

        public void PerformMove()
        {
             ActorCoordinate.CopyFrom(tempCoordinate);
        }
             
        public void CancelMove()
        {
            tempCoordinate.CopyFrom(ActorCoordinate);
        }
    }
}
