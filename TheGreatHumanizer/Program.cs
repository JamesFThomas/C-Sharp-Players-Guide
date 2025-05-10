/*

Title: The Great Humanizer


Story: 

The people in the village of New Ghett come to you with a complaint. 

"Our leaders keep giving us DateTimes that are hard to understand." Thy show you an example: 

Console.WriteLine($" When is the feast? {DateTime.UtcNow.AddHours(30)}");

This code displays things like the following:

When is the feast? 5/10/2025 5:19 pm 

"We keep showing yo too early or too late for the feasts! We have to pull out our clocks and calendars! Isn't there a better way?"

When pressed, they describe what they would prefer: "What if is said something like ^ hours from now or 6 days from now?"

This easier way to understand, and we wouldn't show up too early or too late. If you can do this for us we can retrieve the NuGet Medallion for you.

You know that writing code to convert times and dates to human friendly strings would be a lot of work, but you suspect other programmers have already solved this problem and made a NuGet package for it.   


Objectives: 

- Start by making a new program that does what was shown above: displaying the raw DateTime.

- Add th NuGet package Humanizer.Core to your project using the instructions in this level. 
    --> This NuGet package provides many extension methods (Level 34) that make it easy to display things in human readable formats. 

- Call the new DateTime extension method Humanize() provided by this library to get a better format. 
    --> You will also need to add a using Humanizer directive to call this.

- Run the program with a few different hour offsets DateTime.UtcNow>AddHours(2.5) and DateTime.UtcNow>AddHours(50) to see that it correctly displays a human-readable mesage. 

 
*/

using Humanizer;


var date1 = DateTime.UtcNow.AddHours(2.5);
var date2 = DateTime.UtcNow.AddHours(50);


Console.WriteLine(date1.Humanize());

Console.WriteLine(date2.Humanize());


