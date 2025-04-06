/*

Title: Countdown

Objectives:

    - Write code that counts down from 10 to 1 using a recursive method.
    
    - Hint: Remeber that you must have a base case that ends the recursion and that every time you call the method recursively, you must be getting closer to the base case.
 
*/


void Countdown( int startNumber) 
{
    if (startNumber == 1)
    {
        Console.WriteLine(startNumber);
        return;
    }

    Console.WriteLine(startNumber);

    Countdown(startNumber-1);

}



Countdown(10);