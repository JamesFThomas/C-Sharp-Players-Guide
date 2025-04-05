/*

 Title: Buying Inventory && Discounted Inventory 

 Menu: prices in gold
    Rope - 10
    Torches - 15
    Climbing Equipment - 25
    Clean Water - 1
    Machete - 20
    Canoe - 200
    Food Supplies - 1

 Objectives ( Buying Inventory ):
    - Build a porgram that will show the menu illustrated above. 

    - Ask the user to enter a number from the menu. 

    - Using the information above, use a switch  (either type) to show the item's cost. 

 Objectives ( Discounted Inventory ):
    - Modify your program from before to also ask the user for their name. 

    - If their nameequals your name, divide the cost in half.


 */

int item;
string name;

Console.WriteLine("Menu Items\r\n1 - Rope\r\n2 - Torches\r\n3 - Climbing Equipment\r\n4 - Clean Water\r\n5 - Machete\r\n6 - Canoe\r\n7 - Food Supplies");

Console.Write("Enter a number from the above menu to get the item's price: ");

item = Convert.ToInt32(Console.ReadLine());

Console.Write("What is your name?");

name = Console.ReadLine();



switch (item)
{
    case 1:
        int price = 10;
        Console.WriteLine($"{(name == "James" ? (price / 2) : price)} gold");
        break;
    case 2:
        price = 15;
        Console.WriteLine($"{(name == "James" ? (price / 2) : price)} gold");
        break;
    case 3:
        price = 25;
        Console.WriteLine($"{(name == "James" ? (price / 2) : price)} gold");
        break;
    case 4:
        price = 1;
        Console.WriteLine($"{(name == "James" ? (price / 2) : price)} gold");
        break;
    case 5:
        price = 20;
        Console.WriteLine($"{(name == "James" ? (price / 2) : price)} gold");
        break;
    case 6:
        price = 200;
        Console.WriteLine($"{(name == "James" ? (price / 2) : price)} gold");
        break;
    case 7:
        price = 1;
        Console.WriteLine($"{(name == "James" ? (price / 2) : price)} gold");
        break;
    default:
        Console.WriteLine("Not a menu item, choose another number");
        break;
}
