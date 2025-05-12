using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle
{
    internal class Character
    {
        public string Name { get; set; }
        public Character(string name)
        {
            Name = name;
        }

        public void Action()
        {
            // this will be updated to display action options
            Nothing();
        }

        public void Nothing()
        {
            Console.WriteLine($"{Name} did nothing");
        }
    }
}
