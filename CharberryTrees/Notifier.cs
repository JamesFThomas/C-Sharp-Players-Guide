using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharberryTrees
{
    internal class Notifier
    {
        public Notifier() { }
        public Notifier(CharberryTree tree) 
        {
            tree.TreeRipened += OnTreeRipening;
        }

        private void OnTreeRipening() => RipeningNotification();

        private static void RipeningNotification()
        {
            Console.WriteLine("A charberry fruit has ripened");
        }

        
    }
}
