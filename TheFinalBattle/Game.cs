using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



namespace TheFinalBattle
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
            Console.WriteLine("The Finale Battle has begun!");

            CreateHero();

            AddToMonstersParty(new Character("skeleton-m"));

            Battle();
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



                                                        /******************************************************* COMPLETED *******************************************************/

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