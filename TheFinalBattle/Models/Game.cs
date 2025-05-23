﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;
using TheFinalBattle.Models;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TheFinalBattle.Classes
{
    internal class Game
    {
        public List<Character> Heroes { get; set; } = new List<Character>();
        public List<List<Character>> Monsters { get; set; } = new List<List<Character>>();

        public Game()
        {
            Monsters = new List<List<Character>>()
               {
                   new List<Character>(),   
                   new List<Character>(),
                   new List<Character>()
            };
        }


        public void Start()
        { 
            GameExplanation();

            var (player1, player2) = ChooseGameMode();

            CreateHeroAndMonsterParties();

            Battle(player1,player2);

        }

        private (IPlayer, IPlayer) ChooseGameMode()
        {
            IPlayer player1 = null!;
            IPlayer player2 = null!;
            string? gameMode;
            int convertedInput;

            string invalidEntryPrompt = "\nYour entry was NOT a valid game mode";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nChoose what game play mode you want.");
            Console.WriteLine("1 => Single player");
            Console.WriteLine("2 => Double player versus");
            Console.WriteLine("3 => I just want to watch!");
            Console.ResetColor();

            gameMode = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(gameMode) || !int.TryParse(gameMode, out convertedInput) || (convertedInput < 1 || convertedInput > 3))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(invalidEntryPrompt);
                Console.ResetColor();
                return ChooseGameMode();
            }

            switch (convertedInput)
            {
                case 1:
                    player1 = new Human("Player 1");
                    player2 = new Computer("Computer");
                    break;
                case 2:
                    player1 = new Human("Player 1");
                    player2 = new Human("Player 2");
                    break;
                case 3:
                    player1 = new Computer("Player 1");
                    player2 = new Computer("Computer");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("You like to watch it. It's cool man no judgement!");
                    Console.ResetColor();
                    break;
            }

            return (player1, player2);
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

        public void CreateHeroAndMonsterParties()
        {
            string heroName = CollectHeroName();

            TrueProgrammer hero = new TrueProgrammer(heroName);

            VinFletcher vin = new VinFletcher();

            AddToHeroesParty(hero);

            AddToHeroesParty(vin);

            AddToMonstersParty();

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

        public void AddToMonstersParty()
        {
            Character character = new Skeleton("Skelly");
            Character character1 = new Skeleton("Skeletor");
            Character character2 = new Skeleton("Skeletia");
            Character finalBoos = new UncodedOne("Boss Hog");

            Monsters[0].Add(character);     // Battle 1
            Monsters[1].Add(character1);    // Battle 2
            Monsters[1].Add(character2);    // Battle 2
            Monsters[2].Add(finalBoos);     // Battle 3
        }

        private void CheckCharacterHealth(Character character, List<Character> party)
        {
            if (character.CurrentHP == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"{character.Name} has been defeated!");
                Console.ResetColor();
                party.Remove(character);
            }
        }

        public void WhosTurn(ICharacter character)
        {
            string prompt = $"\nIt's {character.Name}'s turn";
            Console.WriteLine(prompt);
        }

        public void HuzzahTheHeroesWon()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nHeroes have lost! The Uncoded One's forces have prevailed.");
            Console.ResetColor();
        }

        public void BooTheMonstersWon()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nHeroes have won! The Uncoded One has been defeated.");
            Console.ResetColor();
        }

        private void CheckBattleOutcome()
        {
            
            bool heroesAlive = Heroes.Any(character => character.CurrentHP > 0);
            bool monstersAlive = Monsters.Any(party => party.Any(character => character.CurrentHP > 0));

            if (!heroesAlive)
            {
                HuzzahTheHeroesWon();
                return;
            }
            else if (!monstersAlive)
            {
                BooTheMonstersWon();
                return;
            }
        }

        public void HeroesTurns(IPlayer player, List<Character> targets)
        {
            var currentTarget = targets[0];

            foreach (var hero in Heroes)
            {
                DisplayBattleStatus(hero, Heroes, Monsters);
                WhosTurn(hero);
                player.PickBehavior(hero, currentTarget);
                CheckCharacterHealth(currentTarget, targets);
                Thread.Sleep(500);
            }
        }


        public void MonstersTurns(IPlayer player, int index)
        {
            var targets = Heroes;
            var currentTarget = targets[0];

            foreach (var monster in Monsters[index])
            {
                DisplayBattleStatus(monster, targets, Monsters);
                WhosTurn(monster);
                player.PickBehavior(monster, currentTarget);
                CheckCharacterHealth(currentTarget, Heroes);
                Thread.Sleep(500);
            }
        }

        public void DisplayBattleStatus(Character currentCharacter,  List<Character> heroes, List<List<Character>> monsters)
        {
            var allMonsters = monsters.SelectMany(monsterParty => monsterParty);

            Console.WriteLine("\n======================================================== BATTLE ========================================================\n");

            foreach (var hero in heroes)
            {
                if (hero == currentCharacter)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }

                Console.WriteLine($"{hero.Name} _______________ {hero.Health}");

                Console.ResetColor();
            }

            Console.WriteLine("\n----------------------------------------------------------- VS --------------------------------------------------------\n");




            foreach (var monster in allMonsters)
            {
                if (monster == currentCharacter)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }

                Console.WriteLine($"                                                                                  {monster.Name} _____________ {monster.Health}");

                Console.ResetColor();
            }

            Console.WriteLine("=========================================================================================================================");

        }


        public void Battle(IPlayer player1, IPlayer player2)
        {

            int currentIndex = 0;

            while (Heroes.Any() && currentIndex < Monsters.Count ) 
            {
                var currentMonsterParty = Monsters[currentIndex];

                HeroesTurns(player1, currentMonsterParty);
                if (!currentMonsterParty.Any()) 
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Monster party {currentIndex + 1} has been defeated!"); 
                    Console.ResetColor();
                    CheckBattleOutcome();
                    currentIndex++; 
                    continue; 
                }

                MonstersTurns(player2, currentIndex);
                if (!Heroes.Any()) 
                {
                    CheckBattleOutcome();
                    break;
                }

            }
        }
    }
}



