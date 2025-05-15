using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFinalBattle.Classes;

namespace TheFinalBattle.Models
{
    class UncodedOne : Character
    {
        public UncodedOne(string name) : base("The Uncoded One", 15)
        {
            AddBehavior("unravel", new Unravel());
        }
    }
}
