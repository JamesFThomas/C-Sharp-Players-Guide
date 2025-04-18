/*
 
Title: Tic Tac Toe

Complete the game of Tic Tac Toe that allows two Players to compete against each other. 

The below features are required:

- Two human players take turns entering their choices on the same keyboard.

- The players designate which square that they want to play in.
    --> Hint: You can use the number pad as a guide. For example if the player chooses 7 they mark is put in top left corner of the board.

- They game should prevent players from choosing squares that are already occupied. 
    --> If such a move is chosen they player should be informed of the problem and given another chance to make a choice. 

- The game must detect win a player wins or when the board is full with no winner, a "draw" or cat.

- When the game is over the outcome is displayed to the players. 

- The state of the board must be displayed to player after each play. 
    --> Hint: one way to show the board could be like like below:

    It is X's turn.
        | X |   
    -------------
        | O | X
    -------------
      O |   |   
    What square do you want to play in?



Objectives: 

- Build the game of Tic Tac Toe as described in the requirements above. Starting with CRC cards is recommended, but the goal is to make working software, not CRC cards  

- Answer this question: How might you modify your completed program if running multiple rounds was a requirement (for example a best out five series) ? 

*/

// Noun Extraction
//--> Player, Board, Square, Game, Move


// Application 

Game game = new Game();

game.PlayGame();


// Classes

/*

Game Class 

Track?
- what player's turn it is
- track rounds players have played

Do?
- display whose turn it is - done
- display the board state for players - board.DisplayBoard() working
- display winning or draw message prompt to player   - board.CheckBoard() working
- collect player input - not done 
 
*/
public class Game
{ 
   private int roundsPlayed { get; set; } = 1;

   public void PlayGame()
    {
        // create a new board a two new players
        Board board = new Board();
        Player playerX = new Player("X");
        Player playerO = new Player("0");

        // display greeting message
        Greeting();

        // display whose turn it is
        DisplayPLayersTurn();


        while (  board.boardState == "open") 
        { 
        // let player make a move
        playerX.MakeMove(board);
        playerO.MakeMove(board);

        // check the board for a winner or draw
        // check board state before increasing round 
        board.CheckBoard();

        // repeat until game is over
        IncreaseRoundsPlayed();

        }

        board.ResetBoard();
        EndGame();

    }

    public void DisplayPLayersTurn()
    {
        // Fixing the CS1003 error by properly parenthesizing the conditional expression  
        Console.WriteLine($"It is the {(roundsPlayed % 2 == 0 ? "X" : "O")}'s turn to play.");
    }

    public void Greeting()
    {
        Console.WriteLine("Tic Tac Toe.");
        Console.WriteLine("Let's do this, Player X wil go first!");
    }

    public void IncreaseRoundsPlayed() // make into a property later 
    {
        // Increase the rounds played by 1
        roundsPlayed += 1;
    }

    public void EndGame()
    {
        roundsPlayed = 1;
        Console.WriteLine("Game Over! Thanks for playing.");
    }
}

/*

Board Class 

Track?
- open squares on the board
- track board state

Do?
- display the board state - working 
- reset the board - working
- mark the board with a player's move - working 
- check board then indicate when a player has won or board is full - working
 
*/
public class Board
{
    // How will I represent the board? Tuple with named values
    private (string one, string two, string three, string four, string five, string six, string seven, string eight, string nine) board = ("", "", "", "", "", "", "", "", "");
    public string boardState { get; set; } = "open"; // open, full, won 

    public void DisplayBoard()
    {
        //Console.Clear();
        Console.WriteLine($" {board.seven} | {board.eight} | {board.nine}" +
            $"\r\n-----------" +
            $"\r\n {board.four} | {board.five} | {board.six} " +
            $"\r\n-----------" +
            $"\r\n {board.one} | {board.two} | {board.three} ");

    }

    public void ResetBoard()
    {
        // Reset the board to empty
        board = ("", "", "", "", "", "", "", "", "");
    }

