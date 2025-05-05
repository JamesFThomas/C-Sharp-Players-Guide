using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLambdaSieve
{
    internal class Sieve
    {
        public Func<int, bool> filterOperation;

        public Sieve(Func<int, bool> operation)
        {
            filterOperation = operation;
        }

        public bool iGood(int number)
        {
            return filterOperation(number);
        }
    }
}
