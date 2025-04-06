/*

Title: Taking A Number

Objectives:

    - Make a method with the sugnture int AskForNumber(string text). Display the text paarmeters in the Console window, get response from the user,
      convert it into an int and return it. 
        
        --> example: int number = AskForNumber("Please enter a number: ");   

    - Make a method with the signature AskForNumberInRange(string text, int min, int max). Only return if the entered number is between the min and the maxvalues. 
      If the number is not in the range, ask again.
        
        --> example: int number = AskForNumberInRange("Please enter a number between 1 and 10: ", 1, 10);    
    
    - Place these methods in at least one of your previous programs to improve it. 
 
*/





// Main program

Console.Title = "The Prototype Updated";

int user1Input = 0;

string text = "Pilot, enter a number between 0 and 100: ";

string text2 = "Hunter, guess the number the pilot just entered: ";

user1Input = AskForNumber(text);

AskForNumberInRange(text2, user1Input);







// Methods 
int AskForNumber(string text)
{
    int userInput;
    Console.Write(text);
    userInput = Convert.ToInt32(Console.ReadLine());

    if (userInput < 0 || userInput > 100)
    {
        string text3 = "Bad choice, pick a new a number between 0 - 100 please: ";
        return AskForNumber(text3);
    }

    else
    {
        Console.Clear();
        return userInput;
    }
}


void AskForNumberInRange(string text, int target)
{
    int userInput;
    Console.Write(text);
    userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput < target)
        {
               string lowText = $"Your guess {userInput} is too low. Please try again.";
            AskForNumberInRange(lowText, target);
        }

        else if (userInput > target)
        {
            string textHigh = $"Your guess {userInput} is too high. Please try again.";

            AskForNumberInRange(textHigh, target);
    }

     Console.WriteLine($"Your guess {userInput} was correct.");

}