    public void UpdateBoard( string squareNumber, string playerMark)
    {
        // Update the square value with players mark 
        switch (squareNumber)
        {
            case "1":
                board.one = playerMark;
                break;
            case "2":
                board.two = playerMark;
                break;
            case "3":
                board.three = playerMark;
                break;
            case "4":
                board.four = playerMark;
                break;
            case "5":
                board.five = playerMark;
                break;
            case "6":
                board.six = playerMark;
                break;
            case "7":
                board.seven = playerMark;
                break;
            case "8":
                board.eight = playerMark;
                break;
            case "9":
                board.nine = playerMark;
                break;
        }

        // check to see if there is a winner or if the board is full

    }

    public bool IsSquareFree(string squareNumber)
    {
        // Check the square number and access the corresponding tuple item  
        switch (squareNumber)
        {
            case "1":
                return board.one == "";
            case "2":
                return board.two == "";
            case "3":
                return board.three == "";
            case "4":
                return board.four == "";
            case "5":
                return board.five == "";
            case "6":
                return board.six == "";
            case "7":
                return board.seven == "";
            case "8":
                return board.eight == "";
            case "9":
                return board.nine == "";
            default:
                return false;
        }
    }

    public void CheckBoard()
    {

        // destructor the tuple to get the values
        var (one, two, three, four, five, six, seven, eight, nine) = board;

        // check for a winner
        if(one != "" && one == two && one == three)
        {
            DisplayWinner(one);
            boardState = "won";
            return;
        }
        if (four != "" && four == five && four == six)
        { 
            DisplayWinner(four);
            boardState = "won";
            return;
        }
        if (seven != "" && seven == eight && seven == nine)
        {
            DisplayWinner(seven);
            boardState = "won";
            return;
        }
        if (one != "" && one == four && one == seven)
        {
            DisplayWinner(one);
            boardState = "won";
            return;
        }
        if (two != "" && two == five && two == eight)
        { 
            DisplayWinner(two);
            boardState = "won";
            return;
        }
        if (three != "" && three == six && three == nine)
        {
            DisplayWinner(three);
            boardState = "won";
            return;
        }
        if (one != "" && one == five && one == nine)
        {
            DisplayWinner(one);
            boardState = "won";
            return;
        }
        if (three != "" && three == five && three == seven)
        { 
            DisplayWinner(three);
            boardState = "won";
            return;
        }

        // check for a draw
        if (one != "" && two != "" && three != "" && four != "" && five != "" && six != "" && seven != "" && eight != "" && nine != "")
        {
            Console.WriteLine("The board is full, Game is a draw!");
            boardState = "draw";
            return;
        }

        // keep playing
        Console.WriteLine("No winner yet, keep playing!");
        boardState = "open";
        return;

    }

    internal void DisplayWinner(string winner)
    {
        Console.WriteLine($"{winner} is the winner!");
    }

}

/*

Player Class 

Track?
- It can simply take th user input nothing to track

Do?
- take user input to make a move
 
*/
public class Player
{ 
    private string playerMark { get; set; }
    public Player( string mark )
    {
        playerMark = mark;

    }

    public void MakeMove(Board gameBoard)
    {
        string prompt1 = "What open square do you want to play in? (1-9)";

        // display gameBoard here  
        gameBoard.DisplayBoard();

        // prompt player for input  
        Console.Write(prompt1);

        // get player input  
        string? squareNumber = Console.ReadLine();

        // check if input is null or blank input  
        if (string.IsNullOrWhiteSpace(squareNumber))
        {
            Console.WriteLine("Please enter a valid square number.");
            MakeMove(gameBoard); 
            return; 
        }

        // check if square is free  
        if (!gameBoard.IsSquareFree(squareNumber))
        {
            Console.WriteLine("The square is already occupied. Please choose another square.");
            MakeMove(gameBoard);  
            return; 
        }
        else
        {
            gameBoard.UpdateBoard(squareNumber, playerMark);
            return;
        }
    }

}