/*
 
Title: The Old Robot


Story: 

You spot something shinny half buried in the mud. You pull it out and realize that it seems to be some mechanical automation with words "Property Of Dynamak" etched into it.
As you knock off the caked-on mud, you realize that it seems like this old automation might even be programmable, If you can give it teh proper commands.
The automation to be structured like this: 

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run()
    {
        foreach( RobotCommand? command in Commands )
        {
            command?.Run( this );
            Console.WriteLine( $"[{X} {Y} {IsPowered}]" );
        }
    }

}

You don't see a definition of that RobotCommand class. Still you think you might be able to recreate it ( a class with only an Abstract Run command) 
and then make derived classes that extend RobotCommand, that move it in each direction of the four directions and power it on and off.
You wish you could manufacture a whole army of these.


Objectives: 

- Copy the above code into a new project.

- Create a RobotCommand class with a public and abstract void Run(Robot robot) method.
    --> The code above should compile after this step

- Make OnCommand and OffCommand classes that inherit from RobotCommand and turn the robot on or off by overriding the Run method.

- Make a NorthCommand, SouthCommand, EastCommand and WestCommand that move the robot 1 unit in the -Y direction, 1 unit in the -X direction, 1 unit in the +Y direction, and 1 unit in the +X direction respectively.
    --> Also ensure that these commands only work if the robot's IsPowered property is true.

- Make your main method able to collect three commands from the console window. 
    --> Generate new RobotCommand objects based on the text entered. After filling the robot's command set with these new RobotCommand objects, use the robot's Run method to execute them. 
    --> Example: 
        > on
        > north
        > west

       
       [ 0  0  True ]
       [ 0  1  True ]
       [-1  1  True ]
       
- Note: You might find this strategy for making commands that update other objects useful in sense of the larger challenges in the coming levels. 
 
*/

RobotProgram robotProgram = new RobotProgram();

robotProgram.RunProgram();


public class RobotProgram
{
    public void RunProgram()
    {
        // Create a new Robot instance
        Robot robot = new Robot();
        
        // Collect 3 user inputs
        (string? input1, string? input2, string? input3) = CollectInputs();

        // Create command objects based on the inputs
        if ( input1 != null && input2 != null && input3 != null)
        { 
            robot.Commands[0] = CreateCommand(input1);
            robot.Commands[1] = CreateCommand(input2);
            robot.Commands[2] = CreateCommand(input3);
        }
        
        // Run the commands
        robot.Run();

    }

    private RobotCommand? CreateCommand(string input)
    {
        RobotCommand? command = null; 

        switch (input)
        {
            case "on":
                command = new OnCommand();
                break;
            case "off":
                command = new OffCommand();
                break;
            case "north":
                command = new NorthCommand();
                break;
            case "south":
                command = new SouthCommand();
                break;
            case "east":
                command = new EastCommand();
                break;
            case "west":
                command = new WestCommand();
                break;
        }

        return command;
    }


    public (string?, string?, string?) CollectInputs()
    {
        string? input1, input2, input3;
        string prompt1 = "Enter your first robot command (on/off/north/south/east/west):";
        string prompt2 = "Enter your second robot command (on/off/north/south/east/west):";
        string prompt3 = "Enter your third robot command (on/off/north/south/east/west):";
        string invalidInput = "Invalid input. Please enter a valid command.";

        Console.WriteLine(prompt1);
        input1 = Console.ReadLine();

        if (input1 == null || !IsGoodInput(input1))
        {
            Console.WriteLine(invalidInput);
            return CollectInputs(); 
        }

        Console.WriteLine(prompt2);
        input2 = Console.ReadLine();

        if (input2 == null || !IsGoodInput(input2))
        {
            Console.WriteLine(invalidInput);
            return CollectInputs(); 
        }

        Console.WriteLine(prompt3);
        input3 = Console.ReadLine();

        if (input3 == null || !IsGoodInput(input3))
        {
            Console.WriteLine(invalidInput);
            return CollectInputs(); 
        }

        return (input1.ToLower(), input2.ToLower(), input3.ToLower());
    }

    public bool IsGoodInput(string input)
    { 
        bool goodInput = false;

        if (input.ToLower() == "on" || input.ToLower() == "off" || input.ToLower() == "north" || input.ToLower() == "south" || input.ToLower() == "east" || input.ToLower() == "west")
        {
            goodInput = true;
        }

        return goodInput;

    }

}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);

}


public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    override public void Run(Robot robot)
    {
        if (robot.IsPowered) 
        {
            robot.Y++; 
        }
    }
}
    

public class SouthCommand: RobotCommand
{
    override public void Run(Robot robot)
    {
        if (robot.IsPowered) 
        {
            robot.Y--; 
        }
    }

}

public class EastCommand : RobotCommand
{
    override public void Run(Robot robot)
    {
        if (robot.IsPowered) 
        {
            robot.X++; 
        }
    }
}

public class WestCommand : RobotCommand
{
    override public void Run(Robot robot)
    {
        if (robot.IsPowered) 
        {
            robot.X--; 
        }
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

}