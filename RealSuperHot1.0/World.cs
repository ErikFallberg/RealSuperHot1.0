using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class World
    {
        Tile[] map;
        int size = 20;
        Actor player;
        List<Actor> allActors;  // temp
        // Item[] items;
        // Attack[] attacks; could maybe be attacks. 
        // Actor allcharacters;



        public World (Tile[] map, List<Actor> allActors)
        {
            this.map = map;
            this.allActors = allActors;
            player = allActors[0];
        }


        public bool WallCollision(Coordinate coord) // ACTIONCOMPONENT?
        {
            foreach (Tile tile in map)
            {
                if (coord.Compare(tile.Coord))
                    if (tile is Walltile)
                        return true;
            }
            return false;
        }

        public Tile FindTile(Coordinate coord)
        {
            foreach (Tile tile in map)
            {
                if (coord.Compare(tile.Coord))
                    return tile;
            }
            throw new Exception("FindTile got a bad Coordinate!!!");
        }

        public bool ActorCollision(Coordinate coord) // ACTIONCOMPONENT?
        {
            foreach (Actor actor in allActors)
            {
                if (coord.Compare(actor.ActorCoordinate))
                {
                    if (actor == player)
                        actor.Hp--;
                    return true;
                }
            }
            return false;
        }

        public bool ActorCollision(Coordinate coord, out Actor target) // ACTIONCOMPONENT?
        {
            foreach (Actor actor in allActors)
            {
                if (coord.Compare(actor.ActorCoordinate))
                {
                    target = actor;
                    return true;
                }
            }
            target = null;
            return false;
        }

        public void ShowMap()
        {
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    bool check = true;
                    //if (attack != null && map[index].Coord.Compare(attack.Coord))
                    //{
                    //    Console.Write(attack.Id);
                    //    index++;
                    //    check = false;
                    //}
                    if (check)
                    foreach (Actor actor in allActors)
                        if (map[index].Coord.Compare(actor.ActorCoordinate))
                        {
                            Console.Write(actor.Id);
                            check = false;
                            break;
                        }
                    
                    if (check)
                    {
                        Console.Write(map[index].Id);
                    }
                    map[index].ResetId();
                    index++;
                }
                Console.WriteLine();
            }
        }
    }
}
