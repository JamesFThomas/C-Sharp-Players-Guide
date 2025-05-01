using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeptisGame
{
    internal class Player
    {
        public int Id;
        public Player(int id)
        {
            Id = id;
        }

        public int Guess()
        {
            string? input = null;
            string prompt = $"\nPlayer {Id} what is your guess (0-9): ";
            string blankPrompt = "You must enter a valid input!\n";
            string outOfRangePrompt = "Your choice must between 0 - 9\n";

            ConsoleColor color = Id == 1 ? ConsoleColor.Blue : ConsoleColor.Green;
            
            Console.ForegroundColor = color;
            Console.Write(prompt);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();

            input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(blankPrompt);
                Console.ResetColor();
                return Guess();
            }

            if (!int.TryParse(input, out int convertedInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(blankPrompt, ConsoleColor.Red); 
                Console.ResetColor();
                return Guess();
            }
            

            if (convertedInput < 0 || convertedInput > 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(outOfRangePrompt, ConsoleColor.Red);
                Console.ResetColor();
                return Guess();
            }

            return convertedInput;
        }
    }
}
