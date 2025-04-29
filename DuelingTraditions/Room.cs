using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelingTraditions
{
    public interface IRoom
    {
        int Row { get; set; }
        int Column { get; set; }
        string Location { get; }
        string Type { get; set; }
        void Sense(bool isFountainOn = false);
    }

    public interface IActivatableRoom : IRoom
    {
        void Enable();
        void Disable();
    }

    public class Empty : IRoom
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Location => $"(Row = {Row}, Column = {Column})";
        public string Type { get; set; }

        public Empty(int row, int column, string type)
        {
            Row = row;
            Column = column;
            Type = type;
        }
        public void Sense(bool isFountainOn = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You sense nothing but the unnatural darkness, this room is empty!");
            Console.ResetColor();
            return;
        }
    }



    public class Entrance : IRoom
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Location => $"(Row = {Row}, Column = {Column})";
        public string Type { get; set; }
        public Entrance(int row, int column, string type)
        {
            Row = row;
            Column = column;
            Type = type;
        }

        public void Sense(bool isFountainOn)
        {
            if (isFountainOn)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; // entrance text in yellow
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You see light coming from the cavern entrance.");
            Console.ResetColor();
            return;
        }

    }

    public class Fountain : IActivatableRoom
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Location => $"(Row = {Row}, Column = {Column})";
        public string Type { get; set; }
        public Fountain(int row, int column, string type)
        {
            Row = row;
            Column = column;
            Type = type;
        }

        public void Sense(bool isFountainOn)
        {
            if (isFountainOn)
            {
                Console.ForegroundColor = ConsoleColor.Blue; // fountain text in blue
                Console.WriteLine("You here rushing waters from the Fountain of Objects, it has been reactivated!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You hear water dripping in this room. The fountain of Objects is here!");
            Console.ResetColor();
            return;
        }

        public void Enable()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Fountain of Objects has been reactivated!");
            Console.ResetColor();
            return;
        }

        public void Disable()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Fountain of Objects has been DeActivated!");
            Console.ResetColor();
            return;
        }
    }
}
