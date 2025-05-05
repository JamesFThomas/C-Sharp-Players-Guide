using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharberryTrees
{
    internal class CharberryTree
    {
        private Random _random = new Random();
        public bool Ripe { get; set; }

        public event Action? TreeRipened;
        public void MaybeGrow()
        {
            if (_random.NextDouble() < 0.0000001 && !Ripe)
            {
                Ripe = true;
                TreeRipened?.Invoke();
                return;
            }

        }
    }
}
