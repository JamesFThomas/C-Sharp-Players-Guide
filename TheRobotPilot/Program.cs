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



Random range = new Random(); // randomly set manticore range with Random class 

int manticoreRange = range.Next(0, 101); // random number between 0 and 100


DefendTheCity(manticoreRange); // Single player starts the game


void DisplayGameExplanation()
{
    Console.ForegroundColor = ConsoleColor.Magenta; // narrative items in magenta
    Console.WriteLine(@"
            Welcome to the Hunting the Manticore!
            You are defending the city of Consolas from the Uncoded Ones approaching airship.
            Your goal is to guess the range of the airship ( between 0 - 100 ) so your magic cannon can make a hit.
            You will be given data about each shot, allowing you to adjust your range and hopefully destroy the airship. 
            Each round the airship survives the city receives 1 damage until destroyed!
            The battle is up to you!
            ");

    Console.ResetColor();
}



void DisplayGameStatus(int gameRound, int cityHealth, int manticoreHealth)
{
    string statusText = $"\nSTATUS:  Round: {gameRound}  City: {cityHealth}/15   Manticore: {manticoreHealth}/10";
    Console.WriteLine(statusText);
}

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

void DisplayExpectedDamage(int cannonDamage)
{
    string damageText = $"The cannon is expected to deal {cannonDamage} damage this round.";
    Console.WriteLine(damageText);
}

int SetCannonRange(int cannonRange)
{
    string? userInput = null;
    int convertedInput;
    string rangeText = "Enter desired cannon range: ";
    string invalidInputText = "Invalid input. Please enter a number between 0 and 100.";

    Console.Write(rangeText);
    userInput = Console.ReadLine();

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

void GameEndDisplay(int manticoreHealth, int cityHealth)
{

    if (manticoreHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nThe Manticore has been destroyed! The city of Consolas is safe!");
        Console.ResetColor();
    }

    if (cityHealth <= 0)
    {
        Console.ForegroundColor= ConsoleColor.DarkRed;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("\nThe city of Consolas has been destroyed! The Manticore is victorious!");
        Console.ResetColor();
    }
}

void DefendTheCity(int manticoreRange)
{

    int gameRound, cityHealth, manticoreHealth, cannonRange, cannonDamage;
    bool isGameOver = false;

    gameRound = 1;
    cityHealth = 15;
    manticoreHealth = 10;
    cannonDamage = 1;
    cannonRange = 0;


    DisplayGameExplanation();

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