using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelingTraditions
{
    public class Player
    {
        public bool IsAlive { get; set; } = true;
        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }

        public string Location => $"(Row = {CurrentRow}, Column = {CurrentColumn})";

        public string GetInput()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string prompt = "\nWhat do you want to do? ";

            Console.Write(prompt);

            Console.ForegroundColor = ConsoleColor.Cyan;
            string? userInput = Console.ReadLine()?.ToLower();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(userInput) ||
                userInput != "move north" &&
                userInput != "move south" &&
                userInput != "move east" &&
                userInput != "move west" &&
                userInput != "help" &&
                userInput != "quit" &&
                userInput != "enable fountain" &&
                userInput != "disable fountain")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Must enter a valid input");
                Console.ResetColor();
                return GetInput();
            }


            if (userInput == "help")
            {
                ShowHelp();
                return GetInput();
            }

            return userInput;
        }

        public void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("These are the actions that you can take.");
            Console.WriteLine("You can move through rooms: move north, move south, move east, move west.");
            Console.WriteLine("You can interact with the Fountain Of Objects: enable fountain, disable fountain.");
            Console.WriteLine("You can ask for help: help");
            Console.WriteLine("You can quit the game: quit");
            Console.ResetColor();
            return;
        }
    }
}
