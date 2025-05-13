using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;

namespace TheFinalBattle.Classes
{
    internal class Computer : IPlayer
    {
        public string Type { get; set; }

        public Computer(string type )
        {
            Type = type;
        }

        public void PickAction(ICharacter character)
        {
            character.PerformAction("donothing");
        }
    }
}
