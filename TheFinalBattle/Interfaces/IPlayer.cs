using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Classes;

namespace TheFinalBattle.Interfaces
{
    interface IPlayer
    {
        string Type { get; set; }

        void PickBehavior(Character character, Character? target);
    }
}
