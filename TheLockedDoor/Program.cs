
/*

Title: The Locked Door
 
Story: 

The fourth challeneg of the catacomb tasks you with making a door class witha locking mechansim that requires a unique numeric code to unlock. 
You have done something similar before withut using a class, but the locking mechanism is new. The door should only unnlock if the passcode is the right one. 
The following statements describe how the door works. 

- An open door can always be closed.

- A closed (but NOT locked) door can always be opened. 

- A closed door can always be locked.

- A locked door can be unlocked, but a numeric passcode is needed, and the door will only open if the code supplied matches the door's current passcode.

- When a door is created, it must be given aninital passcode.

- Additionally, you should be able to change the passcode by supply he current pascode and a new one. The passcode should only change if thhe current correct code is supplied. 


Objectives:

- Define a Door class that can keep track of wether it is locked, unlocked, open, or closed. 

- Make it so you can perform the four transitions defined above with methods.

- Build a constrcutor that requires the starting numeric passcode.

- Build a method that will allow you change the existing passcode for a Door by suppliying the current passcode and a new passcode. 
  Only change the passcode if the current passcode is correct. 

- Make the main method ask the starting user for a passcode, then create a new Door instance. 
  Allow the user to attempt the four transitions described above (open, close, unlock, lock) and change the code by typing in text commands. 


*/


// Main method - collect users input 
int userInput;

Console.Write("Provide the passcode for your new door:  ");
userInput = Convert.ToInt32(Console.ReadLine());

Door door = new Door(userInput);

//door.DoorDetails(); // door is good at this point check other methods

//door.CloseDoor();

//door.LockDoor();

//Console.Write("Provide the passcode to unlock your door: ");
//userInput = Convert.ToInt32(Console.ReadLine());

//door.UnLockDoor(userInput);

//door.OpenDoor();




public enum DoorAction
{ 
    openDoor = 1,
    closeDoor,
    unlockDoor,
    lockDoor
}

public enum DoorState
{ 
    open = 1,
    closed,
    unlocked,
    locked
}



public class Door
{ 
    // fields
    private DoorState _doorState = DoorState.open;
    private int _passcode;

    // constrcutor
    public Door( int code)
    { 
        _passcode = code;
    }


    // methods 
    public void OpenDoor()
    {
        if (_doorState != DoorState.unlocked)
            Console.WriteLine($"The door is: {_doorState}. You must close, and unlock it in order to open it.");

        if (_doorState == DoorState.unlocked)
        {
            _doorState = DoorState.open;
            Console.WriteLine("The door is now open");
        }


    }

    public void CloseDoor()
    {

        if (_doorState != DoorState.open)
            Console.WriteLine($"The door is: {_doorState}. You must unlock, and open it in order to close it.");
        
        if (_doorState == DoorState.open)
        {
            _doorState = DoorState.closed;
            Console.WriteLine("The door is now closed");
        }

    }

    public void LockDoor()
    {
        if (_doorState != DoorState.closed)
        {
            Console.WriteLine("The door must first be closed to be locked");
        }

        if (_doorState == DoorState.closed)
        { 
            _doorState = DoorState.locked;
            Console.WriteLine("The door is now locked");
        }

    }

    public void UnLockDoor(int code)
    {
        if (!IsValidPasscode(code))
            Console.WriteLine("Invalid passcode, door is remains locked");

        if (IsValidPasscode(code))
        {
            if (_doorState != DoorState.locked)
            {
                Console.WriteLine("The door must first be locked to be unlocked");
            }

            if (_doorState == DoorState.locked)
            { 
                _doorState = DoorState.unlocked;
                Console.WriteLine("The door is now unlocked");
            }
        }

    
    }

    public bool IsValidPasscode( int code)
    {
        // match input passcode to set passcode
        return _passcode == code;
    }

    public void UpdatePasscode( int oldcode, int newcode)
    { 
        // check if old code is valid
        bool valid = IsValidPasscode(oldcode);

        // update old passcode
        if (!valid) Console.WriteLine("The provided passcode was incorrect, I can't update your passcode");


        // reassign the passcode to the new code
        _passcode = newcode;

        // indicate the code has been changed 
        Console.WriteLine("Your passcode was succesfully updated!");
    
    }

    public void DoorDetails()
    { 
        Console.WriteLine($" This door is currently: {_doorState.ToString()} and it's code is: {_passcode}");
    
    }

}