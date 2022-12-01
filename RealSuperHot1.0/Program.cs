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
        static Coordinate monstercoord = new Coordinate(startingpos / 2, startingpos / 2);
        static Actor player = new Actor(new PlayerComponent(), playercoord, 20, '@');
        static Actor monster = new Actor(new MonsterComponent(), monstercoord, 1, 'X');

        static Actor[] allActors = new Actor[] { player, monster };

        static Tile[] map = CreateMap(size);

        static World world = new World(map, allActors);

        static Item attack = null;

        static void Main()
        {
            
           while (true)
            {
                //world.ShowMap(attack);
                //foreach (Actor actor in allActors)
                //{
                //    if (!TakeInput(out ConsoleKey input))
                //        Console.WriteLine("Wrong input, nothing happened");
                //    else if (input != ConsoleKey.Spacebar)
                //        Move(actor, input);
                //    else
                //        Console.WriteLine("ATTACK");  
                //}
                //attack = player.Attack();

            }

        }
        

        static public void Attack(Actor actor)
        {

        }

        static public void Move(Actor actor, ConsoleKey input)
        {


            if (!actor.GetMove((Direction)input, out Coordinate coord))
                Console.WriteLine("You just changed direction");
            else if (world.CheckCollision(coord))
            {
                Console.WriteLine("You can't walk there");
                actor.UnMove();
            }
            else
                actor.Move();
                    
            
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
