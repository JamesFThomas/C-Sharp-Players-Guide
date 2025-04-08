/*
 
Title: Hunting The Manitocore 

Story: 
The Uncoded One's airship, the Manticore, has begun an all-out attack on the city of Consolas. It must be destroyed, or the city will fall. 
Only by combining Milyra's prototype, Skorin's cannon, and your programming skills will you have a chance with this fight. 
You must build a program that allows one user—the pilot of the Manticore—to enter the airship’s range and destroy it before it can lay waste to the town.

The first user begins by secretly establishing how far the Manticore is from the city, in the range 0 to 100. 
The program then allows a second player to repeatedly attempt to destroy the airship by picking the range to target until either the city of Consolas or the Manticore is destroyed. 
In each attempt, the player is told if they overshot (too far), fell short (not far enough), or hit the Manticore (direct hit!). 

The damage dealt to the Manticore depends on the turn number. 
For most turns, if the turn number is a multiple of 3, a fire blast deals 3 points of damage, and if it is a multiple of both 3 and 5, a mighty fire-electric blast deals 10 points of damage. 
The Manticore is destroyed after taking 10 points of damage.

However, if the Manticore survives a turn, it will deal a guaranteed 1 point of damage to the city of Consolas. 
The city can only take 15 points of damage before being annihilated.
Before a round begins, the user should see the current status: the current round number, the city’s health, and the Manticore’s health.


Example: Game play a sample run of the program is shown below: 

- The first player gets a chance to place the Manticore:

Player 1, how far away from the city do you want to station the Manticore? 32

At this point, the display is cleared, and the second player gets their chance:

STATUS:       Round 1:  City: 15/15  Manticore: 10/10
The cannon is expected to deal 1 damage this round.
Enter desired cannon range: 50
That round OVERSHOT the target.

STATUS:       Round 2:  City: 14/15  Manticore: 10/10
The cannon is expected to deal 1 damage this round.
Enter desired cannon range: 12
That round FELL SHORT of the target.

STATUS:       Round 3:  City: 13/15  Manticore: 10/10
The cannon is expected to deal 3 damage this round.
Enter desired cannon range: 32
That round was a DIRECT HIT!

STATUS:       Round 4:  City: 12/15  Manticore: 7/10
The cannon is expected to deal 1 damage this round.
Enter desired cannon range: 32
That round was a DIRECT HIT!

STATUS:       Round 5:  City: 11/15  Manticore: 6/10
The cannon is expected to deal 3 damage this round.
Enter desired cannon range: 32
That round was a DIRECT HIT!

STATUS:       Round 6:  City: 10/15  Manticore: 3/10
The cannon is expected to deal 3 damage this round.
Enter desired cannon range: 32
That round was a DIRECT HIT!
The Manitocore has been destroyed! The city of Consolas is safe!



Objectives: 

- Run the game in a loop until either the Manticore’s or city’s health reaches 0.

- Before the second player’s turn, display the round number, the city’s health, and the Manticore’s health.

- Compute how much damage the cannon will deal this round: 10 points if the round number is a multiple of both 3 and 5, 3 if it is a multiple of 3 or 5 (but not both), and 1 otherwise. Display this to the player.

- Get a target range from the second player, and solve its effect. Tell the user if they overshot (too far), fell short, or hit the Manticore. If it was a hit, reduce the Manticore’s health by the expected amount.

- If the Manticore is still alive, reduce the city’s health by 1.

- Advance to the next round.

- When the Manticore or the city’s health reaches 0, end the game and display the outcome.

- Use different colors for different types of messages.

- Note: This is the largest program you have made so far. Expect it to take some time!

- Note: Use methods to focus on solving one problem at a time.

- Note: This version requires two players, but in the future, we will modify it to allow the computer to randomly place the Manticore so that it can be a single-player game.

 */



// set starting values
int manticoreRange = 0;

// Player 1 sets the Manticore range
manticoreRange = SetManticoreRange();

// Player 2 starts the game
// move all variable definitions and assignments inside of the method
// pass in the manticore range value set by player 1
DefendTheCity(manticoreRange);

// 


