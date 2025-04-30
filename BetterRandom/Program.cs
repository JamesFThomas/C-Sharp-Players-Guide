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

- Create a new static class to ad extensions methods for Random 

- As described above, add, a NextDouble extension method that gives a maximum value for a randomly generated double.

- Add a NextString extension method Random that allows you to pass in any number of string values ( using params ) and randomly pick one of them.

- Add a CoinFlip method that randomly picks a bool value. It should have an optional parameter that indicates the frequency of heads coming up, which should default to .5, or 50% of the time.

- Answer this question: In your opinion, would it be better to make a derived AdvancedRandom class that adds these methods or use extension methods and why? 
    --> Answer: 
 
 
*/