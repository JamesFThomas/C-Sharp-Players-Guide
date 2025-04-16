/*

Title: Rock Paper Scissors

Provide and object oriented design - set of objects, classes, and how they interact for the game of Rock Paper Scissors.

Game Explanation:

- Two human players complete against each other. 

- Each player picks Rock Paper or Scissors

- Depending on the Players choice a winner is determined.
    --> Rock beats Scissors
    --> Scissors beats Paper
    --> Paper beats Rock
    --> both players pick same option => draw

- The game must display who won the round. 

- The game will keep running rounds until the window is closed but must remember the historical record of how:
    --> many times each player won 
    --> how many total draws

Objectives: 

- Use CRC cards or a suitable alternative to outline the objects and classes that may be needed to make the game fo rock paper scissors. 

- You don't need to create this full game right now, just come up with a potential design as a starting point. 

 
 */



// Start with noun extraction 
/*
 Game, Player, Counts (wins, draws, rounds), Choices (rock, paper, scissors) 
 */

// Counts can be properties/ fields within the different classes
// Choices can be enumeration used to evaluate Player choices

/*
Class: Game  

What does a game need to track or do?
- track total rounds
- track total draws
- display the winner of the round

Collaboration:
- collect Player choices


*/

/*
Class: Player

What does a player need to track or do? 
- make a choice 
- track choices 

Collaboration:
- collects user input for round

*/