using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionMastersOfPattern
{
    internal class User
    {

        public User() { }

        public void ShowIngredients()
        {
            string ingredients = "Your choices are:\r\nStardust = 1\r\nSnake Venom = 2\r\nShadow Glass = 3\r\nEyeshine Gem = 4";
            Console.WriteLine(ingredients);
        }

        public IngredientType ChoseIngredient() 
        {
            int convertedInput = 0;
            
            string? input;
            
            IngredientType ingredientType;

            string prompt = "\nWhat would you like to add to your potion?: ";
            
            Console.WriteLine(prompt);
            
            ShowIngredients();

            input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input) || !Int32.TryParse(input, out convertedInput ) )
            {
                Console.WriteLine("Please make a valid choice");
                ChoseIngredient();
            }

            if (convertedInput is not 1 && convertedInput is not 2 && convertedInput is not 3 && convertedInput is not 4)
            {
                Console.WriteLine("Please choose 1 - 4 ");
                ChoseIngredient();
            }

            ingredientType = (IngredientType)convertedInput;

            return ingredientType;

        }

        public bool WantsToAddIngredient()
        {
            string? input;
            string ingredients = "\nWould you like to complete the potion or add a new ingredient? (Add = 1, Complete = 2):";
            Console.WriteLine(ingredients);

            input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input) || (input != "1" && input != "2"))
            {
                Console.WriteLine("Please make a valid choice. Enter 1 to Add or 2 to Complete.");
                return WantsToAddIngredient(); 
            }

            return input == "1";
        }



    }
}
