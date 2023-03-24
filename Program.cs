using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFountainOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to the Fountain of Objects Game.\n\n");
            Console.WriteLine("Description: \nYou enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.");
            Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
            Console.WriteLine("You must navigate the Caverns with your other senses.");
            Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance");
            Console.WriteLine("\nNote: Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");
            Console.WriteLine("Commands are: 'move north', move south', move east', 'move west' and 'enable fountain' \t[Enter help if you forget a command]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n____________________________________________\n");
            Console.WriteLine("Choose between a small, medium and large world.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string world = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("____________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            switch (world)
            {
                case "small":
                    while (true)
                    {
                        if (Rooms4x4.end == true) Rooms4x4.GetRoom();
                        else if (Rooms4x4.end == false) break;
                    }
                    break;
                case "medium":
                    while (true)
                    {
                        if (Rooms6x6.end == true) Rooms6x6.GetRoom();
                        else if (Rooms6x6.end == false) break;
                    }
                    break;
                case "large":
                    while (true)
                    {
                        if (Rooms8x8.end == true) Rooms8x8.GetRoom();
                        else if (Rooms8x8.end == false) break;
                    }
                    break;
                default:
                    Console.WriteLine("Error! Enter either 'small', 'medium' or 'large' ");
                    break;
            }





        }
    }

    public class Rooms4x4
    {
        public static string[,] matrix = new string[4, 4] { { "(0,0)", "(0,1)", "(0,2)", "(0,3)" },
            { "(1,0)", "(1,1)", "(1,2)", "(1,3)" },
            { "(2,0)", "(2,1)", "(2,2)", "(2,3)" },
            { "(3,0)", "(3,1)", "(3,2)", "(3,3)"} };
        public static int i, j, x = 0, y = 0;
        public static string position = matrix[x, y];
        public static string command, status = "unactivated";
        public static bool end = true;

        public static void GetRoom()
        {

            Console.WriteLine("");
            for (i = 0; i < 4; i++)
            {
                Console.Write("\n");
                for (j = 0; j < 4; j++)
                {
                    Console.Write($" {matrix[i, j]}|");
                }
            }
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You are currently in the room at {position}");
            GetSense();
            if (end == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What do you want to do? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                command = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                GetCommand();

            }
            else if (end == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("GAME END");
            }




        }

        public static void GetSense()
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

            if (position == matrix[0, 2] && status == "unactivated")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                Console.ForegroundColor = ConsoleColor.Gray;


            }
        }

        public static void GetCommand()
        {
            switch (command)
            {

                case "move east":

                    if (y == 3)
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

                    if (y == 0)
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

                    if (x == 0)
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

                    if (x == 3)
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

                    if (position == matrix[0, 2])
                    {
                        status = "activated";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        GetRoom();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You are not in the fountain room so there is no effect.");
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
                    Console.WriteLine("______________________________________________________________________________");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Error!! Enter a valid command");
                    break;

            }
        }

    }


    public class Rooms6x6
    {
        public static string[,] matrix = new string[6, 6] { { "(0,0)", "(0,1)", "(0,2)", "(0,3)", "(0,4)", "(0,5)" },
            { "(1,0)", "(1,1)", "(1,2)", "(1,3)", "(1,4)", "(1,5)" },
            { "(2,0)", "(2,1)", "(2,2)", "(2,3)", "(2,4)", "(2,5)" },
            { "(3,0)", "(3,1)", "(3,2)", "(3,3)", "(3,4)", "(3,5)"},
            { "(4,0)", "(4,1)", "(4,2)", "(4,3)", "(4,4)", "(4,5)"},
            { "(5,0)", "(5,1)", "(5,2)", "(5,3)", "(5,4)", "(5,5)"}};
        public static int i, j, x = 0, y = 0;
        public static string position = matrix[x, y];
        public static string command, status = "unactivated";
        public static bool end = true;

        public static void GetRoom()
        {

            Console.WriteLine("");
            for (i = 0; i < 6; i++)
            {
                Console.Write("\n");
                for (j = 0; j < 6; j++)
                {
                    Console.Write($" {matrix[i, j]}|");
                }
            }
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You are currently in the room at {position}");
            GetSense();
            if (end == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What do you want to do? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                command = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                GetCommand();

            }
            else if (end == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("GAME END");
            }




        }

        public static void GetSense()
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

        public static void GetCommand()
        {
            switch (command)
            {

                case "move east":

                    if (y == 5)
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

                    if (y == 0)
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

                    if (x == 0)
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

                    if (x == 5)
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

                    if (position == matrix[3, 3])
                    {
                        status = "activated";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        GetRoom();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You are not in the fountain room so there is no effect.");
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
                    Console.WriteLine("______________________________________________________________________________");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Error!! Enter a valid command");
                    break;

            }
        }
    }

    public class Rooms8x8
    {
        public static string[,] matrix = new string[8, 8] { { "(0,0)", "(0,1)", "(0,2)", "(0,3)", "(0,4)", "(0,5)", "(0,6)", "(0,7)" },
            { "(1,0)", "(1,1)", "(1,2)", "(1,3)", "(1,4)", "(1,5)", "(1,6)", "(1,7)" },
            { "(2,0)", "(2,1)", "(2,2)", "(2,3)", "(2,4)", "(2,5)", "(2,6)", "(2,7)" },
            { "(3,0)", "(3,1)", "(3,2)", "(3,3)", "(3,4)", "(3,5)", "(3,6)", "(3,7)"},
            { "(4,0)", "(4,1)", "(4,2)", "(4,3)", "(4,4)", "(4,5)", "(4,6)", "(4,7)"},
            { "(5,0)", "(5,1)", "(5,2)", "(5,3)", "(5,4)", "(5,5)", "(5,6)", "(5,7)"},
            { "(6,0)", "(6,1)", "(6,2)", "(6,3)", "(6,4)", "(6,5)", "(6,6)", "(6,7)"},
            { "(7,0)", "(7,1)", "(7,2)", "(7,3)", "(7,4)", "(7,5)", "(7,6)", "(7,7)"}};
        public static int i, j, x = 0, y = 0;
        public static string position = matrix[x, y];
        public static string command, status = "unactivated";
        public static bool end = true;

        public static void GetRoom()
        {

            Console.WriteLine("");
            for (i = 0; i < 8; i++)
            {
                Console.Write("\n");
                for (j = 0; j < 8; j++)
                {
                    Console.Write($" {matrix[i, j]}|");
                }
            }
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You are currently in the room at {position}");
            GetSense();
            if (end == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What do you want to do? ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                command = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                GetCommand();

            }
            else if (end == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("GAME END");
            }




        }

        public static void GetSense()
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

        public static void GetCommand()
        {
            switch (command)
            {

                case "move east":

                    if (y == 7)
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

                    if (y == 0)
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

                    if (x == 0)
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

                    if (x == 7)
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

                    if (position == matrix[5, 2])
                    {
                        status = "activated";
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        GetRoom();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You are not in the fountain room so there is no effect.");
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
                    Console.WriteLine("______________________________________________________________________________");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Error!! Enter a valid command");
                    break;

            }
        }
    }
}
