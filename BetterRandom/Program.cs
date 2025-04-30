/*
 
Title: Better Random 


Story:

The Villagers of Randertherin often use the Random class but struggle with it's limited capabilities. 
They have asked for your help to make Random better. They offer you the Medallion of Powerful Methods in exchange. 
Their complaints are as follow: 

- Random.NextDouble() only return values between 0 and 1, and they often need to be bale to produce random double values between 0 and another number, such as 0 to 10.

- They need to randomly choose from one of several strings, such as "up", "down", "left", "right", with each having an equal probability of being chosen.

- They need to do a coin toss randomly picking a bool, and usually want it to be a fair coin toss (50% heads and 50% tails) but occasionally want unequal probabilities. 
    --> example: 75% chance of true and 25% chance of false

Objective: 

- Create a new static class to add extensions methods for Random 

- As described above, add, a NextDouble extension method that gives a maximum value for a randomly generated double.

- Add a NextString extension method Random that allows you to pass in any number of string values ( using params ) and randomly pick one of them.

- Add a CoinFlip method that randomly picks a bool value. It should have an optional parameter that indicates the frequency of heads coming up, which should default to .5, or 50% of the time.

- Answer this question: In your opinion, would it be better to make a derived AdvancedRandom class that adds these methods or use extension methods and why? 
    --> Answer: 
        Personally I would make a derived class and add these methods rather than use the extension approach because I am more comfortable with that understanding. 
        The this parameter can be a little confusing but I se the benefit of using both.  
 
 
*/


using System.Numerics;
using System; 

Random random = new Random();

string[] strings = new[] { "Kayla", "James", "Henry", "Della", "John" };

double myDouble = random.NextDouble(41);

string randomString = random.NextString(strings);

bool myBool = random.CoinFlip(); 


Console.WriteLine(myDouble.ToString());

Console.WriteLine(randomString);

Console.WriteLine(myBool.ToString());


public static class RandomExtensions
{

    public static double NextDouble(this Random random, double maxValue = 1.0  )
    {
        double result = random.Next() * maxValue;

        return result;
    }

    public static string NextString(this Random random, params string[] arguments)
    {
        
        int index = random.Next( arguments.Length );

        return arguments[ index ];
    }


    public static bool CoinFlip(this Random random, double percent = .5)
    {
        if (random.NextDouble() < percent)
        {
            return true;
        }

        return false;

    }
}