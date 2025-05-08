/*
 
Title: Uniter Of Adds

Story: 

This city has used the four great adds for a million clock cycles. 
"But legend for tells the true programmer who can unite them," the Regent of the of the City of Dynamak tells you. 
She shows you the four great adds: 

public static class Adds
{
    public static int Add(int a, int b) => a + b;
    public static int Add(double a, double b) => a + b;
    public static int Add(string a, string b) => a + b;
    public static int Add(Datetime a, Timespan b) => a + b;
}

"The code is identical, but the four types involved demand four different methods. So we survived with the Four Great Adds. Uniting them would be possible for a True Programmer."
With dynamic typing, you know this is possible. 

Objectives:

- Make a single Add method that can replace all four of the above methods using dynamic. 

- Add code to your main method to call the new method with two ints, two doubles, two strings, and a DateTime and TimeSpan, and display the results

- Answer this question:What down side do you see to using dynamic type here? 
    =>

 */


namespace UniterOfAdds
{
    internal class Program
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Uniter of Adds Working");

            int iA = 2;
            int iB = 4;

            double dA = 5;
            double dB = 6;

            string sA = "hello ";
            string sB = "world";

            DateTime date = DateTime.Now;
            TimeSpan timespan = new TimeSpan(36, 0, 0, 0);

            Console.WriteLine($"integers added {dynamicallyAddTypes(iA, iB)}");

            Console.WriteLine($"doubles added {dynamicallyAddTypes(dA, dB)}");

            Console.WriteLine($"strings added {dynamicallyAddTypes(sA, sB)}");

            Console.WriteLine($"time added {dynamicallyAddTypes(date, timespan)}");


        }

        public static dynamic dynamicallyAddTypes(dynamic a, dynamic b)
        { 
            var result = a + b;
            return result;
        }
    
    
    }

}