/*
 
Title: The Replicator Of D'To

Objectives:
    _ Make a program that contains creates an array of length 5.

    _ Ask for the user to enter 5 numbers.

    _ Make a second array with a length 5.

    - Use a loop to copy the values out of the original array and into the new one.

    - Print out the contents of each array one after the other to show the array was copied corretly.  
 */

string numbers;

int[] copy = new int[5];

Console.WriteLine("Please enter 5 numbers separated by a space: ");

numbers = Console.ReadLine() ?? "";

string[] numbersArray = numbers.Split(' ');

for ( int x = 0; x < numbersArray.Length; x++ )
{
    // Convert each value of the string array to an int
    // load the array using the index of the loop
    copy[x] = Convert.ToInt32(numbersArray[x]);

    // Print out the contents of the array
    Console.WriteLine($"The value of the original array is: {numbersArray[x]}");
    Console.WriteLine($"The value of the copied array is: {copy[x]}");

}







