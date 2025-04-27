/*
 
Title: The Fountain Of Objects  

Story: 

The Fountain Of Objects is a grid-based 2d world full of rooms. Most rooms are empty but a few are unique rooms. 
One room is the cavern entrance, another is the Fountain Room, which contains the Fountain Of Objects. 

The player moves through the cavern system one room at a time in order to discover the Fountain of Objects.
They player needs to activate the Fountain then return to the entrance room. 
If they player is able to this without falling in a pit they win the game. 

Unnatural darkness pervades the caverns which prevents all light natural or man made. 
The player must navigate in the dark, relying on their sense of smell and hearing to determine what room they are in and what dangers lurk in nearby rooms. 

Objectives:

- This world consists of a grid of rooms that can be referenced by their row and column.
    --> North is up, East is right, South is down, West is left.
    --> example: 4x4 grid 

               c-1 | c-2 | c-3 | c-4
             -------------------------
        r-1  | 0,0 | 0,1 | 0,2 | 0,3 |
             -------------------------
        r-2  | 1,0 | 1,1 | 1,2 | 1,3 |
             -------------------------
        r-3  | 2,0 | 2,1 | 2,2 | 2,3 |
             -------------------------
        r-4  | 3,0 | 3,1 | 3,2 | 3,3 |
             -------------------------


- The game's flow looks like this: 
    1. The player is told what they can sense in the dark => see, hear, smell
    2. The player gets a chance to perform some action by typing it in
    3. The players chosen action is resolved => the player moves. state of things iin the game changes, checking for a win or a loss, etc.
    4. The game loops back to step 1 until the player wins or loses.

- Most rooms are empty rooms with nothing to sense.

- The player is in one of the rooms can type in commands to move between rooms like this: 
    - "move north" 
    - "move south"
    - "move east"
    - "move west"
    
    --> The player can only move to adjacent rooms and can not move off the map. 

- The room (Row = 0, Column = 0) is the cavern entrance and exit. The player should start here. The player can sense light coming form outside of the cavern when in this room only.
    --> Example: "You see light in this room coming from outside of the cavern. This is the entrance" 

- The room ( Row = 0, Column = 2 ) is the Fountain Room, containing the Fountain of Objects itself. The Fountain can be either be enabled or disabled. 
    --> The player can hear the fountain but will hear different things depending on if the fountain is on or off.
        - "You hear water dripping in this room, the Fount Of Objects is here."
        - "You here rushing waters from the Fountain of Objects, it has been reactivated."
    
    --> The fountain is initially off when the game begins. 
    --> In the fountain room, the player can type the command "enable fountain" to turn the fountain on.
        ---> This command should have no effect if run in any other room and the player should be told so. 
            ----> "You can not enable the fountain in this room, it is not here."

- The player wins the game by finding the Fountain, enabling it, and then moving back to the entrance without falling in a pit or dying from another encounter. 
    --> If the player makes it to the entrance room and the fountain is on the player wins the game 

- Use different colors to display different types of text in the console window:
    - magenta => narrative items 
    - white => descriptive text
    - cyan => player input
    - yellow => text describing entrance light 
    - blue => text describing the fountain
    - red => text describing when the player dies


Hint: 
    - You may find that using a 2 dimensional array is helpful to represent the grid of rooms.

Hint: 
    - Remember your training! You do not need to solve this entire problem all at once, and you do not have to get it right the first time.
      Pick an item or two to start with and solve just those items. Rework until you are happy with it, then add the next item or two.  


Game play Example:

_________________________________________________________________________
You are in the room at ( Row = 0, Column = 0 )
You see light coming from the cavern entrance. 
What do you want to do?  move east

__________________________________________________________________________
You are in the room at ( Row = 0, Column = 1 )
What do you want to do?  move east

__________________________________________________________________________
You are in the room at ( Row = 0, Column = 2 )
You hear water dripping in this room. The fountain of Objects is here!
What do you want to do?  enable fountain

__________________________________________________________________________
You are in the room at ( Row = 0, Column = 2 )
You here rushing waters from the Fountain of Objects, it has been reactivated!
What do you want to do?  move west

__________________________________________________________________________
You are in the room at ( Row = 0, Column = 1 )
What do you want to do?  move west

_________________________________________________________________________
You are in the room at ( Row = 0, Column = 0 )
The Fountain of Objects has been reactivated, and you have escaped with your life! 
You win!



*/


