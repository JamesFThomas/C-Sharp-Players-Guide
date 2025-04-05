/*

Title: The Laws of Freach 

Objectives:
   - Create an application that calculates the minimvalue and average of a array of intergers.

   - Make sure your code uses a foreach loop instead of a for loop

*/


int[] array = new int[] { 3, 5, -7, -99, 32, 27, 45, 47 };

int currentSmallest = int.MaxValue;
int total = 0;

foreach ( int number in array)
{
    if ( currentSmallest < number)
    {
        currentSmallest = number;
    }
    total += number;
}

int average = total / array.Length;

Console.WriteLine($"The smallest number in the areaa is {currentSmallest}");
Console.WriteLine($"The average of the array is {average}");