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
        public Skeleton(string name) : base(name, 5)
        {
            AddBehavior("bonecrunch", new BoneCrunch());
        }


    }
}
