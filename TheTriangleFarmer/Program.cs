/*
    
    Title: The Triangle Farmer 

    Objectives: 

        - Write a program that lets you input the traingle's base size & height

        - Compute the srea of a traingle by truning the below equation into code
            -- Area = base * height / 2

        - Write the result of the coputation
  
*/


string baseSize, height;

Console.WriteLine("Enter the traingle's base size in inches.");

baseSize = Console.ReadLine() ?? "";

Console.WriteLine("Enter the traingle's height in inches.");

height = Console.ReadLine() ?? "";

int area = ( Int32.Parse(baseSize) * Int32.Parse(height)) / 2;

Console.WriteLine($" The area of your triangle is {area} sqaure inches ");