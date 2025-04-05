/*
 
 Title: The Magic Cannon 

 Details:
    - The new cannon crew has a new cannon that blasts out different types of energy.
    - every third turn the cannon blasts out fire
    - every fifth turn the cannon blasts out eltricity
    - when those numbers line up the cannon produces a combined blast

 Objective: 

    - Write a program that will loop through the value between 1 and 100 and display what kind of blast the new cannon crew should expect.

    - Change the color of the output text based on the type of blast:
        - If the number is divisible by 3, display "Yoga Flame!" in red.
        - If the number is divisible by 5, display "Hadoken!" in yellow.
        - If the number is divisible by both 3 and 5, display "Combo Strike, Hadoken Flame!" in blue.
    -
 
 */

for ( int x = 0; x <= 100; x++)
{
    if (x % 15 == 0)
        {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Combo Strike, Hadoken Flame!");
    }
    else if (x % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Yoga Flame!");
    }
    else if (x % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Hadoken!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(x);
    }

}