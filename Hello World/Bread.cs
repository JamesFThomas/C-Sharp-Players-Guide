using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Bread
    {
        public static void Main(string[] args)
        {

        }
        public static void whoReceivedBread()
        {
            Console.WriteLine("Bread is ready.");
            Console.WriteLine("Who is the bread for?");
            string RB = Console.ReadLine();
            Console.WriteLine("Noted:" + RB + " got bread");
        }
    }
}
