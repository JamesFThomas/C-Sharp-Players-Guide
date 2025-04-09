/*

Title: Simula's Test 

Story:

As you move throught the village of Enumerant, you notice a short, cloaked figure folowing you.
Not being one to enjoy a mysterious figure talling you, you decide to confront them.
"Don't scared, I am Simula" she says. They say you have the programming skills to help me.
You say yes and she is super duper excited.

“If you are a True Programmer, you will be able to help me. Follow me.” She leads you to a backstreet and into 
a dimly lit novel. She hands you a small, locked chest. “We haven’t seen any Programmers in these lands in a while. 
And especially not ones that can craft types. If you are a true programmer, I will gladly give it to you to aid you in your quest.”

The chest is a small box you can hold in your hand. The lid can be open, closed (but unlocked), or locked. 
You’d normally be able to go between these states, opening, closing, locking, and unlocking the box, but 
the box is broken. You need to create a program that uses an enumeration to recreate this locking mechanism. 
The image below shows how you can move between the three states:

-states: -> OPEN <-----------> CLOSED <-----------------> LOCKED
-actions:         close/open               lock/unlock

program example: 

The chest is locked. What do you want to do? unlock
The chest is unlocked. What do you want to do? open
The chest is open. What do you want to do? close
The chest is unlocked. What do you want to do? 


Objectives:
- Define an enumeration for the state of the chest.
- Make a variable whose type is this new enumeration.
- Write code to allow you to manipulate the chest with the lock, unlock, open, and close commands, 
  but ensure that you don’t transition between states that don’t support it.
- Loop forever, asking for the next command.

 
*/


BoxState chest = BoxState.Open;

string userInput = string.Empty;
bool isGameRunning = true;


while (isGameRunning)
{

    PromptUser();
    SetUserInput(userInput, isGameRunning);

}

//PlayWithChest();


// CREATE METHOD lock, unlock, open, close to change box state


void PromptUser()
{
    string userPrompt = "What do you want to do? ";
    
    Console.Write($"The box is currently {chest}. ");
    Console.Write(userPrompt);
}

void SetUserInput(string userInput, bool isGameRunning)
{
    userInput = Console.ReadLine().ToLower();
    UserAction(userInput);
}

void Open( )
{
    if ( chest == BoxState.Open)
    {
        Console.WriteLine("The box is already open.");
    }
    
    if (chest == BoxState.Locked)
    {
        Console.WriteLine("Box is locked, you must unlock it to open it.");
    }

    if (chest == BoxState.Closed)
    {
        chest = BoxState.Open;
        Console.WriteLine("The box is now open.");
    }
}

void Close()
{
    if (chest == BoxState.Closed)
    {
        Console.WriteLine("The box is already closed.");
    }

    if (chest == BoxState.Locked)
    {
        Console.WriteLine("Box is locked, you must unlock and open it to close it.");
    }
    if (chest == BoxState.Open) 
    { 
        chest = BoxState.Closed;
        Console.WriteLine("The box is now closed.");
    }
}

void Lock()
{
    if (chest == BoxState.Locked)
    {
        Console.WriteLine("The box is already locked.");
    }

    if (chest == BoxState.Open)
    {
        Console.WriteLine("Box is open, you must close it to lock it.");
    }

    if (chest == BoxState.Closed)
    {
        chest = BoxState.Locked;
        Console.WriteLine("The box is now locked.");
    }
}

void Unlock()
{
    if (chest == BoxState.Open)
    {
        Console.WriteLine("The box is open, you must close and lock it to unlock it.");
    }

    if (chest == BoxState.Closed)
    {
        Console.WriteLine("Box is closed, you must lock to then unlock it.");
    }

    if (chest == BoxState.Locked )
    {
        chest = BoxState.Closed;
        Console.WriteLine("The box is now unlocked.");
    }
}


void UserAction(string userInput)
{
     if (userInput == BoxActions.Exit.ToString().ToLower())
    {
        isGameRunning = false;
    }
    else if (userInput == BoxActions.Open.ToString().ToLower())
    {
        Open();
    }
    else if (userInput == BoxActions.Close.ToString().ToLower())
    {
        Close();
    }
    else if (userInput == BoxActions.Lock.ToString().ToLower())
    {
        Lock();
    }
    else if (userInput == BoxActions.Unlock.ToString().ToLower())
    {
        Unlock();
    }
    else
    {
        Console.WriteLine("Invalid action. Please try again: open, close, lock, unlock, exit.");
    }

}

// debug why PlayWithChest() is not working
void PlayWithChest()
{
    string userInput = string.Empty;
    bool isGameRunning = true;

    while (isGameRunning)
    {

        PromptUser();
        SetUserInput(userInput, isGameRunning);

    }
}




enum BoxState
{
    Open,
    Closed,
    Locked
}

enum BoxActions 
{ 
    Open,
    Close,
    Lock,
    Unlock,
    Exit
}