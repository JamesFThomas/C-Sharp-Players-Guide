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

        public StandardAttack(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        public virtual void Execute(Character attacker, Character? target)
        {
            Console.WriteLine($"\n{attacker.Name} used {Name} on {target?.Name}");
            
            Console.WriteLine($"{Name} dealt {Damage} damage to {target?.Name}");

            if (target != null)
            {
                target.CurrentHP -= Damage;
                
                if (target.CurrentHP <= 0) // don't reduce HP below 0
                { 
                    target.CurrentHP = 0;
                }
            }

            Console.WriteLine($"{target?.Name} health is now {target?.Health}");

        }
    }
}
