/*
 
Title: Safe Number Crunching 


Story:

"Master Programmer we need you help!" We are but simple number crunchers. We need numbers in, work with them for a bit, then display the results. 
But not everybody enters good numbers. Sometimes, we type in the wrong things by accident. And sometimes, somebody does it on purpose.
Trolls, looking to cause trouble, I tell ya.

We heard about these TryParse methods that can ot fail or break. We know you're here looking for Medallions and allies. 
If you can help us with this, the Medallion of Reference Passing is yours, and we will join you at the final battle.


Objective: 

- Create a program that asks the user for an int value. Use the static int.TryParse(string s, out int result) method to parse the number. Loop until they enter a valid number.

- Extend the program to do the same for both double and bool. 
 
 
*/




// create a method that loops collecting a int, double, and bool from the user
// end the loop when the user enters a valid input for all types

CollectUserValues();



void CollectUserValues()
{
    Console.WriteLine("Welcome to the Safe Number Crunching program!");
    int intValue = ValidIntInput();
    double doubleValue = ValidDoubleInput();
    bool boolValue = ValidBoolInput();
    Console.WriteLine($"You entered: {intValue}, {doubleValue}, {boolValue}");
    Console.WriteLine("Thank you for using the Safe Number Crunching program!");

}

int ValidIntInput()
{
    string prompt = "Please enter an integer value: ";
    string blankPrompt = "You must enter a value: null values or empty/white space strings are not valid.";
    string intPrompt = "You must enter a valid integer value: example 1, 2, 3, -1, -2 -3";

    Console.Write(prompt);

    string? input = Console.ReadLine();

    if (String.IsNullOrWhiteSpace(input))
    { 
        Console.WriteLine(blankPrompt);
        return ValidIntInput();
    }

    if ( !int.TryParse(input, out int result))
    {
        Console.WriteLine(intPrompt);
        return ValidIntInput();
    }

    return result;
}

double ValidDoubleInput()
{
    string prompt = "Please enter a double value: ";
    string blankPrompt = "You must enter a value: null values or empty/white space strings are not valid.";
    string doublePrompt = "You must enter a valid double value: example 1.0";

    Console.Write(prompt);
    
    string? input = Console.ReadLine();
    
    if (String.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine(blankPrompt);
        return ValidDoubleInput();
    }
    
    bool wasConverted = double.TryParse(input, out double result);

    if (!wasConverted)
    {
        Console.WriteLine(doublePrompt);
        return ValidDoubleInput();
    }

    return result;
}

bool ValidBoolInput()
{
    string prompt = "Please enter a boolean value (true/false): ";
    string blankPrompt = "You must enter a value: null values or empty/white space strings are not valid.";
    string validPrompt = "You must enter a valid boolean value: example true or false";

    Console.Write(prompt);

    string? input = Console.ReadLine();

    if (String.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine(blankPrompt);
        return ValidBoolInput();
    }

    if ( input.ToLower() != "true" && input.ToLower() != "false")
    {
        Console.WriteLine(validPrompt);
        return ValidBoolInput();
    }

    if (!bool.TryParse(input, out bool result))
    {
        Console.WriteLine(validPrompt);
        return ValidBoolInput();
    }
        return result;

}