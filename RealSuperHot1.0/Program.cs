using System;

namespace RealSuperHot1._0
{
        //  Improvements :
        //  Välja hp, eller difficulty.
        //  Välja karaktärsbild.
        //  
    enum Direction
    {
        Left = ConsoleKey.A,
        Right = ConsoleKey.D,
        Up = ConsoleKey.W,
        Down = ConsoleKey.S
    }
    class Program
    {

        static int size = 20;
        static int startingpos = size / 2;

        static Coordinate playercoord = new Coordinate(startingpos, startingpos);        
        static Actor player = new Actor(new PlayerComponent(), playercoord, 20, '@');
        static Tile[] map = CreateMap(size);


        static void Main()
        {
            World world = new World(map, player);

            world.ShowMap();
            
           

        }



        static Tile[] CreateMap(int size) // Temporary mapmaker, could be made different or bigger for other variations.
        {
            Tile[] temp = new Tile[size * size];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || i == (size - 1) || j == 0 || j == (size - 1))
                    {
                        temp[index] = new Walltile(new Coordinate(j, i));
                        index++;
                    }
                    else
                    {
                        temp[index] = new Floortile(new Coordinate(j, i));
                        index++;
                    }
                }
            }
            return temp;
        }

    }
}
