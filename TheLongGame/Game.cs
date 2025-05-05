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


        public void StartGame() 
        {
            Greeting();

            var user = CreatePlayer();

            DisplayCreatedPlayer(user);

            LogKeyStroke(user);

            SaveScore(user);

            DisplayFinalScore(user);


        }

        static void Greeting()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Welcome to The Long Game!");
            Console.ResetColor();
        }



        static User CreatePlayer()
        {
            string? playerName;
            int playerScore = 0;
            string prompt = "Player please enter your name: ";
            string blankPrompt = "\nPlease enter a valid string value!";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(prompt);
            Console.ForegroundColor= ConsoleColor.Green;
            playerName = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                Console.Write(blankPrompt);
                return CreatePlayer();
            }

            playerScore = CheckScore(playerName); 

            User user = new User(playerName, playerScore); // create new player with name and score data

            return user;

        }

        static void DisplayCreatedPlayer(User user)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nUser {user.Name}, current score is: {user.Score}. \nLets start the long game!"); 
            Console.ResetColor();
        }

        static void DisplayFinalScore(User user)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n{user.Name}, your final score for this game was {user.Score}!");
            Console.ResetColor();
        }


        static int CheckScore(string username)
        {
            int score = 0;
            
            string directoryPath = "Scores"; 

            string[] filePaths = Directory.GetFiles(directoryPath); // getting all file paths

            string?[] fileNames = filePaths.Select(Path.GetFileNameWithoutExtension).ToArray(); // getting all file names from path

            foreach (string? file in fileNames)
            {
                string fullPath = Path.Combine(directoryPath, file + ".txt");

                var userScore = File.ReadAllText(fullPath);

                if (file?.ToLower() == username.ToLower() && userScore != null)
                { 
                    score = Convert.ToInt32(userScore);
                }

            }


            return score;
        }

        static void LogKeyStroke(User user)
        {
            Console.Write("\nPress a key: "); 

            Console.ForegroundColor = ConsoleColor.Green;
         
            var keyPress = Console.ReadKey().Key;
            
            Console.ResetColor();

            if (keyPress != ConsoleKey.Enter)
            {
                user.Score++;
                Console.WriteLine($"\nYour score is: {user.Score}");
                LogKeyStroke(user);
                return;
            }

            return;
        }

        static void SaveScore(User user)
        {
            string directoryPath = "Scores"; 
            
            Directory.CreateDirectory(directoryPath); 
            
            string filePath = Path.Combine(directoryPath, $"{user.Name}.txt"); 
            
            File.WriteAllText(filePath, $"{user.Score}"); 
        }


    }
}
