/*
 Title: The Prototype

 Objectives:
    - Build a porgram that will allow a user, the pilot to enter a number. 

    - If the numeber is above 100 orl less than 0, keep asking. 

    - Clear the screen once the program has collected a good number.

    - Ask a second user, the hunter, to guess numbers.

    - Indicate wheather the user guessed too high, too low, or guessed right. 

    - Loop untiil they get it right, then end the program.  
*/

Console.Title = "The Prototype";

int user1Input, user2Input;

Console.Write("Pilot, enter a number between 0 and 100: ");

user1Input = Convert.ToInt32(Console.ReadLine());

while ( user1Input < 0 || user1Input  > 100 )
{
    Console.Write("Bad choice, Pilot pick a new a number between 0 and 100 please: ");
    user1Input = Convert.ToInt32(Console.ReadLine());
}

Console.Clear();

Console.Write("Hunter, guess the number the pilot just entered: ");

user2Input = Convert.ToInt32(Console.ReadLine());

while ( user2Input != user1Input)
{
    
    if (user2Input < user1Input)
    {
        Console.WriteLine("Your guess is too low.");
        user2Input = Convert.ToInt32(Console.ReadLine());

    }
    else if (user2Input > user1Input)
    {
        Console.WriteLine("Your guess is too high.");
        user2Input = Convert.ToInt32(Console.ReadLine());
    }
    
}

Console.WriteLine("You guessed it right, Hunter! The number is: " + user1Input);