using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;

namespace TheFinalBattle.Classes
{
    class DoNothing : IBehavior
    {
        public string Name { get; set; } = "DO NOTHING";

        public DoNothing() { }

        public void Execute(ICharacter character)
        {


            Console.WriteLine($"{character.Name} will {Name}");

        }
    }
}
