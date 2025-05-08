/*
 
Title: The Robot Factory

Story: 

The Regent of Dynamak is impressed with your dynamic skills and has asked for you to help bring their robot factory back online.
It was damaged in the Uncoded Ones arrival.
Robots are manifactored by collecting their details, all of which are optional except for the numeric ID property. 
After the information is collected the robot is created by displaying its details in the console window. 

Here are two examples: 

You are producing Robot #1.
Do you want to name this robot?  no
Does this robot have a specific size? no 
Does this robot need to be specific color? no

ID: 1

You are producing Robot #2.
Do you want to name this robot?  yes
What is its name? R2-D2
Does this robot have a specific size? yes
What size is it's height? 9
What size is it's width? 4
Does this robot need to be specific color? yes
What color is the robot? azure

ID:2
Name: R2-D2
Height: 9
Width: 4
Color: azure


In exchange, she offers the Dynamic Medallion and all robots the factory makes before you fight the Uncoded One. 

Objectives:

- Create a new dynamic variable, holding a reference to an ExpandoObject.  

- Give the dynamic object an ID property whos type is an int and assign each robot a new number.

- Ask the user if they want to name the robot and if they do collect it and store it in the name property. 

- Ask them if they wan to provide a size for the robot, and if they do collect a width and height value from the user and stor the Width and Height properties 

- Ask if they want to choose a color for the robot. If so store their choice ina Color property.

- Display all existing properties for the robot to the console window using the following code: 

foreach ( KeyValuePair<string, object>  property in (IDictionary<string, object>)robot)
{
    Console.WritLne($"{property .Key}: {property .Value}")
}

- Loop repeatedly to allow the user to degin and build multiple robots

 */


namespace TheRobotFactory
{
    internal class Program
    {

        public static void Main(string[] args)
        {

            Console.WriteLine(" The Robot Factory Working");

        }



    }

}