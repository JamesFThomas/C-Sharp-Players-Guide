using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/*

Title: Indexing Operand City

Story: 

In exchange for the Medallion of Indexers, the city asks for the ability to index a BlockCoordinate by a number:
- block[0] for the blocks row and block[1] for the blocks column.

Help them in this quest by adding a get-only indexer to the BlockCoordinate class

Objectives:

- Add a get-only indexer to the BlockCoordinate to access items by an index: 
    --> index[0] is the row and index[1 is the column]

- Answer this question: Does an indexer provide many benefits over just referring to th Row and Column properties in this case? Explain your thoughts? 
    => 
 
*/

namespace NavigatingOperandCity
{
    public record BlockCoordinate(int Row, int Column)
    {

        public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b) => new BlockCoordinate(a.Row + b.RowOffset, a.Column + b.ColumnOffset);

        public static BlockCoordinate operator +(BlockCoordinate a, Direction b)
        {
            BlockOffset offset;
            
            switch (b)
            { 
                case Direction.north:
                    offset = new BlockOffset(-1, 0);
                    break;
                case Direction.south:
                    offset = new BlockOffset(1, 0);
                    break;
                case Direction.east:
                    offset = new BlockOffset(0, 1);
                    break;
                case Direction.west:
                    offset = new BlockOffset(0, -1);
                    break;
                default: 
                    throw new ArgumentOutOfRangeException(nameof(b), $"Direction '{b}' is not valid.");

            }

            return new BlockCoordinate(a.Row + offset.RowOffset, a.Column + offset.ColumnOffset);
        }

    }
}
