using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;

namespace TheFinalBattle.Classes
{
    internal class Human : IPlayer
    {
        public string Type { get; set; }

        public Human(string type)
        {
            Type = type;
        }

        public void PickBehavior(Character character, Character? target)
        {
 
            string? userInput;
            int convertedInput = 0;
            string menuPrompt = $"\n{character.Name}'s behaviors:";
            string choicesPrompt = $"\nWhat behavior would you like {character.Name} to perform? ";
            string invalidInputPrompt = $"\nYour behavior choice was invalid for {character.Name}. Try again!";

            int choice = 0;

            Console.WriteLine(menuPrompt);

            foreach (KeyValuePair<string, IBehavior> keyValuePair in character.Behaviors)
            {
                Console.WriteLine($"{choice} - {keyValuePair.Key}");
                choice++;
            }

            Console.Write(choicesPrompt);
            userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput) || !Int32.TryParse(userInput, out convertedInput) || convertedInput >= character.Behaviors.Count || convertedInput < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(invalidInputPrompt);
                Console.ResetColor();
                PickBehavior(character, target);
                return;
            }

            var behaviorKey = character.Behaviors.Keys.ElementAt(convertedInput);

            character.PerformBehavior(behaviorKey, target);
        }
    }
}
