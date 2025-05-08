using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniterOfAdds
{

    public static class Adds
    {
        public static int Add(int a, int b) => a + b;
        public static double Add(double a, double b) => a + b;
        public static string Add(string a, string b) => a + b;
        public static DateTime Add(DateTime a, TimeSpan b) => a + b;
    }
}
