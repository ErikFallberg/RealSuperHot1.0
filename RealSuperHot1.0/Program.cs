using System;
using System.Collections.Generic;

namespace RealSuperHot1._0
#nullable enable
{
    enum Direction
    {
        Left = ConsoleKey.A,
        Right = ConsoleKey.D,
        Up = ConsoleKey.W,
        Down = ConsoleKey.S
    }
    class Program
    {
        static int score;
        static int size = 20;
        static int startingpos = size / 2;

        static Tile[] map = CreateMap(size);

        static int playerhp = 20;
        static char playersprite = '@';

        static Actor player = new Actor(new PlayerInput(), new Coordinate(startingpos, startingpos), playerhp, playersprite);

        static List<Actor> allActors = new List<Actor> { player };

        static World world = new World(map, allActors);


        static void Main()
        {
            int timer = 0;
            int level = 0;
            score = 0;

            while (true)
            {
                Console.WriteLine($"Hp: {player.Hp} Level: {level} Score: {score}");
                world.ShowMap();

                foreach (Actor actor in allActors)
                {
                    if (actor.TakeInput(out Direction direction))
                        score += actor.Attack(world);
                    else if(actor.Hp > 0)
                        actor.Move(world, direction);
                }
                if (player.Hp < 1)
                    break;
                allActors.RemoveAll((Actor actor) => actor.Hp < 1);
                Console.Clear();
                Spawner(level);

                timer++;
                level += (timer % 50 == 0 && level < 10) ? 1 : 0;
            }
            Console.Clear();
            Console.WriteLine("Game Over!!!");
            Console.WriteLine($"Your final score was {score}");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Do you wanna start again?");
            Console.WriteLine("Y / N");
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.Y)
                {
                    player = new Actor(new PlayerInput(), new Coordinate(startingpos, startingpos), playerhp, playersprite);
                    allActors = new List<Actor> { player };
                    world = new World(map, allActors);
                    Console.Clear();
                    Main();
                }
                else if (input == ConsoleKey.N)
                    break;
            }

        }

        public static void Spawner(int level)
        {
            Random rand = new Random();
            int r = rand.Next(0, 10 - level);
            if (r == 0 && allActors.Count < 20)
                SpawnMonster();
        }

        public static void SpawnMonster()
        {
            Coordinate monstercoord = SpawnLocation();
            MonsterInput monstercomp = new MonsterInput(monstercoord, player.ActorCoordinate);
            char id = 'X';
            int hp = 1;

            allActors.Add(new Actor(monstercomp, monstercoord, hp, id));
        }

        public static Coordinate SpawnLocation()
        {
            int x;
            int y;
            Random rand = new Random();
            int r = rand.Next(0, 4);
            switch (r)
            {
                case 0:
                    x = 1;
                    y = rand.Next(1, size - 1);
                    break;
                case 1:
                    x = size - 1;
                    y = rand.Next(1, size - 1);
                    break;
                case 2:
                    x = rand.Next(1, size - 1);
                    y = 1;
                    break;
                case 3:
                    x = rand.Next(1, size - 1);
                    y = size - 1;
                    break;
                default:
                    throw new Exception("spawnlocation is fucking ur");
            }
            return new Coordinate(x, y);
        }


        static Tile[] CreateMap(int size) 
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
