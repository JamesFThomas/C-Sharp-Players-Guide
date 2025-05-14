using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle.Interfaces
{
    interface IAttack : IBehavior
    {
        int Damage { get; set; }

        void Execute(ICharacter attacker, ICharacter target);
    }
}
