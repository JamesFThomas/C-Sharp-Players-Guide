using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Classes;

namespace TheFinalBattle.Interfaces
{
    interface IBehavior
    {
        string Name { get; set; }

        void Execute(Character character, Character? target, int? damage);
    }
}
