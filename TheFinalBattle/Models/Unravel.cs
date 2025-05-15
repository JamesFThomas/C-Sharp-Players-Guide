using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Classes;

namespace TheFinalBattle.Models
{
    internal class Unravel : StandardAttack
    {
        private static readonly Random Random = new Random();
        private const string AttackName = "UNRAVEL";
        public Unravel() : base(AttackName, Random.Next(3)) {}

        public override void Execute(Character attacker, Character? target)
        {
            int damage = Random.Next(3);

            Console.WriteLine($"{attacker.Name} used {Name} on {target?.Name}");

            Console.WriteLine($"{Name} dealt {Damage} damage to {target?.Name}");

            if (target != null)
            {
                target.CurrentHP -= damage;

                if (target.CurrentHP <= 0)
                {
                    target.CurrentHP = 0;
                }
            }

            Console.WriteLine($"{target?.Name} health is now {target?.Health}");
        }
    }
}
