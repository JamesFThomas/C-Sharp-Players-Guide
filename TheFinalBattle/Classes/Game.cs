using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;
using static System.Formats.Asn1.AsnWriter;

/*

Title: Actions and Players 


Story: 

The previous two challenges have had the characters taking turns directly. 

But instead of the characters deciding actions, the player controlling each character's team should pick teh action for each character. 

Eventually, there will be several actions types to choose from ( do nothing, attack, use item, etc. ).

There will also be multiple player types ( computer/AI and human input from the console window ).

A player is responsible for picking an action for each character in their party. 

The game should ask the player to choose the action rather than asking the characters to act for themselves. 

For now, the only action type will be a do-nothing action, and the only player type will be a computer player.

This challenge does not demand that you add new externally visible capabilities but make any needed changes to allow the game to work as described above, with players choosing actions instead of characters. 

If you are confident your design already supports this, claim the XP now an move on. 



Objectives: 

- The game needs to be able to represent action types. Each action should be able to run when asked. 

- The game needs to include a do nothing action, which displays the same text as in previous challenges
    --> Example: "SKELETON did NOTHING"

- The game needs to be able to represent different player types. A player needs the ability to pick an action for a character they control, given the battle's current state.

- The game needs a sole player type: a computer player ( a simple AI of sorts ). For now, the computer player will simply pick the one available option: do nothing ( and optionally wait a bit first with Thread.Sleep ).

- The game must know which player controls each party to ask the correct player to pick each character's action. 
    --> Set up the game to ask the player to select an action for each of their characters and then run the chosen action.

- Put a simple computer player in charge of each party.
    

- Note: To somebody watching, the end result of this challenge may look identical to before this challenge

*/



namespace TheFinalBattle.Classes
{
    internal class Game
    {
        public List<ICharacter> Heroes { get; set; } = new List<ICharacter>();
        public List<ICharacter> Monsters { get; set; } = new List<ICharacter>();

        public Dictionary<string, List<ICharacter>> Parties;

        public Game()
        {
            Parties = new Dictionary<string, List<ICharacter>>()
                {
                    { "heroes", Heroes },
                    { "monsters", Monsters }
                };
        }

        public void Start()
        {

            GameExplanation();

            CreateHero();

            AddToMonstersParty(new Skeleton("Skelly"));

            Battle();
        }

        public void GameExplanation()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The final battle has arrived.");
            Console.WriteLine("On a volcanic island, enshrouded in a cloud of ash, you have reached the lair of the of the Uncoded One.");
            Console.WriteLine("You have prepared for this fight and you will return Programming to the lands.");
            Console.WriteLine("Your allies have gathered to engage the Uncoded One's minions on the volcanic slopes while you and your party strike into the heart of the Uncoded One's lair to battle and destroy it.");
            Console.WriteLine("Only a True Programmer will be able to survive the encounter, defeat the Uncoded One, and escape!");
            Console.ResetColor();
        }

        public void CreateHero()
        {
            string heroName = CollectHeroName();

            TrueProgrammer hero = new TrueProgrammer(heroName);

            AddToHeroesParty(hero);
            
        }

        public string CollectHeroName()
        {
            string? input;
            string namePrompt = "\nWhat shall be our hero's title? ";
            string invalidInputPrompt = "Please enter a valid name for the hero";

            Console.Write(namePrompt);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(invalidInputPrompt);
                Console.ResetColor();
                return CollectHeroName();
            }

            return input;

        }

        public void AddToHeroesParty(ICharacter character)
        {
            Heroes.Add(character);
        }

        public void AddToMonstersParty(ICharacter character)
        {
            Monsters.Add(character);
        }

        public void HeroesTurns()
        {
            foreach (var hero in Heroes)
            {
                WhosTurn(hero);
                hero.Action();
                Thread.Sleep(500);
            }
        }

        public void MonstersTurns()
        {
            foreach (var monster in Monsters)
            {
                WhosTurn(monster);
                monster.Action();
                Thread.Sleep(500);
            }
        }

        public void WhosTurn(ICharacter character)
        {
            string prompt = $"\nIt's {character.Name}'s turn";
            Console.WriteLine(prompt);
        }

        public void Battle() 
        {
            HeroesTurns();
            MonstersTurns();
        }
    }
}






            /******************************************************* COMPLETED CHALLENGES *******************************************************/

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
    --> For example: "It's SKELETON's turn"

- The only action the game needs to support at the moment is doing nothing.
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



/*

Title: The True Programmer 

Story: 

Our Skeletons need a hero to fight. 

We'll do that by adding in the focal character of the game, the player character, which represents the player directly, called the True Programmer by in-game role.

The player will choose the true programmer's name.  


Objectives: 

- The game must represent a True programmer character with a name supplied by the user.

-  Before getting started, ask the user for the name for this character.

- The game should run a battle with the True Programmer in the hero party vs. a skeleton in the monster party.
    
- The game might look like the following: 

------------------------------------------------------------------------------------------------------------------------------------------

"It' TOG's turn"
"TOG did NOTHING"

"It' SKELETON's turn"
"SKELETON did NOTHING"

------------------------------------------------------------------------------------------------------------------------------------------

*/