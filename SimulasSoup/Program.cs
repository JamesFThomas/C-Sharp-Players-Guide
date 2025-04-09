/*

Title: Simula's Soup

I'm a great cook, I've got recipes for soup, stew, and gumbo. I've got mushrooms, chicken, carrots, and potatoes for ingredients. 
And becuase you got my chest open I have spices again so I can make it spicy, salty, or sweet.
Pick a recipe, a main ingredient, and a seasoning, and I'll make it.
Use your programmer skills to help us track what we make.


Objectives:

- Define enumerations for the three variations on food: 
    -- type (soup, stew, gumbo) 
    -- main ingredient ( mushrooms, chicken, carrots, potatoes) 
    -- seasoning ( spicy, salty, sweet)

- Make a tuple varaible to represent a soup composed of the three above enumeration types

- Let the user pick a type, main ingredient, and seasoning from the choices and fill the tuple with the results. 
    -- Hint: You could give the user a menu to pick from or simply compare the user's text input agaiinst specific strings to determine which enumeration value represents their choice.

- When done, display the contents of the soup tuple variable in a format like this: "Sweet Chicken Gumbo"
   -- Hunt: You don't need to convert the enumeration value back to a string. Simply displaying  the enumeration value with Write or WriteLine will display the name of the enumeration value

 
*/


(string type, string ingredient, string seasoning) meal = ("", "", "");

GetRecipeChoice();
GetIngredientChoice();
GetSeasoningChoice();
DisplayMeal();




// display as seasiong, ingredient, recipe 

//make methods for each choice 
void GetRecipeChoice()
{
    // show the user the choices
    Console.Write("Please choose a recipe: soup, stew, or gumbo: ");
    
    // get user choice 
    //string userInput = Console.ReadLine().ToLower();

    string? userInput = Console.ReadLine()?.ToLower();
    
    if (userInput == null)
    {
        Console.WriteLine("Input cannot be null. Please try again.");
        GetRecipeChoice();
    }

    // set the meal variable type
    switch (userInput)
    {
        case "soup":
            meal.type = Recipe.soup.ToString().ToLower();
            break;
        case "stew":
            meal.type = Recipe.stew.ToString().ToLower();
            break;
        case "gumbo":
            meal.type = Recipe.gumbo.ToString().ToLower();
            break;
        default:
            Console.WriteLine("Invalid choice.");
            GetRecipeChoice();
            break;
    }

}

void GetIngredientChoice()
{
    // show the user the choices
    Console.Write("Please choose an ingredient: mushrooms, chicken, carrots, potatoes: ");

    string? userInput = Console.ReadLine()?.ToLower();

    if (userInput == null)
    {
        Console.WriteLine("Input cannot be null. Please try again.");
        GetIngredientChoice();
    }

    // set the meal variable type
    switch (userInput)
    {
        case "mushrooms":
            meal.ingredient = Ingredient.mushrooms.ToString().ToLower();
            break;
        case "chicken":
            meal.ingredient = Ingredient.chicken.ToString().ToLower();
            break;
        case "carrots":
            meal.ingredient = Ingredient.carrots.ToString().ToLower();
            break;
        case "potatoes":
            meal.ingredient = Ingredient.potatoes.ToString().ToLower();
            break;
        default:
            Console.WriteLine("Invalid choice.");
            GetIngredientChoice();
            break;
    }
}



void GetSeasoningChoice()
{
    // show the user the choices
    Console.Write("Please choose a seasoning: spicy, salty, sweet: ");

    string? userInput = Console.ReadLine()?.ToLower();

    if (userInput == null)
    {
        Console.WriteLine("Input cannot be null. Please try again.");
        GetSeasoningChoice();
    }

    // set the meal variable type
    switch (userInput)
    {
        case "spicy":
            meal.seasoning = Seasoning.spicy.ToString().ToLower();
            break;
        case "salty":
            meal.seasoning = Seasoning.salty.ToString().ToLower();
            break;
        case "sweet":
            meal.seasoning = Seasoning.sweet.ToString().ToLower();
            break;
        default:
            Console.WriteLine("Invalid choice.");
            GetSeasoningChoice();
            break;
    }
}


void DisplayMeal()
{
    // display the meal
    Console.WriteLine($"Your having: {meal.seasoning} {meal.ingredient} {meal.type}");
}

enum  Recipe
{ 
    soup,
    stew,
    gumbo
}

enum Ingredient
{
    mushrooms,
    chicken,
    carrots,
    potatoes
}

enum Seasoning
{ 
    spicy,
    salty,
    sweet
} 