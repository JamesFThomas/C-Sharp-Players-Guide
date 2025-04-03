/*
    Title: The Defense of Consolas
 
    Objectives:
        
        - Ask the user for the target row and column.

        - Compute the neighboring rows and columns of where to deploy the squad 

        - Display the deployment instructions in a different color of your chooisng.

        - Change the window title to be "Defense of Consolas"

        - Play a sound with Console.Beep when the results have been computed and displayed.   
 
 */

// Change the window title to be 
Console.Title = "Defense of Consolas";

// Ask for target row 
Console.Write("Target Row? ");
int row = Int32.Parse(Console.ReadLine());


// Ask for target column  
Console.Write("Target Column? ");
int column = Int32.Parse(Console.ReadLine());

// compute left side cordinates
string left = $"({row}, {column - 1})";

// compute botom cordinates
string bottom = $"({row - 1}, {column})";

// compute right side cordinates
string right = $"({row}, {column + 1})";

// compute top cordinates
string top = $"({row + 1}, {column})";

// Computation beep
Console.Beep();


// Change color before cordinate display
Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.Red;

// Display computed cordinates
Console.WriteLine("Deploy to:");
Console.WriteLine(left);
Console.WriteLine(bottom);
Console.WriteLine(right);
Console.WriteLine(top);

// Display beep
Console.Beep();

