/*

Title: The Long Game

Story: 
The island of lo has a long running tradition that was destroyed when the Uncoded one arrived. 
The island inhabitants would compete over a long period of time to see who could press the most keys on a keyboard.
The Uncoded ones arrival destroyed the inhabitants ability to ue the Medallion of Files, and these historic competitions spanning days, weeks, and months has become impossible. 
As a True Programmer, you can use the Medallion of Files to bring back these long time-running games to the island.


Objectives: 

- When the program starts, ask the user to enter their name.

- By default the player starts with a score of 0.

- Add 1 point to their score, for every keypress they make. 

- Display the players update score after each each key press.

- When the player presses the below keys make certain things happen: 
    --> Enter key == end the game 
    --> Hint: The following code reads if the keypress was the Enter key: Console.ReadKey().Key == Console.Key.Enter
  

- When the player presses Enter save their score in a file. 
    --> Hint: Consider saving his to a file named [username].txt. 
    --> or this challenge you can assume the user doesn't enter a name that would produce an illegal file name (such as *). 

- When a user enters a name at the start, if they already have a previously saved score, start with that score instead. 

*/

// Noun extraction 
    // Program/Game, User, Score, Keypress 

namespace TheLongGame
{
    internal class Program
    {
        public static void Main(string[] args)

        {

            try
            {
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }


}