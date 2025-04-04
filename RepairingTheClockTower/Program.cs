/*
    Title: Repairing the Clocktower

    Objectives:
        - Take numbers a input from the console.

        - Display the string "Tick" is even and "Tock" if the number is odd

        - Hint: Remember to use the "%" modulus or remainder operator to determine if a number is even or odd.

*/

// input variable 
int input;

// pormpt user for input
Console.Write("Enter a number: ");

// Get/convert input from user 
input = Convert.ToInt32(Console.ReadLine());

// check if the number is even or odd
if ( input % 2 == 0)
{
    Console.Write("Tick");
}
else 
{
    Console.Write("Tock");
}

