using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Classes;

namespace TheFinalBattle.Models
{
    class BoneCrunch : StandardAttack
    {
        private static readonly Random Random = new Random(); 

        private const string AttackName = "BONE CRUNCH";

        public BoneCrunch() : base(AttackName, Random.Next(2)) { }

    }
}
