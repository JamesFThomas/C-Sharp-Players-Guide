/*
 
Title: The Point 

Story: 
Create a Point class to store a point in two demensions. 
Each point is represented by an X-coordinate (x), 
a sisde to side distance from a speacial central poitn called the origin,
and a y-coordinate (y), and up-and-down distance away fromt he origin.   

Objectives: 
- Define a new Point class with properties for X and Y.

- Add a constructor to create a point from specific x && y coordinate. 

- Add a parameterless constructor to create a point at the origin (0,0).

- In your main method, create a point at (2,3) and another at (-4,0). 
    --> Display these points on the console window in the format (x, y) to illustrate that the class works

- Answer this question: Are you X and Y porperties immutable? Why did you choose what you did? 
    --> Answer: I decided to remove the setter methods and make the point immutable becuase the Point shouldn't change but rather move from one point to another
                so there is no need to update the point just make a new to travel to.  
*/

Point one = new Point(2, 3);
Point two = new Point(-4, 0);

one.DisplayPoint();
two.DisplayPoint();






public class Point
{
    private int _x;
    private int _y;

    public Point(int x, int y )
    { 
        _x = x;
        _y = y;
        
    }

    public Point() 
    { 
        _x = 0;
        _y = 0;
    }

    public int X { get; }
    public int Y { get; }



    public void DisplayPoint()
    {
        Console.WriteLine($"({_x}, {_y})");
    }

}