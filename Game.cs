using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    class Game
    {
        public static int i, j, elements, x = 0, y = 0;
        public static int lower = 0, upperX, upperY;  //variables storing upper and lower bound values for the if statement to enable player to not move outside the bounds of the map
        public static string fountain; //stores location of room containing the fountain of objects
        public static string[,] matrix;
        public static string position; //stores player's position at that point in time
        public static string command, status = "unactivated"; //status variable shows whether the fountain of objects has been activated or not
        public static bool end = true;


        public static void GetSmallWorld()
        {
            elements = 4;
            upperY = 3;
            upperX = 3;

            matrix = new string[4, 4]
          {
                { "(0,0)", "(0,1)", "(0,2)", "(0,3)" },
                { "(1,0)", "(1,1)", "(1,2)", "(1,3)" },
                { "(2,0)", "(2,1)", "(2,2)", "(2,3)" },
                { "(3,0)", "(3,1)", "(3,2)", "(3,3)"} };

            fountain = matrix[0, 2];
            position = matrix[x, y];

            Play();
        }

        public static void GetMediumWorld()
        {
            elements = 6;
            upperY = 5;
            upperX = 5;

            matrix = new string[6, 6]
        {
                { "(0,0)", "(0,1)", "(0,2)", "(0,3)", "(0,4)", "(0,5)" },
                { "(1,0)", "(1,1)", "(1,2)", "(1,3)", "(1,4)", "(1,5)" },
                { "(2,0)", "(2,1)", "(2,2)", "(2,3)", "(2,4)", "(2,5)" },
                { "(3,0)", "(3,1)", "(3,2)", "(3,3)", "(3,4)", "(3,5)"},
                { "(4,0)", "(4,1)", "(4,2)", "(4,3)", "(4,4)", "(4,5)"},
                { "(5,0)", "(5,1)", "(5,2)", "(5,3)", "(5,4)", "(5,5)"}};

            fountain = matrix[3, 3];
            position = matrix[x, y];

            Play();
        }

        public static void GetLargeWorld()
        {
            elements = 8;
            upperY = 7;
            upperX = 7;

            matrix = new string[8, 8]
           {
                { "(0,0)", "(0,1)", "(0,2)", "(0,3)", "(0,4)", "(0,5)", "(0,6)", "(0,7)" },
                { "(1,0)", "(1,1)", "(1,2)", "(1,3)", "(1,4)", "(1,5)", "(1,6)", "(1,7)" },
                { "(2,0)", "(2,1)", "(2,2)", "(2,3)", "(2,4)", "(2,5)", "(2,6)", "(2,7)" },
                { "(3,0)", "(3,1)", "(3,2)", "(3,3)", "(3,4)", "(3,5)", "(3,6)", "(3,7)"},
                { "(4,0)", "(4,1)", "(4,2)", "(4,3)", "(4,4)", "(4,5)", "(4,6)", "(4,7)"},
                { "(5,0)", "(5,1)", "(5,2)", "(5,3)", "(5,4)", "(5,5)", "(5,6)", "(5,7)"},
                { "(6,0)", "(6,1)", "(6,2)", "(6,3)", "(6,4)", "(6,5)", "(6,6)", "(6,7)"},
                { "(7,0)", "(7,1)", "(7,2)", "(7,3)", "(7,4)", "(7,5)", "(7,6)", "(7,7)"}};

            fountain = matrix[5, 2];
            position = matrix[x, y];

            Play();
        }

        public static void Play()
        {
            // while loop allows the game to end when the player has won/lost/quit the game.
            while (end)
            {
                GetRoom();
            }
        }

        //allows user choose size of the world to play and creates a 4x4, 6x6, or 8x8 map depending on user response
        public static void GetWorld()
        {
            Console.WriteLine("\n____________________________________________\n");
            Console.WriteLine("Choose between a Small, Medium or Large world.");
            Console.ForegroundColor = ConsoleColor.Cyan;

            //converts user's string response into an enum value
            Enum.TryParse<World>(Console.ReadLine(), out var world);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("____________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            switch (world)
            {
                case World.Small:
                    GetSmallWorld();
                    break;
                case World.Medium:
                    GetMediumWorld();
                    break;
                case World.Large:
                    GetLargeWorld();
                    break;
                default:
                    break;
            }
        }


        //prints out world map for each move
        public static void GetRoom()
        {

            Console.WriteLine("");
            for (i = 0; i < elements; i++)
            {
                Console.Write("\n");
                for (j = 0; j < elements; j++)
                {
                    Console.Write($" {matrix[i, j]}|");
                }
            }
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You are currently in the room at {position}");

            if (elements == 4) Get4x4Sense();
            if (elements == 6) Get6x6Sense();
            if (elements == 8) Get8x8Sense();

            if (end)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What do you want to do? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                command = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                GetCommand();
            }
        }

        //shows all the actions for each command
        public static void GetCommand()
        {
            switch (command)
            {

                case "move east":

                    if (y == upperY)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You have gotten to a dead end. Please retrace your steps.");
                        break;
                    }
                    else
                    {
                        y++;
                        position = matrix[x, y];
                    }

                    break;


                case "move west":

                    if (y == lower)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You have gotten to a dead end. Please retrace your steps.");
                        break;
                    }
                    else
                    {
                        y--;
                        position = matrix[x, y];
                    }
                    break;


                case "move north":

                    if (x == lower)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You have gotten to a dead end. Please retrace your steps.");
                        break;
                    }
                    else
                    {
                        x--;
                        position = matrix[x, y];
                    }

                    break;


                case "move south":

                    if (x == upperX)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You have gotten to a dead end. Please retrace your steps.");
                        break;
                    }
                    else
                    {
                        x++;
                        position = matrix[x, y];
                    }

                    break;


                case "enable fountain":

                    if (position == fountain)
                    {
                        status = "activated";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        GetRoom();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are not in the fountain room so there is no effect.");
                        Console.ResetColor();
                    }
                    break;

                case "help":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("______________________________________________________________________________");
                    Console.WriteLine("\nAvailable Commands: ");
                    Console.WriteLine("'move north' - moves you to the room above your current room");
                    Console.WriteLine("'move south' - moves you to the room below your current room");
                    Console.WriteLine("'move east' - moves you to the room to the right your current room");
                    Console.WriteLine("'move west' - moves you to the room to the left your current room");
                    Console.WriteLine("'quit' - terminates the game");
                    Console.WriteLine("'help' - gives information about available commands");
                    Console.WriteLine("'enable fountain' - activates the fountain of objects");
                    Console.WriteLine("______________________________________________________________________________");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case "quit":
                    Console.WriteLine("\nYou have terminated the game.");
                    Console.ReadKey();
                    end = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Error!! Enter a valid command");
                    break;

            }
        }

        //The Get(4x4/6x6/8x8)Sense Functions dictate the location of pits and the fountain room depending on the world chosen
        public static void Get4x4Sense()
        {
            if (position == matrix[0, 0])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (status == "unactivated") Console.WriteLine("You see light in this room coming from outside the cavern, this is the entrance.");
                if (status == "activated")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("The Fountain Of Objects has been reactivated, and you have escaped with your life! \nYou win!");
                    Console.ReadKey();
                    end = false;

                }
            }

            if (position == matrix[1, 1])
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You have entered a pit. ");
                Console.WriteLine("YOU HAVE LOST!!");
                Console.ReadKey();
                end = false;
            }

            if (position == matrix[0, 1] || position == matrix[1, 0] || position == matrix[1, 2] || position == matrix[2, 1])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (position == fountain && status == "unactivated")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                Console.ForegroundColor = ConsoleColor.Gray;


            }
        }

        public static void Get6x6Sense()
        {
            if (position == matrix[0, 0])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (status == "unactivated") Console.WriteLine("You see light in this room coming from outside the cavern, this is the entrance.");
                if (status == "activated")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("The Fountain Of Objects has been reactivated, and you have escaped with your life! \nYou win!");
                    Console.ReadKey();
                    end = false;
                }
            }

            if (position == matrix[1, 4] || position == matrix[1, 5] || position == matrix[2, 4]
                || position == matrix[3, 4] || position == matrix[3, 5] || position == matrix[4, 3] || position == matrix[4, 4]
                || position == matrix[4, 5] || position == matrix[5, 3] || position == matrix[5, 5])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (position == matrix[2, 5] || position == matrix[5, 4])
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You have entered a pit. ");
                Console.WriteLine("YOU HAVE LOST!!");
                Console.ReadKey();
                end = false;
            }

            if (position == matrix[3, 3] && status == "unactivated")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                Console.ForegroundColor = ConsoleColor.Gray;


            }
        }

        public static void Get8x8Sense()
        {
            if (position == matrix[0, 0])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (status == "unactivated") Console.WriteLine("You see light in this room coming from outside the cavern, this is the entrance.");
                if (status == "activated")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("The Fountain Of Objects has been reactivated, and you have escaped with your life! \nYou win!");
                    Console.ReadKey();
                    end = false;
                }
            }

            if (position == matrix[1, 4] || position == matrix[1, 5] || position == matrix[1, 6] || position == matrix[2, 4] || position == matrix[2, 6]
                           || position == matrix[3, 4] || position == matrix[3, 5] || position == matrix[3, 6] || position == matrix[4, 3] || position == matrix[4, 4]
                           || position == matrix[4, 5] || position == matrix[5, 3] || position == matrix[5, 5] || position == matrix[6, 3] || position == matrix[6, 4] || position == matrix[6, 5]
                           || position == matrix[5, 5] || position == matrix[5, 6] || position == matrix[5, 7] || position == matrix[6, 5] || position == matrix[6, 7]
                           || position == matrix[7, 5] || position == matrix[7, 6] || position == matrix[7, 7] || position == matrix[0, 0] || position == matrix[0, 1] || position == matrix[0, 2]
                           || position == matrix[1, 0] || position == matrix[1, 2] || position == matrix[2, 0] || position == matrix[2, 1] || position == matrix[2, 2])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            if (position == matrix[2, 5] || position == matrix[5, 4] || position == matrix[6, 6] || position == matrix[1, 1])
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You have entered a pit. ");
                Console.WriteLine("YOU HAVE LOST!!");
                Console.ReadKey();
                end = false;
            }

            if (position == matrix[5, 2] && status == "unactivated")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
        }


    }

    enum World { Small, Medium, Large }
}
