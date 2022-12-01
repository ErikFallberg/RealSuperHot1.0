using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    class World
    {
        Tile[] map;
        Actor player;

        public World (Tile[] map, Actor player)
        {
            this.map = map;
            this.player = player;

        }



        public void ShowMap()
        {
            int index = 0;
            for (int i = 0; i < Math.Sqrt(map.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(map.Length); j++)
                {
                    if (!map[index].Coord.Compare(player.ActorCoordinate))
                    {
                        Console.Write(map[index].Id);
                        index++;
                    }
                    else
                    {
                        Console.Write(player.Id);
                        index++;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
