using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;

namespace TheFinalBattle.Classes
{
    internal class Character : ICharacter
    {
        public string Name { get; set; }
        public Dictionary<string, IBehavior> Behaviors { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public string Health => $"{CurrentHP}/{MaxHP}";

        public Character(string name, int max)
        {
            Name = name;
            MaxHP = max;
            CurrentHP = max;
            Behaviors = new Dictionary<string, IBehavior>();
            AddBehavior("donothing", new DoNothing());
        }

        public void AddBehavior(string behaviorName, IBehavior behavior)
        {
            Behaviors[behaviorName] = behavior;
        }

        public void PerformBehavior(string behaviorName, Character? target)
        {
            if (Behaviors.TryGetValue(behaviorName, out IBehavior? behavior))
            {
                behavior.Execute(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} has no actions named: {behaviorName}. Try another");
            }
        }

    }

}
