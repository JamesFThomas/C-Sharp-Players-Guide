/*


Title: The Robotic Interface 


Story: 

With your knowledge of interfaces, you realize you can refine the old robot you found in the mud to use interfaces instead of the original design. 

Instead of an Abstract RobotCommand base class, it could become an IRobotCommand interface!


Objective:

- Change your RobotCommand class into an IRobotCommand interface.

- Remove the unnecessary public and abstract keywords from the Run method. 

- Change the Robot class to use IRobotCommand instead of RobotCommand.

- Make all your commands implement this new interface instead of extending the RobotCommand class that no longer exists. 
    --> You will also want to remove the override keywords in these classes

- Ensure your program still compiles and runs 

- Answer this question: Do you feel this is an improvement over using an abstract base class? Why or why not?
    - Answer => I think the reduction in keywords make the code easier to read and understand. but I don't know if the performance has been improved using interfaces over abstract classes. 
 
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
        if (input1 != null && input2 != null && input3 != null)
        {
            robot.Commands[0] = CreateCommand(input1);
            robot.Commands[1] = CreateCommand(input2);
            robot.Commands[2] = CreateCommand(input3);
        }

        // Run the commands
        robot.Run();

    }

    private IRobotCommand? CreateCommand(string input)
    {
        IRobotCommand? command = null;

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

// replaced RobotCommand abstract class with IRobotCommand interface
public interface  IRobotCommand
{
    public void Run(Robot robot);

}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}


public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }

}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

public class WestCommand : IRobotCommand
{
     public void Run(Robot robot)
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
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

}