using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;

namespace TheFinalBattle.Classes
{
    class DoNothing : IAction
    {
        public void Execute(Character character)
        {
            var name = character.Name;
            Console.WriteLine($"{name} did NOTHING");
        }
    }
}
