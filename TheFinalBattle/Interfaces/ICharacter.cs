using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Classes;

namespace TheFinalBattle.Interfaces
{
    interface ICharacter
    {
        string Name { get; set; }

        int MaxHP { get; set; }

        int CurrentHP { get; set; }

        int Health => CurrentHP / MaxHP;

        public void AddBehavior(string behaviorName, IBehavior action );
        public void PerformBehavior(string actionName, Character? target);

    }
}
