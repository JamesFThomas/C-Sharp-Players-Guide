namespace ConsoleMethods
{
    /*

Title: Colored Console


Story: 

The medallion of Large Solutions lies behind a sealed stone door and can only be unlocked by building a solution with two correctly linked projects. 
this multi-project solution is the key that unseals the door. 


Objectives:

- Create a new console application from scratch.

- Add a second Class Library project to the solution. 

- Add the method public static string Prompt(string question) that writes question to the console window, then switches to cyan to get the user's response all on the same line.

- Add the method public static void WriteLine(string text, ConsoleColor color) that writes the given text on its own line in the given color. 

- Add the method public static void Write(string text, ConsoleColor color) that writes the given text without a new line in the given color.  

- Add the right references between projects so that the main program can use the following code.  

string name = ColorConsole.Prompt("What is your name")
ColorConsole.WriteLine("Hello " + name, ConsoleColor.Green);
*/
    public class ColorConsole
    {
        public static string Prompt(string question)
        {
            string? input;

            Console.Write(question);

            Console.ForegroundColor = ConsoleColor.Cyan;

            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            { 
                Console.WriteLine("Please enter answer!");
                return Prompt(question);
            }
              
            return input;

        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();

        }

        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

    }
}
