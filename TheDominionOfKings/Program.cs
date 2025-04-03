/*
    Title: The Dominion of Kings

    Objectives: 
        - Create a program that allows users to enter how many provinces, duchies, and estates they have. 

        - Add up the user's total score, giving 1 point per estate, 3 per duchy, and 6 per porvince.

        - Display the point totat to the user. 
 
*/


// Create variables for each string input provinces, duchies, estates;
int provinces, duchies, estates, totalPoints;

// Assign each variable to user input for corresponding question 

Console.WriteLine("Enter the number of provinces you control.");

provinces = Int32.Parse(Console.ReadLine());

Console.WriteLine("Enter the number of duchies you control.");

duchies = Int32.Parse(Console.ReadLine());

Console.WriteLine("Enter the number of estates you control.");

estates = Int32.Parse(Console.ReadLine());

// create variable to hold total point value 


// perform computation for total points 
totalPoints = (provinces * 6) + (duchies * 3) + (estates * 1);


// return total points 
Console.WriteLine($"Your total points are {totalPoints}.");