// set manticore range
int SetManticoreRange()
{
    int userInput = 0;
    Console.Write("Player 1, how far away from the city do you want to station the Manticore?");
    userInput = Convert.ToInt32(Console.ReadLine());

    // check if input is in range 
    while ( userInput < 0 || userInput > 100)
    { 
        Console.WriteLine("The range mus be between 0 and 100.");
        userInput = Convert.ToInt32(Console.ReadLine());
    }

    // check if input is a number
    Console.Clear();
    return userInput;

}

// display game status

void DisplayGameStatus(int gameRound, int cityHealth, int manticoreHealth)
{
    string statusText = $"STATUS:  Round: {gameRound}  City: {cityHealth}/15   Manticore: {manticoreHealth}/10";
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
    else { 
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

// set cannon range
int SetCannonRange(int cannonRange)
{
    int userInput;
    string rangeText = "Enter desired cannon range: ";

    Console.Write(rangeText);
    userInput = Convert.ToInt32(Console.ReadLine());

    if (userInput < 0 || userInput > 100)
    {
        Console.WriteLine("The cannon must be set between 0 and 100.");
        Console.Write(rangeText);
        userInput = Convert.ToInt32(Console.ReadLine());
    }

    cannonRange = userInput;

    return cannonRange;

}

// Modify the method `CalculateHealthDisplayRoundResults` to return a tuple instead of an array.
// This will allow the deconstruction syntax to work correctly.

(int manticoreHealth, int cityHealth) CalculateHealthDisplayRoundResults(
    int cannonRange, int manticoreRange, int manticoreHealth, int cityHealth, int cannonDamage)
{
    string shotResult;
    string shotText;

    // Calculate manticore health - use cannon range, manticore range, and cannon damage
    if (cannonRange < manticoreRange)
    {
        shotResult = "FELL SHORT OF";
        shotText = $"That round {shotResult} the target";
        Console.WriteLine(shotText);
    }
    else if (cannonRange > manticoreRange)
    {
        shotResult = "OVERSHOT";
        shotText = $"That round {shotResult} the target";
        Console.WriteLine(shotText);
    }
    else if (cannonRange == manticoreRange)
    {
        shotResult = "DIRECTLY HIT";
        manticoreHealth -= cannonDamage;
        shotText = $"That round {shotResult} the target";
        Console.WriteLine(shotText);
    }

    if (manticoreHealth > 0)
    {
        cityHealth -= 1;
    }

    return (manticoreHealth, cityHealth); // Return a tuple instead of an array
}

// method to calculate health 
void GameEndDisplay(int manticoreHealth, int cityHealth)
{

    if (manticoreHealth == 0)
    {
        Console.WriteLine("The Manitocore has been destroyed! The city of Consolas is safe!");
    }
    
    if (cityHealth == 0)
    {
        Console.WriteLine("The city of Consolas has been destroyed! The Manitocore is victorious!");
    }
}

// create emthod to run player 2 turns
void DefendTheCity(int manticoreRange)
{

    int gameRound, cityHealth, manticoreHealth, cannonRange, cannonDamage;
    Boolean isGameOver = false;

    gameRound = 1;
    cityHealth = 15;
    manticoreHealth = 10;
    cannonDamage = 1;
    cannonRange = 0;


       

    while (!isGameOver)
    {
        
        DisplayGameStatus(gameRound, cityHealth, manticoreHealth); // display the status

        cannonDamage = CalculateCannonDamage(gameRound, cannonDamage); // sets 1 || 3 || 10 
        
        DisplayExpectedDamage(cannonDamage); //display damage for current round

        cannonRange = SetCannonRange(cannonRange); // collects user 2 input 

        (manticoreHealth, cityHealth ) = CalculateHealthDisplayRoundResults(cannonRange, manticoreRange, manticoreHealth, cityHealth, cannonDamage); // calculates damage and displays results

        if (manticoreHealth <= 0 || cityHealth <= 0)
        {
            GameEndDisplay(manticoreHealth, cityHealth); // calculate health - not working 
            isGameOver = true; // set game over to true
        }

        gameRound++; // increment the round number

    }


}