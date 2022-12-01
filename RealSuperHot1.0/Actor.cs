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
        Coordinate PotentialMove;

        Direction direction = Direction.Up;
        int hp; 

        public Actor(IActionComponent action, Coordinate coord, int hp, char id)
        {
            this.action = action;
            this.hp = hp;
            this.Id = id;
            this.ActorCoordinate = coord;
            PotentialMove = new Coordinate(ActorCoordinate);
        }

        public void Move(Tile[] map, Direction direction)
        {
            if (this.direction != direction)
            {
                this.direction = direction;
            }
            else

            {
                bool collision = false;
                PotentialMove.IncrementCoordinate(direction);

                //if (!collision)
                //{
                //    foreach (monster in monster)
                //    {
                //        if(Monster.Coord == temppos)
                //        {
                //            collision = true;
                //            break;
                //        }
                //    }
                //}

                if (!collision)
                {
                    foreach (Tile tile in map)
                    {
                        if (tile.Coord.Compare(PotentialMove))
                        {
                            if (!tile.Passable)
                            {
                                collision = true;
                                break;
                            }                          
                        }
                    }
                }


                if (collision)
                    ActorCoordinate.CopyFrom(PotentialMove);
                else
                    PotentialMove.CopyFrom(ActorCoordinate);
            }
            
        }

    }
}
