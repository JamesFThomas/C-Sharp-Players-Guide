using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;
using static System.Collections.Specialized.BitVector32;

namespace TheFinalBattle.Classes
{
    internal class Computer : IPlayer
    {
        public string Type { get; set; }

        public Computer(string type)
        {
            Type = type;
        }

        public void PickBehavior(Character character, Character? target)
        {
            foreach (var behaviorPair in character.Behaviors)
            {
                if (behaviorPair.Value is StandardAttack)
                {
                    character.PerformBehavior(behaviorPair.Key, target);
                    break; 
                }
            }
        }
    }
}
