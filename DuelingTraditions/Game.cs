using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelingTraditions
{
    public class Game
    {

        public void Start()
        {

            DisplayGameExplanation();

            var board = CreateBoard();
            var player = new Player();



            while (player.IsAlive)
            {
                board.DisplayBoard(player);

                board.MovePlayer(player);

                var didPlayerWin = (player.CurrentRow == 0 && player.CurrentColumn == 0) && board.IsFountainOn == true;

                if (didPlayerWin == true)
                {
                    board.PlayerWon(player);
                    break;
                }
            }

        }

        public void DisplayGameExplanation()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; // narrative items in magenta

            Console.WriteLine(@"
            Welcome to the Fountain of Objects!
            You are in a dark cavern system with many rooms.
            Your goal is to find the Fountain of Objects and return to the entrance.
            Be careful, there are dangers lurking in the darkness!
            Good luck!
            ");

            Console.ResetColor();
        }

        public Board CreateBoard()
        {
            string? size = null;

            Console.ForegroundColor = ConsoleColor.White; // descriptive text in white

            Console.Write("Please select a board size: small, medium, or large: ");

            Console.ForegroundColor = ConsoleColor.Cyan;

            size = Console.ReadLine()?.ToLower();

            Console.ResetColor();

            if (String.IsNullOrWhiteSpace(size) || (size != "small" && size != "medium" && size != "large"))
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Must enter a valid board size");

                return CreateBoard();
            }

            Board board = new Board(size);

            board.LoadBoard();

            return board;
        }
    }
}
