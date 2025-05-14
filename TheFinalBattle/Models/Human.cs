using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;

namespace TheFinalBattle.Classes
{
    internal class Human : IPlayer
    {
        public string Type { get; set; }

        public Human(string type)
        {
            Type = type;
        }

        public void PickBehavior(Character character, Character? target)
        {
            // add logic for user to pick desired character action
        }
    }
}