/******************************************************* COMPLETED CHALLENGES *******************************************************/

// 1.
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


// 2.
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


// 3.
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

// 4.
/*

Title: Attacks 


Story: 

In this challenge, we will extend our game by giving characters attacks and allowing players to pick an attack instead of doing nothing.

We won't address tracking or dealing damage yet.


Objectives: 

- The game needs to be able to represent specific types of attacks. 
Attacks will have a name and other capabilities too. 

- Each character has a standard attack, but this varies from character to character.
The true Programmer's ( the players character ) attack's is called PUNCH. The Skeleton's attack is called BONE CRUNCH.

- The program must be capable of representing an attack action, our second action type. 
An attack action must represent which attacks is being used and the target of the attack. When this action runs, it should state the attacker, the attack, and the target. 
Example: "TOG used PUNCH on SKELETON"

- Our computer player should pick an attack action rather than do nothing action. 
The attack action can be simple for now: always use the character's standard attack and always target the other party's first character.  
If you want to choose a random target or some other logic, you can.

- The game should now run more like below:
------------------------------------------------------------------------------------------------------------------------------------------

"It's TOG's turn..."
"TOG used PUNCH on SKELETON"

"It's SKELETON's turn..."
"SKELETON used BONE CRUNCH on TOG"

------------------------------------------------------------------------------------------------------------------------------------------

- Hint: 
The player will need access to the list of characters that are potential targets. 
In my case, I passed my Battle object ( which represents the entire battle and gives access to both parties and all their members ) to the player
I then added methods to Battle where I could give it a character, and it would return the character's party ( GetPartyFor(Character) ) or the opposing party ( GetEnemyPartFor(Character) ).


*/

// 5.
/*

Title:  Damage and HP


Story: 

Now that our characters are attacking each other it is time for the attacks to matter. 

In this challenge we will enhance the game to give characters hit points (HP).

Attacking should reduce the HP of the target down to 0 but not past it.

Reaching 0 HP means death, which we will deal with in the next challenge. 


Objectives: 

- Characters should be able to track both their initial/maximum HP and their current HP. The true Programmer should have 25 HP, while skeletons should have 5. 

- Attacks should be able to produce attack data for a specific use of the attack. 
For now, this is simply the amount of damage that they will deal this time, though keep in mind that other challenges will add more data to this, including things like the frequency of hitting or missing and damage types.  

- The PUNCH attack should deal 1 point of damage while the BONE CRUNCH should randomly deal 0 or 1 damage point. 
HINT: Remember that Random can be used to generate random numbers. random.Next(2) will generate a 0 or 1 equal probability.  

- The attack action should ask the attack to determine how much damage it cause this time and then reduce the target's HP by that amount. 
A character's HP should not be lowered below 0;

- The attack should report how much damage the attack did and what the target HP is at after the attack. 
Example: "PUNCH did 1 damage to SKELETON." "SKELETON is now at 4/5 HP"

- When the game runs after the updates of this challenge the output will look similar to below: 
------------------------------------------------------------------------------------------------------------------------------------------

It's TOG's turn...
TOG used PUNCH on SKELETON.
PUNCH dealt 1 damage to SKELETON.
SKELETON is now at 4/5 HP.

It's SKELETON's turn...
SKELETON used BONE CRUNCH on TOG.
BONE CRUNCH dealt 0 damage to TOG.
TOG is now at 25/25 HP.

------------------------------------------------------------------------------------------------------------------------------------------

*/

