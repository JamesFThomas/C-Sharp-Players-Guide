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
        // - The game needs to be able to represent different player types. A player needs the ability to pick an action for a character they control, given the battle's current state.
        string Type { get; set; }

        void PickAction(ICharacter character);
    }
}
