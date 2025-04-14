/*

Title: The Password Validator 
 
Story: 

The final task is to describe a class that represents a cocnept more abstract than the first four: a password validator. 
You must create a class that can determine if a password is valid (meets the rules defined for a legitmate password).
The rules for the task are below: 

- Passwords must be between 6 min and 13 maximum characters long.  

- Passwords must contain at least one uppercase letter, one lowercase letter, and one number. 

- Passwords cannot contain an uppercase "T" or the ampersand symbol "&". 

- Hint: 
foreach with a string lets you get it's characters!
--> foreach(char letter in word) {...}
    
char has the static methods to ctaegrize letters! 
--> char.IsUpper('A'), char.IsLower('a'), char.IsDigit('0')
 

Objectives:

- Define a new Password validator class that can be given a password and determine if it is valid by the above rules 

- Make your main mehtod loop forever, asking for a password and reporting wheather or not it is valid using an instance of the PasswrodValidator class.  


*/

string? userInput;

string userPrompt = "Please input a valid password: ";

string passwordRules = "Passwords must be: \r\n- between 6 and 13 characters long. \r\n- contain at least one uppercase letter, one lowercase letter, and one number. \r\n- cannot contain an uppercase \"T\" or the ampersand symbol \"&\".";

bool keepRunning = true;

    // create new instance of validator class
    PasswordValidator passwordValidator = new PasswordValidator();


while (keepRunning)
{
    // prompt user for input
    Console.WriteLine(passwordRules);
    Console.Write(userPrompt);

    // collect user input
    userInput = Console.ReadLine() ?? "";

    // break loop
    if (userInput == "exit") keepRunning = false;

    // evaluate input string with PasswordValidator
    bool result = passwordValidator.ValidatePassword(userInput);

    // display result of validation
    if (result)  Console.WriteLine($"Your password was valid");
    if (!result) Console.WriteLine($"Your password was invalid");

}




public class PasswordValidator
{
    public bool ValidatePassword(string codeString)
    {
        bool isValid = false;
        bool hasUpperCase = false;
        bool hasLowerCase = false;
        bool hasNumber = false;

        // fail early 
        if (string.IsNullOrEmpty(codeString) || (codeString.Length < 6 && codeString.Length > 13)) return isValid;


        foreach (char letter in codeString) 
        {
            if (char.IsUpper(letter)) hasUpperCase = true;
            if( char.IsLower(letter)) hasLowerCase = true;
            if ( char.IsDigit(letter)) hasNumber = true;
            if ( letter.Equals('T') || letter.Equals('&')) return isValid;
            
        }

        if ( hasLowerCase && hasUpperCase && hasNumber ) isValid = true;

        return isValid;

    }

}