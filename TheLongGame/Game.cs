using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLongGame
{
    internal class Game
    {
        public Game() { }


        static void StartGame() 
        {
            string playerName;
            int playerScore = 0; 

            // ask player for name
            playerName = CollectPlayerName();

            // check to see if file by that name exist - set playerScore to that value
            // playerScore = CheckUserScores();

            // create new player with input string 
            User user = new User(playerName, playerScore);

            // TrackKeyStrokes

            //SaveUserScores
            
            //End Game

        }

        static string CollectPlayerName()
        {
            string? input;
            string prompt = "Player please enter your name: ";
            string blankPrompt = "Please enter a valid string value!";

            Console. Write(prompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Write(blankPrompt);
                return CollectPlayerName();
            }

            return input;
        }

        static int CheckUserScores(string username)
        {
            // Check directory of files for filename matching inputted username
            return 0;
        }

        static void TrackKeyStrokes(User user)
        { 
            // track keystrokes and increase user score or end game 
        }

        static void SaveUserScores(string username)
        {
            // save user score in Scores Directory for next game  

        }

    }
}
