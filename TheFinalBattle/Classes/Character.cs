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
        public Dictionary<string, IAction> Actions { get; set; }
        public Character(string name)
        {
            Name = name;
            Actions = new Dictionary<string, IAction>();
            AddAction("donothing", new DoNothing());
        }

        public void AddAction(string actionName, IAction action)
        {
            Actions[actionName] = action;
        }

        public void PerformAction(string actionName)
        {
            if (Actions.TryGetValue(actionName, out IAction? action))
            {
                action.Execute(this);
            }
            else
            {
                Console.WriteLine($"{Name} has no actions named: {actionName}. Try another");
            }
        }
    }

}
