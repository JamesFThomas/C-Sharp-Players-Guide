/*

Title: Dueling Traditions 

Story:

The inhabitants of the Island of Programain, guardians of the medallion of Organization, seem to be hiding from you, peering at you through shuttered windows, leaving you alone on the dusty streets. 
The only people on the road stand in front of you, a gray haired old woman and two toughs who stand just behind her. 
"We heard a programmer might be headed this way, but you're no True Programmer. In the age before Programmers declared their main methods, used namespaces, and split their programs into multiple files. You probably don't even know what those things are!"
She spits on the ground and demands that you leave at once, but you know you can win her over by showing her you can use the tools she just named.
Do the following with one o the larger programs you have created in another challenge.



Objectives:

- Give your program a traditional Program and Main method instead of the top-level statements. 

- Place every type in a namespace.

- Place each type in it's own file. ( Small types like enumerations or records can be the exception. )
 
- Answer this question? Having used both top-level statements and a traditional entry point, which do you prefer? Why?
    --> Answer: 
        ---> Since I am using the newer C# 10, I prefer the top-level statements because my files are separated into Program and other directories each containing their own classes or namespaces.
        ---> witting out the Program class in the program file seems redundant and could be a bit confusing later when I look back. 
    


*/


using Game = DuelingTraditions.Game;

internal class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}



