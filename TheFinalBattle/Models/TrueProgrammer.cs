using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;
using TheFinalBattle.Models;

namespace TheFinalBattle.Classes
{
    internal class TrueProgrammer : Character
    {
        public TrueProgrammer(string name) : base(name)
        {
            AddBehavior("punch", new Punch());
        }

        // override or add method specific to class here when ready 
    }
}
