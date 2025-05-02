/*

Title: The Sieve


Story: 

The island of Delgata is home to the Numeromechanical Sieve, a machine that take in numbers and judges them be good or bad. 
In ancient times the Sieve could be supplied with a single method by the island's ruler, making the machine adaptable as leadership changed over time. 
The Delgatans will give you the Medallion of Delegates if you can reforge the Sieve. 


Objective:

- Create a Sieve class with a public bool iGood(int number) method.This class needs a delegate parameter that can be invoked later within the isGood() method. 
    --> Hint: You cna make you ow delegate type to use Func<int bool>.

- Define methods with an int parameter and bool return type for the following: 
    --> returns true for even numbers 
    --> returns true for positive numbers 
    --> returns true for multiples of 10 

- Create a program that asks the user to pick of these three filters, constructs a new Sieve instance by passing one of those methods as a parameter, and then ask the user to enter numbers repeatedly, displaying whether or not the number is good or bad depending on the filter in use.   

- Answer this question: Describe how you could have also solved this problem with inheritance and polymorphism. Which solution seems more straightforward to you, and why?  
 
*/

