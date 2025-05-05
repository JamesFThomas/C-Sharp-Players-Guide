/*

Title: The Lambda Sieve 

Story: 
The city of Lambdan, also on the island of Delgata, believes that the great Neuromechanical Sieve which you worked on in Level 36, could e made better by using lambda expression instead of regular,named methods.
If you can help them convince island leadership to make this change, they will give you the Lambda Medallion and pledge the Lambdani Fleet's assistance is this coming final battle. 

Objectives: 

- Modify your The Sieve program from Level 36 to use lambda expression for the constructor instead of named methods of the three filters 

- Answer this question: Does this change make the program shorter or longer?
    =>

- Answer this question: Does this change make the program harder or easier to read?
    =>



*/

namespace TheLambdaSieve
{
    internal class Program
    {
        public static void Main(string[] args)

        {

            Collector collector = new Collector();

            try
            {
                collector.PickFilter();

                var filterType = collector.filterType;

                var sieve = collector.CreateSieve(filterType);

                collector.UseSieveRepeatedly(sieve);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }
}