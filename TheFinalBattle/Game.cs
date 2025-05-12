using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

Title: Building Character 

Story: 

This challenge is deceptively complex: it will require building out enough of the game's foundation to get two characters taking turns in a loop.

Sure, they won't be doing anything, but that's still a big step forward!

Objectives: 

- The game needs to be able to represent characters with a name and be able to take a turn.

- The game should be able to have a skeleton character with the name SKELETON

- The game should be able to represent a party with a collection of characters.

- The game should be able to run a battle composed of two parties - heroes and monsters.
    --> A battle needs to run a series of rounds where each character in each party ( heroes first ) can take a turn. 

- Before a Character takes their turn, the game should report to the user who's turn it is.
    --> For example: "It' SKELETON's turn"

- Th only action the game needs to support at the moment is doing nothing.
    --> This action is done by displaying text about doing nothing, resting, or skipping a turn in the console window. 
    --> For example: "SKELETON did NOTHING"

- The game must run a battle with a single skeleton in both the hero and monster party. 
    --> At this point the two skeletons should do nothing repeatedly. 
    --> the game could look like below: 

------------------------------------------------------------------------------------------------------------------------------------------

"It' SKELETON's turn"
"SKELETON did NOTHING"

"It' SKELETON's turn"
"SKELETON did NOTHING"

------------------------------------------------------------------------------------------------------------------------------------------

- Optional: Put a blank line between each characters turn to differentiate one turn from another

- Optional: At this point the game should run automatically. Considering adding Thread.Sleep(500); to slow the game down enough to allow the user to see what is happening over time. 

*/

namespace TheFinalBattle
{
    internal class Game
    {

        public Game() { }


        public void Start()
        {
            Console.WriteLine("The Finale Battle is working!");
        }
    }
}
