using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeptisGame
{
    internal class Game
    {
        static int targetNumber {  get; set; } 
        static List<int> guesses = new List<int>();
        static bool stillGuessing = true; 

        public Game() { }

        public void Start()
        {

            Player p1 = new Player(1);
            Player p2 = new Player(2);

            Greeting();
            PickRandomNumber();

            while (stillGuessing)
            { 
                CollectPlayerGuess(p1);
                CollectPlayerGuess(p2);
            }



        }

        public void Greeting()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to Exepti's Game ");
            Console.WriteLine("The computer will chose a random number between 0-9");
            Console.WriteLine("Players 1 & 2 will take turns guessing the number until one guesses correctly to win.");
            Console.WriteLine("You can't pick the same number twice.");
            Console.WriteLine("Here we go!\n");
            Console.ResetColor();
        }

        public void PickRandomNumber()
        { 
            Random random = new Random();
            targetNumber = random.Next(10);
        
        }

        public bool IsValidGuess( int guess )
        {
            if (guesses.Contains(guess)) return false;

            return true;
        }

        public void TrackPlayerGuess(int guess)
        { 
            guesses.Add(guess);
        }

        public void GameOver()
        {
            Console.WriteLine("\nThanks for playing");
        }

        public void CollectPlayerGuess(Player player)
        { 
            int guess = player.Guess();

            if (!IsValidGuess(guess))
            { 
                Console.WriteLine($"{player.Id} that number was already used, guess again.\n");
                CollectPlayerGuess(player);
                return;
            }

            if (guess == targetNumber)
            {
                stillGuessing = false;
                throw new CorrectGuessException("You guessed correctly");
            }

            
            Console.WriteLine($"{guess}, Good Guess player {player.Id}");
            TrackPlayerGuess(guess);
        }


    }
}
