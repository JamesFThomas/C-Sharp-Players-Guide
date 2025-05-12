using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle
{
    internal class TrueProgrammer : ICharacter
    {
        public string Name { get; set; }

        public TrueProgrammer(string name)
        {
            Name = name;
        }

        public void Action()
        {
            Nothing();
        }

        private void Nothing()
        {
            Console.WriteLine($"{Name} did nothing"); ;
        }
    }
}
