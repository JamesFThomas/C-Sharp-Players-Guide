/*
 
Title: Hangman

In Hangman, the computer picks a random word for the player to guess.
The player then begins to guess the word by picking letters from the alphabet, which get filled in progressively in the display if guessed correctly, finally revealing the word. 
The player con only get so many letters wrong, ( a letter not found in the word) before loosing the game. 

An example run of the game is shown below: 

Word: - - - - - - - - - | Remaining: 5 | Incorrect: | Guess: e
Word: - - - - - - - - E | Remaining: 5 | Incorrect: | Guess: i
Word: I - - - - - - - E | Remaining: 5 | Incorrect: | Guess: u
Word: I - - U - - - - E | Remaining: 5 | Incorrect: | Guess: o
Word: I - - U - - - - E | Remaining: 4 | Incorrect: O | Guess: a
Word: I - - U - A - - E | Remaining: 4 | Incorrect: O | Guess: t
Word: I - - U T A - - E | Remaining: 4 | Incorrect: OS | Guess: s
Word: I - - U T A - - E | Remaining: 3 | Incorrect: OSR | Guess: r
Word: I M M U T A - - E | Remaining: 2 | Incorrect: OSR | Guess: m
Word: I M M U T A - L E | Remaining: 2 | Incorrect: OSR | Guess: l
Word: I M M U T A B L E | Remaining: 2 | Incorrect: OSR | Guess: b
Word: IMMUTABLE
You Won!


- The game picks a word at random form a list of words. 
- The game's state is shown to player as displayed above in the example. 
- The player can pick a letter, but if the pick a letter they already chose they must pick again. 
- The game should update the state based the current letter the player picked.
- The game should be able to detect when the player has guessed all letters and declare a win.
- The game needs to detect a loss for the player, when they are out of incorrect guesses.  

Objectives: 
- User CRC cards (or a suitable alternative) to outline the objects and classes that may be needed to make the game of 15-Puzzle.
- You don't need to create the whole game at this point just come up with a potential design. 

*/

// Noun Extraction 
// Game,  Word List, Player,  


/*
 
Game Class

Track?
- display string template 

- current game state variables
    -- current word
        ---> Word_List.NewWord()

    -- total number of guesses allowed
        ---> Word_List.NewWord()

    -- incorrect guesses 
        ---> Word_List.Guesses()

    -- remaining guesses = total_guesses - incorrect_guesses

    -- last user guest
        ---> Player.NewGuess()




Do?
- Start a new game
    --> .Run()
        ---> creates a new Player()
        ---> 

- Display current game state
    --> .DisplayGameState()
 
*/


/*

Word_List Class

Track?
- list words
    --> string[] wordList = []

- guesses and if they are correct
    --> [,,] guesses = []

Do?
- generate a list of random words
    --> .GenerateList()

- give a new random word from the word list and total guesses for that word
    --> .NewWord()

- check to see if guess is in word, log guess and correctness
    --> IsCorrectGuess()
 
*/


/*

Player Class

Track?
- previous picks
    --> string[] guesses = [];

Do?
- collect user input / make a new guess
    .NewGuess()
 

*/


