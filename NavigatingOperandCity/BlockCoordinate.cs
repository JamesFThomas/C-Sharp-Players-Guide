using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
