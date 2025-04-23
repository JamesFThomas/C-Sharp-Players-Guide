/*

Title: Colored Items


Story:

You have a sword, a bow , and an axe in front of you, defined like this: 

public class Sword{}
public class Bow{}
public class Axe{}

You want to associate a color with these items ( or any item type). 
You could make a ColoredSword derived from Sword that adds a Color property, but doing this for all three item types will be painstaking. 
Instead, you define a new generic ColoredItems class that does this for any item. 


Objectives:

- Put three Class definitions from the story into a new project. 

- Define a generic class to represent a colored item. It must have properties for the item itself (generic in type) and a ConsoleColor associated with it. 

- Add a void Display() method to your ColoredItem type that changes the consoles foreground color to the item's color and displays the item in the color.
    --> Hint: It is sufficient to just call ToString() on the item to get a text representation of it.

- In your main method, create a new colored item containing a blue sword, a red bow, and a green axe.
    --> Display all three items to see each item displayed in its color. 

 
*/


// Use the ColoredItem generic type with the Sword, Bow, and Axe types.
// --> make the new variable of type ColoredItem<Sword>, ColoredItem<Bow>, and ColoredItem<Axe> respectively
// ---> set each variable to a new ColoredItem with the correct parameters passed into the generic type constructor 

ColoredItem<Sword> blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);

ColoredItem<Bow> redBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);

ColoredItem<Axe> greenAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);


Console.WriteLine("Colored Items:");
blueSword.Display();
redBow.Display();
greenAxe.Display();



public class ColoredItem<T>
{
    public T Item { get; set; } // generic item field
    public ConsoleColor Color { get; set; } // color must be of console color type

    public ColoredItem(T item, ConsoleColor color) // constructor sets the item and color with expected types   
    {
        Item = item;
        Color = color;
    }

    public void Display()  // will display the item name in the color specified 
    {
        string? itemName = Item?.ToString(); // string representing Item name
        Console.ForegroundColor = Color; // set foreground color to Item Color value
        Console.WriteLine(itemName); // display the item name
        Console.ResetColor(); // reset the color to default
    } 
}

public class Sword { }
public class Bow { }
public class Axe { }