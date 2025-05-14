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
        public void Execute(ICharacter attacker, ICharacter target)
        {
            // Will add logic for damage here in a later challenge 
            Console.WriteLine($"{attacker.Name} used {Name} on {target.Name}");
        }

        public void Execute(ICharacter character)        
        {            
            Console.WriteLine($"{character.Name} standard attack is: {Name}.");        }
    }
}
