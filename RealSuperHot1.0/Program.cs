using System;
using System.Collections.Generic;

namespace RealSuperHot1._0
{
        //  Improvements :
        //  Välja hp, eller difficulty. 
        //  Välja karaktärsbild. 
        //  Potentiell förbättring, inte resetta alla tiles. 
        // tilesförändring tar in ett ID? 
        // World 
        // Krav : Throw and catch; 
        // Enable nullable, och nullhantering // findtile gets a try-catch. 
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

        static Actor player;

        static List<Actor> allActors;

        static World world;




        static void Main()
        {
            player = new Actor(new PlayerComponent(), new Coordinate(startingpos, startingpos), playerhp, playersprite);
            allActors = new List<Actor> { player };
            world = new World(map, allActors);

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
                        Attack(actor);
                    else if(actor.Hp > 0)
                        Move(actor, direction);
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
        }
        

        static public void Attack(Actor actor)
        {
            Coordinate temp = actor.GetCoordinate();

            if (world.ActorCollision(temp, out Actor target))
            {
                target.Hp--;
                score++;
            }
            actor.MakeAttack(world.FindTile(temp));
            actor.CancelMove(); 
        }


        static public void Move(Actor actor, Direction direction)
        {
            if (!actor.CheckDirection(direction))
                return;
            else
            {
                Coordinate temp = actor.GetCoordinate();
                if (world.WallCollision(temp) || world.ActorCollision(temp))
                    actor.CancelMove();
                else
                    actor.PerformMove();
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
            MonsterComponent monstercomp = new MonsterComponent(monstercoord, player.ActorCoordinate);
            char id = 'X';
            int hp = 1;

            allActors.Add(new Actor(monstercomp, monstercoord, hp, id));
        }

        public static Coordinate SpawnLocation()
        {
            int x = 0;
            int y = 0;
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
