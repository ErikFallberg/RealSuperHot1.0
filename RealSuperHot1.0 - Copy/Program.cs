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
        static Tile[] map = CreateMap(size);

        static Coordinate playercoord = new Coordinate(startingpos, startingpos);
        static Coordinate monstercoord = new Coordinate(startingpos / 2, startingpos / 2);
        static int playerhp = 20;
        static char playersprite = '@';

        static Actor player = new Actor(new PlayerComponent(), playercoord, playerhp, playersprite);
        static Actor monster = new Actor(new MonsterComponent(playercoord, monstercoord), monstercoord, 1, 'X');

        static Actor[] allActors = new Actor[] { player, monster };



        static World world = new World(map, allActors);



        static void Main()
        {

            while (true)
            {
                Console.WriteLine("");
                world.ShowMap();

                foreach (Actor actor in allActors)
                {
                    if(actor.TakeInput(out Direction direction))
                        Console.WriteLine(); // Attack
                    else
                    {
                        if (!actor.CheckDirection(direction))
                            continue;
                        actor.Move(world.CheckCollision(actor.GetCoordinate()));
                    }
                }
                Console.Clear();
            }

        }
        

        static public void Attack(Actor actor)
        {

        }

        static bool TakeInput(out ConsoleKey input)  // ACTIONCOMPONENT. Om spacebar ska spelaren attackera, om spelaren står bredvid ska monster attackera. 
        {
            input = Console.ReadKey().Key;
            return input == ConsoleKey.A || input == ConsoleKey.D || input == ConsoleKey.W || input == ConsoleKey.S || input == ConsoleKey.Spacebar;
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
