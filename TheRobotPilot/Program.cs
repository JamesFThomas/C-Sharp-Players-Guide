/*
 
Title: The Robot Pilot


Story:

When we first made the Hunting the Manticore game in level 14, we required two human players: one to set up the Manticore's range from the city and the other to destroy it.
With Random, we can turn this into a single player game by randomly picking the range for the Manticore.


Objectives:

- Modify your Hunting the Manticore game to a single player game by having the computer pick a random range between 0 and 100.
 
- Answer this Question: How might you use inheritance, polymorphism, or interfaces to allow the game to be either single play (the computer randomly chooses the starting location and direction) or two players (the second human determines the starting location and direction).
--> Answer: 
    - Inheritance: Create a base class for the game that contains common properties and methods, and then create derived classes for single-player and two-player modes. 
    - Polymorphism: Use virtual methods in the base class that can be overridden in derived classes to implement different behaviors for single-player and two-player modes.
    - Interfaces: Define an interface for game actions that both single-player and two-player classes can implement, allowing for flexibility in how the game is played.
*/




// randomly set manticore range with Random class 
Random range = new Random();

int manticoreRange = range.Next(0, 101); // random number between 0 and 100

// Single player starts the game
DefendTheCity(manticoreRange);

/*

//method no longer used in one player upgrade using random class  

int SetManticoreRange()
{
    int userInput = 0;
    Console.Write("Player 1, how far away from the city do you want to station the Manticore?");
    userInput = Convert.ToInt32(Console.ReadLine());

    // check if input is in range 
    while (userInput < 0 || userInput > 100)
    {
        Console.WriteLine("The range mus be between 0 and 100.");
        userInput = Convert.ToInt32(Console.ReadLine());
    }

    // check if input is a number
    Console.Clear();
    return userInput;

}

 */

// display game status

void DisplayGameStatus(int gameRound, int cityHealth, int manticoreHealth)
{
    string statusText = $"\nSTATUS:  Round: {gameRound}  City: {cityHealth}/15   Manticore: {manticoreHealth}/10";
    Console.WriteLine(statusText);
}

// calculate cannon damage
int CalculateCannonDamage(int gameRound, int cannonDamage)
{
    if (gameRound % 15 == 0)
    {
        cannonDamage = 10;
    }
    else if (gameRound % 3 == 0 || gameRound % 5 == 0)
    {
        cannonDamage = 3;
    }
    else
    {
        cannonDamage = 1;
    }
    return cannonDamage;
}

// display damage for the round
void DisplayExpectedDamage(int cannonDamage)
{
    string damageText = $"The cannon is expected to deal {cannonDamage} damage this round.";
    Console.WriteLine(damageText);
}

// Updated method to remove the null check for an int type, as it is unnecessary and causes CS0472.
int SetCannonRange(int cannonRange)
{
    string? userInput = null;
    int convertedInput;
    string rangeText = "Enter desired cannon range: ";
    string invalidInputText = "Invalid input. Please enter a number between 0 and 100.";

    Console.Write(rangeText);
    userInput = Console.ReadLine();

    // Check if the input is a valid integer
    if( String.IsNullOrWhiteSpace(userInput) )
    {
        Console.WriteLine(invalidInputText);
        return SetCannonRange(cannonRange); 
    }

    convertedInput = Convert.ToInt32(userInput);

    if (convertedInput < 0 || convertedInput > 100)
    {
        Console.WriteLine(invalidInputText);
        return SetCannonRange(cannonRange); 
    }

    cannonRange = convertedInput;

    return cannonRange;
}

(int manticoreHealth, int cityHealth) CalculateHealthDisplayRoundResults(
    int cannonRange, int manticoreRange, int manticoreHealth, int cityHealth, int cannonDamage)
{
    string shotResult;
    string shotText;

    // Calculate manticore health - use cannon range, manticore range, and cannon damage
    if (cannonRange < manticoreRange)
    {
        shotResult = "FELL SHORT OF";
        Console.ForegroundColor = ConsoleColor.Blue;
        shotText = $"\nThat round {shotResult} the target";
        Console.WriteLine(shotText);
        Console.ResetColor();
    }
    else if (cannonRange > manticoreRange)
    {
        shotResult = "OVERSHOT";
        Console.ForegroundColor = ConsoleColor.Red;
        shotText = $"\nThat round {shotResult} the target";
        Console.WriteLine(shotText);
        Console.ResetColor();
    }
    else if (cannonRange == manticoreRange)
    {
        shotResult = "DIRECTLY HIT";
        manticoreHealth -= cannonDamage;
        Console.ForegroundColor = ConsoleColor.Yellow;
        shotText = $"\nThat round {shotResult} the target";
        Console.WriteLine(shotText);
        Console.ResetColor();
    }

    if (manticoreHealth > 0)
    {
        cityHealth -= 1;
    }

    return (manticoreHealth, cityHealth); 
}

// method to calculate health 
void GameEndDisplay(int manticoreHealth, int cityHealth)
{

    if (manticoreHealth == 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas is safe!");
    }

    if (cityHealth == 0)
    {
        Console.WriteLine("The city of Consolas has been destroyed! The Manticore is victorious!");
    }
}

// create method to run player 2 turns
void DefendTheCity(int manticoreRange)
{

    int gameRound, cityHealth, manticoreHealth, cannonRange, cannonDamage;
    bool isGameOver = false;

    gameRound = 1;
    cityHealth = 15;
    manticoreHealth = 10;
    cannonDamage = 1;
    cannonRange = 0;




    while (!isGameOver)
    {

        DisplayGameStatus(gameRound, cityHealth, manticoreHealth); 

        cannonDamage = CalculateCannonDamage(gameRound, cannonDamage); 

        DisplayExpectedDamage(cannonDamage); 

        cannonRange = SetCannonRange(cannonRange); 

        (manticoreHealth, cityHealth) = CalculateHealthDisplayRoundResults(cannonRange, manticoreRange, manticoreHealth, cityHealth, cannonDamage); 

        if (manticoreHealth <= 0 || cityHealth <= 0)
        {
            GameEndDisplay(manticoreHealth, cityHealth); 
            isGameOver = true; 
        }

        gameRound++;

    }


}