/*

Title: The Potion Masters Of Pattern



Story: 

The Island of Pattern is home to skilled potion masters in need of some help. 
Potions are mixed bya adding one ingredient at a time until they produce a valuable potion type. 
The potion masters will give you the Patterned Medallion if you help make program to build potions according to the rules below. 

- All potions start as water.

- Adding stardust to water turns it into an elixir. 

- Adding snake venom to elixir turns into into poison potion. 

- Adding shadow glass to an elixir turns into a invisibility potion.  
 
- Adding eyeshine gem to an elixir turns into a night vision potion.  
 
- Adding shadow glass to a night visibility potion turns it into a cloudy brew.  

- Adding eyeshine gem to a invisibility potion turns it into into a cloudy brew.

- Adding stardust to an elixir turns into a wraith potion.

- Anything else results in a ruined potion.



Objectives:

- Create Enumerations for the potions and ingredient types. 

- Tell the user what type of potion they currently have and what ingredients choices are available. 

- Allow them to enter an ingredient choice. Use a pattern to turn the user's choice into a ingredient. 

- Change the current potion type according to the rules above using a pattern. 

- Allow them to choose whether to complete the potion or continue before adding an ingredient. 
    --> If the user chooses to complete the potion end the program.  

- When the usr creates a ruined potion, tell them and start over with water
 
 
*/

namespace PotionMastersOfPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            User user = new User();
            Potion potion = new Potion();
            bool isCreating = true;

            while (isCreating)
            {
                var ingredient = user.ChoseIngredient();
                var shouldAddOrEnd = user.WantsToAddIngredient();

                if (!shouldAddOrEnd)
                {
                    isCreating = false;
                }
                else // Only proceed if the user wants to add an ingredient
                {
                    potion.AddIngredient(ingredient);

                    if (potion._Type == PotionType.Ruined)
                    {
                        Console.WriteLine("You ruined the potion and must start over!");
                        potion = new Potion(); 
                        continue; 
                    }

                    Console.WriteLine($"You've created a {potion._Type}");
                }
            }

            Console.WriteLine($"Your final potion is {potion.TypeToString()}");
        }
    }
}





