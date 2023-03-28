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

            Game.GetWorld();

        }
    }
}
