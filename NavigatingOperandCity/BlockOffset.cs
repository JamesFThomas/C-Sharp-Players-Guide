using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*

Title: Converting Directions to Offsets

Story: 

Operanders often use Directions and BlockOffsets in casual conversation: "go north", or "go two blocks west and one block south".
However it would be convenient to convert a direction to a BlockOffset. 
For example: the direction north would be an offset of(-1,0).
Operanders offer you their final Medallion, the Medallion of Conversions, if you can add a custom conversion in BlockOffset that converts a Direction to a BlockOffset.  

Objectives:

- Add a custom conversion to BlockOffset that turns a direction into a BlockOffset. 

- Answer this question: This challenge didn't call out whether to make the conversion implicit or explicit. Which did you choose and why? 
    => I choose to make the conversion explicit because I don't know if the conversion would happen automatically and it make more sense to me reading it out in the code. 


*/


namespace NavigatingOperandCity
{
    public record BlockOffset(int RowOffset, int ColumnOffset)
    {
        public static explicit operator BlockOffset(Direction direction)
        {
            return direction switch
            {
                Direction.north => new BlockOffset(-1, 0),
                Direction.south => new BlockOffset(1, 0),
                Direction.east => new BlockOffset(0, 1),
                Direction.west => new BlockOffset(0, -1),
                _ => throw new ArgumentException("Not a valid direction")
            };
        }
    }
}
