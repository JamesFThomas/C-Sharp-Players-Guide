﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLongGame
{
    internal class User
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public User(string name, int score)
        {
            Name = name;
            Score = score;
        }

    }
}
