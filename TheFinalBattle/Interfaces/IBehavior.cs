using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle.Interfaces
{
    interface IBehavior
    {
        string Name { get; set; }

        void Execute(ICharacter character);
    }
}
