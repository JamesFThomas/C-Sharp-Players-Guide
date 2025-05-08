/*

Challenge #1:  
Title: Asynchronous Random Words

Story:

On the island of Tasken, you meet Awat, who tells you that being a True Programmer isn't all that hard.
His ancestors have been the stewards of the Asynchronous Medallion, yet Awat uses it as a food dish for his cat. 
"A thousand miniods with a thousand random generators will also eventually produce "hello world"!" he claims.
Indeed they could but you know it would take awhile. 
With tasks, you can allow a human to pick a word and randomly generate the word asynchronously. 
Doing this will show Awat how long it will take to randomly generate the words "hello" and "world" convincing him that a Programmer's skill means something. 

Objectives: 

- Make the method int RandomRecreate(string word).
    --> It should take the string's length and generate and equal number of random characters. 
    --> It is okay to assume all words only use lowercase letters. 
    --> One way to randomly generate a lowercase letter is (char)('a' + random.Next(26))
    --> This method should loop until it randomly generates the target word, counting the required attempts.
    --> The return value is the number of attempts. 

- Make the method Task<int> RandomlyRecreatedAsync(string word) that schedules the above method to run asynchronously (Task.Run is one option)

- Have your main method ask the user for a word. 
    --> Run the RandomlyRecreatedAsync method and await it's result and display it. 
    --> Note: Be careful about long words! keep the length of the word below 7 characters. 

- Use DateTime.Now before and after the async task runs to measure the wall clock time it took.
    --> Display the time elapsed (level 32)

 
 */

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

namespace AsynchronousRandomWords
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Program program = new Program();
            DateTime started = DateTime.Now;
            int attempts = await program.RandomlyRecreatedAsync("hello");
            DateTime ended = DateTime.Now;

            TimeSpan timeSpan = ended - started;

            Console.WriteLine($"Attempts to recreate 'hello': {attempts}");
            Console.WriteLine($"The process took {timeSpan.Seconds} secs");
        }

        public int RandomRecreate(string word, int attempts = 0)
        {


            Random random = new Random();
            string randomString;

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

        public Task<int> RandomlyRecreatedAsync(string word)
        {
            return Task.Run(() => RandomRecreate(word));
        }
    }


}


