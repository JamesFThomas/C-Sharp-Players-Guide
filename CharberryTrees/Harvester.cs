using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharberryTrees
{
    internal class Harvester
    {
        static CharberryTree? _tree;
        public Harvester() { }
        public Harvester(CharberryTree tree)
        {
            _tree = tree;
            tree.TreeRipened += OnTreeRipening;
        }

        private void OnTreeRipening() => HarvestFruit();

        private static void HarvestFruit()
        {
            if (_tree != null)
            { 
                _tree.Ripe = false;
            }
        }
 

    }
}
