/*
 
Title: 15 Puzzle

The game of 15-Puzzle contains a set of numbered titles on a board with a single open slot.
The goal is to rearrange the titles to put the numbers in order, with the empty space in the bottom right corner.

- The player needs to be able to manipulate the board to rearrange it. 
- The current state of the game needs to be displayed to the user.
- The game needs to detect when it has been solved and tell the player they won.
- The game needs to be able to generate random puzzles to solve.  
- The game needs to track and display how many moves the player has made. 

Objectives: 
- User CRC cards (or a suitable alternative) to outline the objects and classes that may be needed to make the game of 15-Puzzle.
- You don't need to create the whole game at this point just come up with a potential design. 

- Answer this question: Would your design need to change if we also wanted 3x3 or 5x5 boards? 
    --> The classes I have fleshed out would not need to change. 
        The specific method code for generating a new board can 
        be updated to take in size parameters so that isn't an issue.

*/

// Noun extraction 
// Game
// Board
// PLayer


/* 

Game Class:

What does a Game need to track? 
- track total moves made
    --> Player.totalMoves()

- if puzzle board has been solved
    --> Board.currentState()

What does a game need to do? 
- Start a new game
    --> Game.Run()
        ---> creates a new player 

- collect user input for each new move 
    --> Player.MakeMove()

- display number of player moves made
    --> Game.MovesDisplay()

- display winner message to user if/when solved
    --> Game.UserWon()


*/


/* 

Board Class


What does a Board need to track?
- track current board values and their position (board state)
    --> [ ,, ] board { get; }

What does a Board need to do? 
- generate a new puzzle randomly
    --> GenerateNewBoard( int height, int width )

- update the board 
    --> UpdateBoard( int move)

- display the state of the board
    --> GetBoard()

- indicate when the board has been solved 
    --> wasSolved()
 
 */


/* 

Player Class

What does a Player need to track? 
- the moves it has made
    --> int totalMove { get; set; }


What does a player need to do? 
- make a new move on the board 
    --> makeMove()

*/