/*
 
Title: List Of Commands 


Story:

In level 27 we encountered a robot with an array to hold commands to run. 
But we could make the robot have as many commands as we want by turning the array into a list.
Revisit that challenge to make the robot a list instead of an array, and add commands to run until the user says stop.


Objectives:

- Change Robot class to use a List<IRobotCommand> instead of an array for its Command property.  

- Instead of looping three times, go until the user types stop. Then run all the command created.
 

*/




RobotProgram robotProgram = new RobotProgram();

robotProgram.RunProgram();


public class RobotProgram
{
    bool isCollectingCommands = true;
    public void RunProgram()
    {
        // Create a new Robot instance
        Robot robot = new Robot();

        // Collect commands until the user types "stop"
        CollectCommands(robot);

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

    // Update the CollectCommands method to handle the nullable return value of CreateCommand
    public void CollectCommands(Robot robot)
    {
        string? input;
        string prompt = "Enter your robot command (on/off/north/south/east/west) or type 'stop' to finish:";
        
        while (isCollectingCommands)
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();

            if (input != null && input.ToLower() == "stop")
            { 
                isCollectingCommands = false;
                break;                
            }

            if (input == null || !IsGoodInput(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid command.");
                CollectCommands(robot);
                return;

            }
            
            
            else
            {
                IRobotCommand? command = CreateCommand(input);

                if (command != null) 
                {
                    robot.Commands.Add(command);
                }
            }

        }

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
public interface IRobotCommand
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
    public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

}