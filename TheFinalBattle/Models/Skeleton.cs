using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Interfaces;
using TheFinalBattle.Models;

namespace TheFinalBattle.Classes
{
     class Skeleton : Character
    {
        public Skeleton(string name) : base(name, 1)
        {
            AddBehavior("bonecrunch", new BoneCrunch());
        }


        // override or add method specific to class here when ready 

    }
}
