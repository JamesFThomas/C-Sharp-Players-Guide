/*
 
    Title: Watchtower 

    Cordinate Diagram:       

                    x < 0      x = 0      x > 0
                   +-------+-------+-------+
            y > 0  |  NW   |   N   |  NE   |
                   +-------+-------+-------+
            y = 0  |   W   |   !   |   E   |
                   +-------+-------+-------+
            y < 0  |  SW   |   S   |  SE   |
                   +-------+-------+-------+

    Objectives:

    - Ask the user for an x value and a y value. These are the cordinates of the enemy reltive to the watch tower's location

    - Using the image on the right, if statements, and relational operators, display a message about what direction the enemy is coming from.   
        -- ex: "The enemy is to the northwest!" || "The enemy is here"
 
 */


// create conditions for return messages 

int x, y;

Console.Title = "Watchtower";

Console.Write("Enter the x coordinate of the enemy location: ");
x = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the y coordinate of the enemy location: ");
y = Convert.ToInt32(Console.ReadLine());


if ( x < 0 && y > 0)
{
    Console.WriteLine("The enemy is to the Northwest!");

}

if (x == 0 && y > 0)
{
    Console.WriteLine("The enemy is to the North!");
}

if (x > 0 && y > 0)
{
    Console.WriteLine("The enemy is to the Northeast!");
}

if (x < 0 && y == 0)
{
    Console.WriteLine("The enemy is to the West!");
}

if (x == 0 && y == 0)
{
    Console.WriteLine("The enemy is Here!");
}

if (x > 0 && y == 0 )
{
    Console.WriteLine("The enemy is to the East!");
}

if (x < 0 && y < 0)
{
    Console.WriteLine("The enemy is to the Southwest!");
}

if (x == 0 && y < 0)
{
    Console.WriteLine("The enemy is to the South!");
}

if (x > 0 && y < 0)
{

    Console.WriteLine("The enemy is to the Southeast!");
}

