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
        private static readonly Random Random = new Random();
        private const string AttackName = "BONE CRUNCH";

        public BoneCrunch() : base(AttackName, Random.Next(2))
        {
        }

        public override void Execute(Character attacker, Character? target)
        {
            int damage = Random.Next(2);

            Console.WriteLine($"\n{attacker.Name} used {Name} on {target?.Name}");

            Console.WriteLine($"{Name} dealt {damage} damage to {target?.Name}");

            if (target != null)
            {
                target.CurrentHP -= damage;

                if (target.CurrentHP <= 0) // don't reduce HP below 0
                {
                    target.CurrentHP = 0;
                }
            }

            Console.WriteLine($"{target?.Name} health is now {target?.Health}");
        }
    }
}
