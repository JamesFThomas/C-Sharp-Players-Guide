/*

Title: Room Coordinates


Story: 

The time to enter the Fountain of Objects draws closer. While you don't know what to expect, you have found some scrolls that describe the area in ancient times.
It seems to be structures as a set of rooms in a grid-like arrangement. 

Locations of the room may be represented as a row and column, and you take it upon yourself to try to capture this concept with a new struct definition.  


Objectives: 

- Create a Coordinate struct that can represent a room coordinate with a row and column. 

- Ensure Coordinate is immutable. 

- Make method to determine if one coordinate is adjacent to another ( differing by a single row or column )

- Write a main method that creates a few coordinates and determines if they are adjacent to each other to prove that it is working correctly. 
 
*/

Coordinate coordinate1 = new Coordinate(1, 2);
Coordinate coordinate2 = new Coordinate(1, 3);
Coordinate coordinate3 = new Coordinate(2, 2);
Coordinate coordinate4 = new Coordinate(2, 3);

Console.WriteLine($"Coordinate 1 is adjacent to coordinate 2 {coordinate1.IsAdjacent(coordinate2)}."); // true
Console.WriteLine($"Coordinate 1 is adjacent to coordinate 3 {coordinate1.IsAdjacent(coordinate3)}."); // false
Console.WriteLine($"Coordinate 1 is adjacent to coordinate 4 {coordinate1.IsAdjacent(coordinate4)}."); // false
Console.WriteLine($"Coordinate 2 is adjacent to coordinate 3 {coordinate2.IsAdjacent(coordinate3)}."); // false 
Console.WriteLine($"Coordinate 2 is adjacent to coordinate 4 {coordinate2.IsAdjacent(coordinate4)}."); // true





public struct Coordinate
{ 
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacent(Coordinate coordinate)
    {
        // check to see if the coordinates are in the same row or column
        // check to see if the difference between the coordinates is 1
        return (Row == coordinate.Row && Math.Abs(Column - coordinate.Column) == 1) ||
               (Column == coordinate.Column && Math.Abs(Row - coordinate.Row) == 1);

    }

}