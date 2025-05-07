using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatingStream
{
    internal class RecentNumbers
    {
        List<int> numbers {  get; set; } = new List<int>();
        public RecentNumbers() { }
        public int CurrentNumber => numbers.Count() > 0 ? numbers[^1] : -1; // return last element if any values in List
        public int PreviousNumber => numbers.Count() > 1 ? numbers[^2] : -1; // return the second to last element if more than one value is in the list 

        public void AddNumber(int newNumber) => numbers.Add(newNumber);

    }
}
