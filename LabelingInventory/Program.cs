/*
 
Title: Labeling Inventory 

You realize that your inventory items are not easy to sort through. If you could make it easy to label all of your inventory items, it would be easier to know what items are in your pack.

Modify your inventory program from the previous level as described below.

Objectives:

- Override the existing ToString() method ( from the object base class) on all your inventory subclasses to give them a name. 
    --> For example: new Rope().ToString() returns "Rope".

- Override ToString() on the Pack class to display the contents of the pack. If a pack contains water, rope and two arrows, then calling ToString() on that Pack object could look like this:
    --> "Pack containing: Water, Rope, Arrow, Arrow"

- Before the user chooses the next item to add, display the pack's current contents via its new ToString method.

 
*/



// Program 
LoadPackProgram program = new LoadPackProgram();

program.Start();



// Classes

public class LoadPackProgram
{
    public void Start()
    {
        Console.WriteLine("Welcome to the Inventory System!");

        Pack pack = CreateNewPack();

        LoadPack(pack);

    }

    public Pack CreateNewPack()
    {
        Pack pack;

        Console.WriteLine("Please enter the maximum number of items your pack can hold:");
        int maxItems = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Please enter the maximum weight your pack can hold:");
        double maxWeight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Please enter the maximum volume your pack can hold:");
        double maxVolume = Convert.ToDouble(Console.ReadLine());

        pack = new Pack(maxItems, maxWeight, maxVolume);
        Console.WriteLine($"Pack created successfully! \r\n max items: {maxItems}, max weight: {maxWeight}, max volume: {maxVolume}.\r\n");

        return pack;
    }

    public void LoadPack(Pack pack)
    {
        InventoryItem currentItemToAdd;

        bool wasAdded = false;


        while (pack.GetCurrentItemCount() <= pack.GetMaxItemCount() && pack.GetCurrentVolume() <= pack.GetMaxVolume() && pack.GetCurrentVolume() <= pack.GetMaxVolume())
        {

            pack.DisplayPackContents();

            currentItemToAdd = pack.PickItem();

            wasAdded = pack.AddItem(currentItemToAdd);

            ItemAddedMessage(currentItemToAdd, wasAdded);

            if (pack.GetCurrentWeight() == pack.GetMaxWeight())
            {
                PackReachedLimit(1);
                break;
            }

            if (pack.GetCurrentVolume() == pack.GetMaxVolume())
            {
                PackReachedLimit(2);
                break;
            }

            if (pack.GetCurrentItemCount() == pack.GetMaxItemCount())
            {
                PackReachedLimit(3);
                break;
            }


        }

    }

    public void ItemAddedMessage(InventoryItem currentItemToAdd, bool wasItemAdded)
    {
        if (wasItemAdded)
            Console.WriteLine($"\n Item: {currentItemToAdd.GetType().Name} volume: {currentItemToAdd.Volume} weight: {currentItemToAdd.Weight} was ADDED to your pack!");

        else
            Console.WriteLine($"Failed to add {currentItemToAdd.GetType().Name} to the pack. \nAdding this item would exceed a set pack limit!");
    }

    public void PackReachedLimit(int messageNumber)
    {
        if (messageNumber == 1)
            Console.WriteLine("Pack has reached max weight! No more items can be added.");

        if (messageNumber == 2)
            Console.WriteLine("Pack has reached max Volume! No more items can be added.");

        if (messageNumber == 3)
            Console.WriteLine("Pack has reached max Item limit! No more items can be added.");
    }

}

public class InventoryItem
{
    public double Weight { get; }
    public double Volume { get; }

    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }


}


// Derived Classes
public class Arrow : InventoryItem
{
    public Arrow() : base(0.1, 0.05) { }
}

public class Bow : InventoryItem
{
    public Bow() : base(1, 4) { }
}

public class Rope : InventoryItem
{
    public Rope() : base(1, 1.5) { }
}

