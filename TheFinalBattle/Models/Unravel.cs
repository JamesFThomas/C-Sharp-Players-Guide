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
        //private static readonly Random Random = new Random();

        private const string AttackName = "UNRAVEL";

        public Unravel() : base(AttackName, 0) { }

        public override void Execute(Character attacker, Character? target, int? damage)
        {
            //int damage = Random.Next(3);

            //Console.WriteLine($"\n{attacker.Name} used {Name} on {target?.Name}");

            //Console.WriteLine($"{Name} dealt {damage} damage to {target?.Name}");

            //if (target != null)
            //{
            //    target.CurrentHP -= damage;

            //    if (target.CurrentHP <= 0)
            //    {
            //        target.CurrentHP = 0;
            //    }
            //}

            //Console.WriteLine($"{target?.Name} health is now {target?.Health}");

            int randomDamage = random.Next(3);

            base.Execute(attacker, target, randomDamage);
        }

    }
}
