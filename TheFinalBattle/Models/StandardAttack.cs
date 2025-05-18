using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;

namespace TheFinalBattle.Classes
{
    internal class StandardAttack : IAttack
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        protected static readonly Random random = new Random();

        public StandardAttack(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        public virtual void Execute(Character attacker, Character? target, int? damage)
        {
            if (target != null)
            {
                // calculate probability of success before adding damage
                var success = SuccessProbability();

                int actualDamage = damage ?? Damage;

                if (success == 1)
                {
                    // landed attack
                    Console.WriteLine($"\n{attacker.Name} used {Name} on {target.Name}");

                    Console.WriteLine($"{Name} dealt {Damage} damage to {target.Name} with a {success} success rate!");

                    target.CurrentHP -= actualDamage; 

                    if (target.CurrentHP <= 0) 
                    {
                        target.CurrentHP = 0;
                    }
                }
                else
                {
                    // missed attack
                    Console.WriteLine($"{attacker.Name} MISSED {target.Name} with {Name} attack!");
                    return;
                }

            }
            else
            {
                Console.WriteLine("No target to attack.");
                return;
            }

            Console.WriteLine($"{target.Name} health is now {target.Health}");
        }

        public int SuccessProbability()
        {
            double probability = random.NextDouble();
            return probability < 0.5 ? 1 : 0;
        }
    }
}
