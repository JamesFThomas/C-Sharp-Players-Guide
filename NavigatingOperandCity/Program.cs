/*

Title: Navigating Operand City

Story: 

The city of operand is a carefully organized city organized into city blocks, lined up north to south and east to west.
Blocks are referred to by their coordinates in the city, as we saw in the Cavern of Objects.
The inhabitants of the town use the following three types as they work with city blocks:

- public record BlockCoordinate(int Row, int Column);
- public record BlockOffset(int RowOffset, int ColumnOffset);
- public enumeration Direction { North, South, East, West }

BlockCoordinate refers to to a specific blocks location, BlockOffset is for relative distances between blocks, and Direction specifies directions. 
As we saw with the Cavern of Objects, rows start at 0 the North end of the city and get bigger as you go south, while columns start at 0 on the west end and get bigger as you go east.   
The city has used these types for a long time, but the problem is that they don't play nice with each other.
The town is the steward of three Medallions of code.
They will give you each of them if you can use them to make life more manageable. 
Use the code above as a starting point for what you would build. 

In exchange for the medallion of Operators, they ask you to make it easy to add BlockCoordinate with a Direction and also with a BlockOffset to get a new BlockCoordinates.
Add operators to BlockCoordinates to achieve this. 

Objectives:

- Use the code above as a starting point. 

- Add an addition (+) to BlockCoordinates that takes a BlockCoordinate and a BlockOffset as arguments and produces a new BlockCoordinate that refers to the one you would arrive at by starting at the original coordinate and moving by the offset.
That is if we started at (4,3) and had an offset of (2,0) we should end up at (6,3).

- Add another addition (+) to BlockCoordinate that take a BlockCoordinate and a Direction as arguments and produces a new BlockCoordinate that is a block in the direction indicated if we started at (4,3) and went east, we should end up at (4,4).  

- Write code to ensure that both operators are working correctly. 


 
*/ 