public class Water : InventoryItem
{
    public Water() : base(2, 3) { }
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1, 0.5) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5, 3) { }
}



public class Pack
{
    private InventoryItem[] items;
    private double maxWeight;
    private double maxVolume;

    public Pack(int itemMax, double weightMax, double volumeMax)
    {
        items = new InventoryItem[itemMax];
        maxWeight = weightMax;
        maxVolume = volumeMax;
    }

    public double GetMaxWeight() => maxWeight;
    public double GetMaxVolume() => maxVolume;
    public int GetMaxItemCount() => items.Length;

    public int GetCurrentItemCount()
    {
        int currentCount = 0;
        foreach (InventoryItem item in items)
        {
            if (item != null)
            {
                currentCount++;
            }
        }
        return currentCount;
    }

    public double GetCurrentWeight()
    {
        double currentWeight = 0;
        foreach (InventoryItem item in items)
        {
            if (item != null)
            {
                currentWeight += item.Weight;
            }
        }
        return currentWeight;
    }

    public double GetCurrentVolume()
    {
        double currentVolume = 0;
        foreach (InventoryItem item in items)
        {
            if (item != null)
            {
                currentVolume += item.Volume;
            }
        }
        return currentVolume;
    }

    public void DisplayItemsMenu()
    {
        string itemMenu = @"
Item Menu:
    1) Arrow =>     weight: .1,  volume: .05
    2) Bow =>       weight: 1,   volume: 4
    3) Rope =>      weight: 1,   volume: 1.5
    4) Water =>     weight: 2,   volume: 3
    5) Rations =>   weight: 1,   volume: .5
    6) Sword =>     weight: 5,   volume: 3
    ";
        Console.WriteLine(itemMenu);
    }

    public InventoryItem PickItem()
    {
        InventoryItem item;
        int itemNumber;

        DisplayItemsMenu(); // Display the item menu

        Console.WriteLine("Please select an item by menu number to add to your pack:");

        // Get user input
        itemNumber = Convert.ToInt32(Console.ReadLine());


        if (itemNumber == 1)
        {
            item = new Arrow();
        }
        else if (itemNumber == 2)
        {
            item = new Bow();
        }
        else if (itemNumber == 3)
        {
            item = new Rope();
        }
        else if (itemNumber == 4)
        {
            item = new Water();
        }
        else if (itemNumber == 5)
        {
            item = new FoodRations();
        }
        else if (itemNumber == 6)
        {
            item = new Sword();
        }
        else
        {
            Console.WriteLine("Invalid item number. Please try again.");
            return PickItem();
        }

        return item; // return the selected item 

    }

    public bool CanAddItem(InventoryItem item)
    {
        if (GetCurrentItemCount() + 1 > GetMaxItemCount()) return false;

        if (GetCurrentWeight() + item.Weight > GetMaxWeight()) return false;

        if (GetCurrentVolume() + item.Volume > GetMaxVolume()) return false;

        return true;
    }

    public bool AddItem(InventoryItem item)
    {
        bool itemAdded = false;

        // check to see if item can be added
        if (!CanAddItem(item)) return itemAdded;

        // add single item to the pack
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                itemAdded = true;
                break; // exit loop after adding item
            }
        }

        return itemAdded;
    }

    public void DisplayPackContents()
    {
        Console.WriteLine("\nPack Contents:");

        foreach (InventoryItem item in items)
        {
            if (item != null)
            {
                Console.WriteLine($"- {item.GetType().Name} => weight: {item.Weight}, volume: {item.Volume}");
            }

            continue;
        }

        Console.WriteLine($"    Total Weight/Max Weight: {GetCurrentWeight()} / {GetMaxWeight()}");
        Console.WriteLine($"    Total Volume/Max Volume: {GetCurrentVolume()} / {GetMaxVolume()}");
        Console.WriteLine($"    Total Items/Max Items: {GetCurrentItemCount()} / {GetMaxItemCount()}");
    }

}
