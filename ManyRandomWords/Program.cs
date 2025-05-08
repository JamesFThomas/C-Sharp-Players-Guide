/*

Challenge #2:

Title: Many Random Words

Story:

Awat impressed with what you did in the last challenge but thinks it could be better. 
"Why not generate "hello" and "world" in parallel!?" he asks. 
"You do that, and I'll let you take this medallion off of me."


Objectives: 

- Modify your program from the previous challenge to allow the main method to keep waiting for the user to enter more words. 
    --> For every new word entered, create and run a task to compute the attempt count and the time elapsed and display the result, but then let that run asynchronously while you wait for the next word. 
    --> You can generate many words in parallel this way. 
    --> Hint: Moving the elapsed time and output logic to another async method may make this easier. 
 
 
*/

using System;
using System.Text;

namespace ManyRandomWords
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {


            while (true)
            {
                string word = CollectWord();
                await GenerateWord(word);

            }
        }

        async public static Task GenerateWord(string word)
        {
            DateTime started = DateTime.Now;

            int attempts = await RandomlyRecreatedAsync(word);
            
            DisplayGenerationData(word, attempts, started);
        }


        public static string CollectWord()
        {
            string prompt = "Enter a word for the random generator to match";
            string validInput = "Please input a valid string value under 5 characters long";

            string? input;

            Console.WriteLine(prompt);
            input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input) || input.Length > 5)
            {
                Console.WriteLine(validInput);
                return CollectWord();
            }
            else 
            { 
            
                return input; 
            }
        }

        public static int RandomRecreate(string word, int attempts = 0)
        {

            string randomString;
            Random random = new Random();



            while (true)
            {
                randomString = "";

                for (int i = 0; i < word.Length; i++)
                {

                    randomString += (char)('a' + random.Next(26)); ;
                }


                if (randomString.ToString() == word)
                {
                    break;
                }

                attempts++;

            }

            return attempts;

        }

        public static void DisplayGenerationData(string word, int attempts, DateTime started)
        {
            TimeSpan timeSpan = DateTime.Now - started;

            Console.WriteLine($"It took {timeSpan.Seconds} seconds and {attempts} attempts to recreate {word}.");
        }

        public static Task<int> RandomlyRecreatedAsync(string word)
        {
            return Task.Run(() => RandomRecreate(word));
        }
    }


}