// 6.
/*

Title: Death


Story: 

When a character's HP reaches 0, it has been defeated and should be removed from it's party. 

If a party has no characters left the battle is over.


Objectives: 

-  After an attack deals damage, if the target's HP has reached 0, remove them from the game.

- When you remove a character from the game, display text to illustrate this.
Example: "SKELETON has been defeated!"

- Between rounds ( or between character turns,) the game should see if a party has no more living characters. 
If so the battle (and the game ) should end.

- After the battle is over, if the heroes won ( there are still surviving characters in the party ) then display a message sating that the heroes won, and the Uncoded One was defeated. 
If the monsters won, then display a message saying that the heroes lost and the Uncoded One's forces have prevailed. 

*/

// 7.

/*

Title: Battle Series


Story: 

The game runs as a series of battles, not just one. 

The heroes do not win until every battle has been won, while the monsters win if they can stop the heroes in any battle 


Objectives: 

- There is ony party of heroes but multiple parties of monsters.
For now build, two monster parties: the first should have one skeleton, and the second has two skeletons. 

- Start the battle with the heroes and the first party of monsters. 
When the heroes win, advance to the next party of monsters
If the heroes lose a battle, end the game. If the monsters lose a battle, move to the next battle unless it is the last. 


*/

// 8.
/*

Title: The Uncoded One


Story: 

It is time to put the final boss into the game.

The Uncoded one itself. 

We will add this monster in as a third battle. 


Objectives: 

- Define a new type of monster, The Uncoded One.
It should have 15 HP and an unravelling attack that randomly deals between 0-2 damage when used.
The Uncoded one out to have more HP than the True Programmer, but much more than 15 HP means the Uncoded one wins every time. 
We can adjust these numbers later.

- Add a third battle to the series that contains the Uncoded One. 

*/

// 9.
/*

Title: The Player Decides 


Story: 

We have one critical missing piece to add before the core game is done: letting a human play it. 


Objectives: 

- The game should allow a human player to play it by retrieving their action choices through the console window. 
For a human-controlled character, the human can use that character's standard attack or do nothing. 
It is acceptable for all attacks selected by the human to target the first ( or random ) target without allowing the player to pick one specifically. 
You can let the player pick if you want, but it is not required.

- The following is one possible approach: 
------------------------------------------------------------------------------------------------------------------------------------------

It's TOG's turn...
1 - Standard Attack (PUNCH)
2 - Do Nothing

What do you want to do?  2

------------------------------------------------------------------------------------------------------------------------------------------


- As the game is starting, allow the user to choose from three following gameplay modes:
1. player vs. computer ( human player will command the heroes and the computer the monsters party )
2. computer vs. computer ( a computer player running each team as we have done so far )
3. human vs human ( where a human picks actions for both sides )


- Hint:
There are many ways you could approach this. My solution was to build a MenuItem record that held information about options in the menu. 
It included properties string Description, bool IsEnabled, and IActionToPerform.IAction is my interface representing any of the action types, with implementation like DoNothingAction and AttackAction. 
I have a method that creates the list of menu items, and it produces a new MenuItem instance for each choice. 
The code draws the menu iterates through the MenuItem instance and displays them with a number. 
After getting the number, I find the right MenuItem, extract the IAction, and return it. 
That means I create many IAction objects that don't get used, but it is a system that is easy to extend in the future challenges. 

*/


// Expansion Challenges 

// 1.
/*

Title: The Game Status


Story: 

This challenge gives us a cleaner representation of the status of the game. 

Objectives: 

- Before a character gets their turn, display the overall status of the battle. 
This status must include all characters in both parties with their current and total HP. 

- You must also distinguish who's turn it is by color, a text marker, or some other identifier 

- Note: You have the flexibility in how you approach this challenge, but the following shows one possibility
( with the current character colored yell instead of white )


================================================================== BATTLE ==================================================================

TOG  (25/25)


--------------------------------------------------------------------- VS ------------------------------------------------------------------
                                                       
                                                                                                                             Skeleton (5/5)
                                                                                                                             Skeleton (5/5)


=============================================================================================================================================


*/

// 2.
/*

Title: Vin Fletcher 


Story: 

The true Programmer does not have to fight the Uncoded One alone.
The hero can have other heroes (companions) that should get their turn to fight. 
In this challenge, we will add our favorite arrow maker, Vin Fletcher to the game. 
This challenge will also add in the possibility for an attack to sometimes miss. 


Objectives: 

- When an attack generates attack data, it must also include a probability of success. 
0 is guaranteed failure, 1 is guaranteed success, 0.5 is 50/50 etc.

- Modify your attack action to account for the possibility of missing. 
If an attack misses, don't damage the target and instead report that the attack missed. 
Example: "VIN FLETCHER MISSED"

- Create a new character type to represent VIN FLETCHER.
He starts with 15 HP.
If you did the Gear challenge, Vin should have the same standard attack PUNCH as the true Programmer has and equip him ith Vin's Bow gear with an attack called quick shot that deals 3 damage but only succeeds 50% of the time. 
If you did not do the Gear Challenge, give Vin quick shot as his standard attack. 

*/