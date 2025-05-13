using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle.Interfaces
{
    interface ICharacter
    {
        string Name { get; }

        public void AddAction(string actionName, IAction action);
        public void PerformAction(string actionName);

    }
}
