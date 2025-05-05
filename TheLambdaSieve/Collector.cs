using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLambdaSieve
{
    internal class Collector
    {
        public int filterType { get; set; }
        public Collector() { }

        public void PickFilter()
        {
            string? input;
            string questions = "What number filter do you want to use with the Sieve machine? 1 = even, 2 = positive, 3 = multiples of 10: ";
            string invalidInput = "Invalid input, please type in a number\n";
            string incorrectNumberPrompt = "You must choose 1, 2, or 3 for available filter types\n";

            Console.Write(questions);

            Console.ForegroundColor = ConsoleColor.Yellow;
            input = Console.ReadLine();
            Console.ResetColor();

            if (String.IsNullOrWhiteSpace(input) || !Int32.TryParse(input, out int convertedInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(invalidInput);
                Console.ResetColor();
                PickFilter();
                return;
            }

            if (convertedInput != 1 && convertedInput != 2 && convertedInput != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(incorrectNumberPrompt);
                Console.ResetColor();
                PickFilter();
                return;
            }

            filterType = convertedInput;

        }

        public Sieve CreateSieve(int type)
        {

            switch (type)
            {
                case 1:
                    var evenSieve = new Sieve(IsEven);
                    return evenSieve;
                case 2:
                    var positiveSieve = new Sieve(IsPositive);
                    return positiveSieve;
                case 3:
                    var multiplesOf10sieve = new Sieve(IsMultipleOf10);
                    return multiplesOf10sieve;
                default:
                    throw new ArgumentException("Unable to create a Sieve with that type of filter");
            }

        }

        public void UseSieveRepeatedly(Sieve sieve)
        {
            string? input;
            string prompt = "\nWhat number would you like to check?: ";
            string invalidInput = "Please input a number value!";

            Console.Write(prompt);

            Console.ForegroundColor = ConsoleColor.Yellow;
            input = Console.ReadLine();
            Console.ResetColor();

            if (String.IsNullOrEmpty(input) || !Int32.TryParse(input, out int numberToCheck))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(invalidInput);
                Console.ResetColor();
                UseSieveRepeatedly(sieve);
                return;
            }

            // use sieve with number to check
            var result = sieve.iGood(numberToCheck);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{numberToCheck} was {result}\n");
            Console.ResetColor();

            UseSieveRepeatedly(sieve);
            return;

        }

        public bool IsEven(int input) => input % 2 == 0;

        public bool IsPositive(int input) => input > 0;

        public bool IsMultipleOf10(int input) => input % 10 == 0;
    }
}
