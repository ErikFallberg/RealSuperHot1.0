using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class World
    {
        Tile[] map;
        int size = 20;

        //?
        Actor[] allActors;  // temp
        // Item[] items;
        // Attack[] attacks; could maybe be attacks. 
        // Actor allcharacters;



        public World (Tile[] map, Actor[] allActors)
        {
            this.map = map;
            this.allActors = allActors;
        }


        public bool CheckCollision(Coordinate coord) // ACTIONCOMPONENT?
        {
            foreach (Tile tile in map)
            {
                if (coord.Compare(tile.Coord))
                    if (tile is Walltile)
                        return true;
            }
            foreach (Actor actor in allActors)
            {
                if (coord.Compare(actor.ActorCoordinate))
                    return true;    
            }
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
                            index++;
                            check = false;
                            break;
                        }
                    
                    if (check)
                    {
                        Console.Write(map[index].Id);
                        index++;
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