Game Game = new Game(); // create a new game object
Game.Start(); // start the game



public class Game
{
    // Responsible for starting the game and managing the game loop

    public void Start()
    {
        
        DisplayGameExplanation();

        var board = CreateBoard(); 
        var player = new Player();



        while (player.IsAlive) // while the player is alive
        {
            board.DisplayBoard(player); 

            board.MovePlayer(player);

            // Check if the player has won or lost
            var didPlayerWin = (player.CurrentRow == 0 && player.CurrentColumn == 0) && board.IsFountainOn == true;
            
            if ( didPlayerWin == true )
            {
                board.PlayerWon(player);
                break;
            }
        }

    }

    // Create Game explanation to displayed at start of Game 
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

        Console.ResetColor(); // reset text color to default
    }

    public Board CreateBoard() 
    {
        string? size = null;

        Console.ForegroundColor = ConsoleColor.White; // descriptive text in white

        Console.WriteLine("Please select a board size: small, medium, or large");

        Console.ForegroundColor = ConsoleColor.Cyan; // change color for user input text 

        size = Console.ReadLine()?.ToLower();

        Console.ResetColor(); // reset text color to default

        if (String.IsNullOrWhiteSpace(size) || (size != "small" && size != "medium" && size != "large"))
        {
            Console.ForegroundColor = ConsoleColor.White; // descriptive text in white

            Console.WriteLine("Must enter a valid board size");
            
            return CreateBoard(); 
        }

        Board board = new Board(size);

        board.LoadBoard(); 

        return board; 
    }
}

public class Board
{
    public string Size { get; set; }

    public int Rows { get; set; }

    public int Columns { get; set; }

    public IRoom[,] Rooms { get; set; }

    public bool IsFountainOn { get; set; } = false;

    public bool QuestComplete { get; set; } = false;

    public Board( string size )
    {
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

        // Load the rest of the rooms with empty rooms
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

    // Display the board to the player
    public void DisplayBoard(Player player)
    {
        Console.WriteLine($"\n{Size} Game Board");

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                var room = Rooms[i, j];
                var isPlayerLocation = i == player.CurrentRow && j == player.CurrentColumn;

                if (room != null && room == Rooms[0,0])
                {
                    Console.Write($"{room.Type.ToString()[0]} " );
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

    // Ensure the move is on the board
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
        Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
        Console.WriteLine($"You can not move in that direction: {direction}");
    }

    public void MovePlayer(Player player)
    {

        string? input = player.GetInput();

        // ensure that the move is valid
        if(input == "move north")
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
            player.IsAlive = false;
            Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
            Console.WriteLine("Thanks for playing, Quitter!");
            Console.ResetColor();
            return;
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

        Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
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
        
        Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
        Console.WriteLine("You can not interact with the fountain because it is not in this room.");
        Console.ResetColor();
        return;
    }

    public void PlayerWon(Player player)
    {
        Console.ForegroundColor = ConsoleColor.Yellow; // text in yellow
        Console.WriteLine("You Win! Thanks For Playing!");
        Console.ResetColor();
        player.IsAlive = false; // end the game
        return;

    }

    public void PlayerLost(Player player)
    {
        Console.ForegroundColor = ConsoleColor.Red; // text in red
        Console.WriteLine("You Lost! Game Over!");
        Console.ResetColor();
    }

}


public interface IRoom 
{ 
    int Row { get; set; } 
    int Column { get; set; } 
    string Location { get; } 
    string Type { get; set; } 
    void Sense(bool isFountainOn = false); 
}

public interface IActivatableRoom : IRoom 
{ 
    void Enable(); 
    void Disable(); 
}

public class Empty : IRoom
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string Location => $"(Row = {Row}, Column = {Column})";
    public string Type { get; set; }

    public Empty(int row, int column, string type)
    {
        Row = row;
        Column = column;
        Type = type;
    }
    public void Sense(bool isFountainOn = false)
    {
        Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
        Console.WriteLine("You sense nothing but the unnatural darkness, this room is empty!");
        Console.ResetColor(); 
        return;
    }
}



public class Entrance : IRoom
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string Location => $"(Row = {Row}, Column = {Column})";
    public string Type { get; set; }
    public Entrance(int row, int column, string type)
    {
        Row = row;
        Column = column;
        Type = type;
    }

