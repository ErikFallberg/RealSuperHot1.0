using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class Actor
    {
        public char Id { get; private set; }
        
        IActionComponent action;

        public Coordinate ActorCoordinate { get; private set; }
        public Coordinate tempCoordinate;

        Direction direction = Direction.Up;
        int hp; 





        public Actor(IActionComponent action, Coordinate coord, int hp, char id)
        {
            this.action = action;
            this.hp = hp;
            this.Id = id;
            this.ActorCoordinate = coord;
            tempCoordinate = new Coordinate(ActorCoordinate);
        }


        //public Item Attack() // Attack cant return item cause it fucks with showmap // CONTINUE HERE. Instead i think it should change the tile, and after tile is shown it changes back. 
        //{
        //    Coordinate coord = new Coordinate(ActorCoordinate, direction);
        //    if (direction == Direction.Left || direction == Direction.Right)
        //        return new Item(coord, '-');
        //    else if (direction == Direction.Up || direction == Direction.Down)
        //        return new Item(coord, '|');
        //    else
        //        throw new Exception("Attack took an invalid Direction.");
        //}
            
         public void Attack(Tile[] map)
         {
              
         }



        public bool TakeInput(out Direction direction)
             => action.TakeInput(out direction);
        
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

        public Coordinate GetCoordinate()
        {
            tempCoordinate.IncrementCoordinate(direction);
            return tempCoordinate;
        }

        public void Move(bool check)
        {
            if (!check)
                ActorCoordinate.CopyFrom(tempCoordinate);
            else
                tempCoordinate.CopyFrom(ActorCoordinate);
        }
             
        
            
        

    }
}
