using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Classes;

namespace TheFinalBattle.Models
{
    internal class BoneCrunch : StandardAttack
    {
        private const string AttackName = "BONE CRUNCH";

        public BoneCrunch() : base(AttackName, 0)
        {
        }

        public override void Execute(Character attacker, Character? target, int? damage)
        {
            int randomDamage = random.Next(2);

            base.Execute(attacker, target, randomDamage);
          
        }
    }
}