    public void Sense(bool isFountainOn) 
    {
        if (isFountainOn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // entrance text in yellow
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
            Console.ResetColor(); 
            return;
        }

        Console.ForegroundColor = ConsoleColor.Yellow; 
        Console.WriteLine("You see light coming from the cavern entrance.");
        Console.ResetColor(); 
        return;
    }

}

public class  Fountain : IActivatableRoom
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string Location => $"(Row = {Row}, Column = {Column})";
    public string Type { get; set; }
    public Fountain(int row, int column, string type)
    {
        Row = row;
        Column = column;
        Type = type;
    }

    public void Sense(bool isFountainOn)
    {
        if (isFountainOn)
        {
            Console.ForegroundColor = ConsoleColor.Blue; // fountain text in blue
            Console.WriteLine("You here rushing waters from the Fountain of Objects, it has been reactivated!");
            Console.ResetColor(); 
            return;
        }

        Console.ForegroundColor = ConsoleColor.Blue; 
        Console.WriteLine("You hear water dripping in this room. The fountain of Objects is here!");
        Console.ResetColor(); 
        return;
    }

    public void Enable()
    {
        Console.ForegroundColor = ConsoleColor.Blue; 
        Console.WriteLine("The Fountain of Objects has been reactivated!");
        Console.ResetColor(); 
        return;
    }

    public void Disable()
    {
        Console.ForegroundColor = ConsoleColor.Blue; 
        Console.WriteLine("The Fountain of Objects has been DeActivated!");
        Console.ResetColor(); 
        return;
    }
}


public class Player
{
    public bool IsAlive { get; set; } = true;
    public int CurrentRow { get; set; }
    public int CurrentColumn { get; set; }

    public string Location => $"(Row = {CurrentRow}, Column = {CurrentColumn})";

    public string GetInput()   
    {
        Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
        string prompt = "What do you want to do? ";

        Console.Write(prompt);

        Console.ForegroundColor = ConsoleColor.Cyan; // user input text in cyan
        string? userInput = Console.ReadLine()?.ToLower();
        Console.ResetColor(); 

        // Check if input is valid  
        if (string.IsNullOrWhiteSpace(userInput) || 
            userInput != "move north" && 
            userInput != "move south" && 
            userInput != "move east" && 
            userInput != "move west" && 
            userInput != "help" && 
            userInput != "quit" && 
            userInput != "enable fountain" && 
            userInput != "disable fountain")
        {
            Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
            Console.WriteLine("Must enter a valid input");
            Console.ResetColor(); 
            return GetInput();
        }

        
        if (userInput == "help")
        { 
            ShowHelp(); 
            return GetInput(); 
        }

        return userInput;
    }

    public void ShowHelp()
    {
        Console.ForegroundColor = ConsoleColor.White; // descriptive text in white
        Console.WriteLine("These are the actions that you can take.");
        Console.WriteLine("You can move through rooms: move north, move south, move east, move west.");
        Console.WriteLine("You can interact with the Fountain Of Objects: enable fountain, disable fountain.");
        Console.WriteLine("You can ask for help: help");
        Console.WriteLine("You can quit the game: quit");
        Console.ResetColor();
        return;
    }
 }

