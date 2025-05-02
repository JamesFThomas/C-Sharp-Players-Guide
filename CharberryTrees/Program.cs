/*

Title: Charberry Trees


Story:

The Island of Eventia survives by harvesting the fruit of the native charberry tree.
Harvesting charberry fruit requires three people and an afternoon, but tow is enough to feed a family for a week. 
Charberry trees fruit randomly, requiring somebody to frequently check in on the plants to notice one has fruited.
Eventia will give you the Medallion of Events if you can help them with two things: 
    
    1) automatically notify people when a tree ripens 
    
    2) automatically harvest the fruit.

Their tree looks like this: 

CharberryTree tree = new CharberryTree()

while(true)
{
    tree.MaybeGrow();
}

public class CharberryTree 
{
    private Random _random = new Random();
    public bool Ripe { get: set; }

    public void MaybeGrow()
    {
        if( _random.NextDouble() < 0.00000001 && !Ripe )
        {
            Ripe = true;
        }

    }


}


Objective:

- Make a new project that includes the above code.

- Add a Ripened event to the CharberryTree class that is raised when the tree ripens. 

- Make a Notifier class that knows about the tree and subscribes to its Ripened event. Attach a handler that displays something like "A charberry fruit has ripened" to the console window.
    --> Hint: perhaps pass it in as a constructor parameter 
 
- Make a Harvester class that knows about the tree and subscribes to it's Ripened event. Attach a handler that sets the tree's Ripe property back to false.   
    --> Hint: like the notifier class, this could be passed as a constructor parameter. 

- Update your main method to create a tree, notifier, and harvester, and get them to work together to grow, notify, and harvest forever. 


*/

namespace CharberryTrees
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            CharberryTree tree = new CharberryTree();
            Notifier notifier = new Notifier(tree);
            Harvester harvester = new Harvester(tree);

            try
            { 
                while (true)
                {
                    tree.MaybeGrow();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

    }
}