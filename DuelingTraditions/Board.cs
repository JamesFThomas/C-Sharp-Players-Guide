using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelingTraditions
{
    public class Board
    {
        public string Size { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public IRoom[,] Rooms { get; set; }

        public bool IsFountainOn { get; set; } = false;

        public bool QuestComplete { get; set; } = false;

        DateTime startTime { get; set; } // variable to store the start time
        DateTime endTime { get; set; } // variable to store the end time

        public Board(string size)
        {
            startTime = DateTime.Now; // set the start time to the current time

            if (size == "small")
            {
                Rooms = new IRoom[4, 4];
                Size = "Small";
                Rows = 4;
                Columns = 4;
            }
            else if (size == "medium")
            {
                Rooms = new IRoom[6, 6];
                Size = "Medium";
                Rows = 6;
                Columns = 6;
            }
            else
            {
                Rooms = new IRoom[8, 8];
                Size = "Large";
                Rows = 8;
                Columns = 8;
            }
        }

        public void LoadBoard()
        {
            Rooms[0, 0] = new Entrance(0, 0, "Entrance");

            Rooms[0, 2] = new Fountain(0, 2, "Fountain");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Rooms[i, j] == null)
                    {
                        Rooms[i, j] = new Empty(i, j, "Empty");
                    }
                }
            }

        }

        public void DisplayBoard(Player player)
        {
            Console.WriteLine($"\n{Size} Game Board\n");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var room = Rooms[i, j];
                    var isPlayerLocation = i == player.CurrentRow && j == player.CurrentColumn;

                    if (room != null && room == Rooms[0, 0])
                    {
                        Console.Write($"{room.Type.ToString()[0]} ");
                    }
                    else if (isPlayerLocation)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(String.Concat(Enumerable.Repeat("--", Rows)));
            }
        }

        public bool IsAValidMove(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                return false;
            }

            return true;
        }

        public void InvalidMove(string direction)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You can not move in that direction: {direction}");
        }

        public void MovePlayer(Player player)
        {

            string? input = player.GetInput();

            if (input == "move north")
            {
                if (IsAValidMove(player.CurrentRow - 1, player.CurrentColumn))
                {
                    player.CurrentRow -= 1; // update player position
                    SenseRoom(player); // sense the room
                    return;
                }

                InvalidMove(input);
                MovePlayer(player);
                return;
            }
            else if (input == "move south")
            {
                if (IsAValidMove(player.CurrentRow + 1, player.CurrentColumn))
                {
                    player.CurrentRow += 1;
                    SenseRoom(player);
                    return;
                }

                InvalidMove(input);
                MovePlayer(player);
            }
            else if (input == "move east")
            {
                if (IsAValidMove(player.CurrentRow, player.CurrentColumn + 1))
                {
                    player.CurrentColumn += 1;
                    SenseRoom(player);
                    return;
                }

                InvalidMove(input);
                MovePlayer(player);
                return;
            }
            else if (input == "move west")
            {
                if (IsAValidMove(player.CurrentRow, player.CurrentColumn - 1))
                {
                    player.CurrentColumn -= 1;
                    SenseRoom(player);
                    return;
                }

                InvalidMove(input);
                MovePlayer(player);
                return;
            }
            else if (input == "enable fountain")
            {
                EnableFountain(player);
                return;
            }
            else if (input == "disable fountain")
            {
                DisableFountain(player);
                return;
            }
            else if (input == "quit")
            {
                PlayerQuit(player);
            }
        }

        public void SenseRoom(Player player)
        {
            // Sense the room
            Rooms[player.CurrentRow, player.CurrentColumn].Sense(IsFountainOn);
        }

        public void EnableFountain(Player player)
        {

            var currentRoom = Rooms[player.CurrentRow, player.CurrentColumn];


            if (currentRoom is IActivatableRoom activatableRoom)
            {
                IsFountainOn = true;
                activatableRoom.Enable();
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You can not interact with the fountain because it is not in this room.");
            Console.ResetColor();
            return;
        }

        public void DisableFountain(Player player)
        {
            var currentRoom = Rooms[player.CurrentRow, player.CurrentColumn];

            if (currentRoom is IActivatableRoom activatableRoom)
            {
                IsFountainOn = false;
                activatableRoom.Disable();
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You can not interact with the fountain because it is not in this room.");
            Console.ResetColor();
            return;
        }

        public void PlayerWon(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            TimeInCavern();
            Console.WriteLine("\nYou Win! Thanks For Playing!");
            Console.ResetColor();
            player.IsAlive = false; // end the game
            return;

        }

        public void PlayerLost(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TimeInCavern();
            Console.WriteLine("\nYou Lost! Game Over!");
            Console.ResetColor();
            player.IsAlive = false;
        }

        void PlayerQuit(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red; // text in red
            TimeInCavern();
            Console.WriteLine("\nThanks for playing, Quitter!");
            Console.ResetColor();
            player.IsAlive = false;
            return;
        }

        public void TimeInCavern()
        {
            endTime = DateTime.Now; // set the end time to the current time
            TimeSpan elapsedTime = endTime - startTime; // calculate the elapsed time
            Console.WriteLine($"You spent {elapsedTime.TotalSeconds} seconds in the cavern.");
        }

    }
}
