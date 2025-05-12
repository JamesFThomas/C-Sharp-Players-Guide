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
        public List<Character> Heroes { get; set; } = new List<Character>();
        public List<Character> Monsters { get; set; } = new List<Character>();

        public Dictionary<string, List<Character>> Parties;

        public Game()
        {
            Parties = new Dictionary<string, List<Character>>()
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

            Character hero = new Character(heroName);

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

        public void AddToHeroesParty(Character character)
        {
            Heroes.Add(character);
        }

        public void AddToMonstersParty(Character character)
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

        public void WhosTurn(Character character)
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
