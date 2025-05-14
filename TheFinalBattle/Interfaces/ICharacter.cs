using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle.Interfaces
{
    interface ICharacter
    {
        string Name { get; }

        public void AddBehavior(string behaviorName, IBehavior action );
        public void PerformBehavior(string actionName);

    }
}
