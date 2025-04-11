
/*

Title: Arrow Factories  
 
Story: 
- Vin Fletcher sometimes makes custom-ordered arrows , but these are rare.  Most of the time, he sells one of the following standard arrows: 
    --> The Elite Arrow --> arrowhead = steel, fletching = plastic, shaft length = 95cm
    --> The Pro Arrow --> arrowhead = wood, fletching = goose feathers, shaft length = 75cm
    --> The Marksman Arrow --> arrowhead = steel, fletching = goose feathers, shaft length = 65cm
You can make static method to make these specific variations of arrows easier to make on demand. 

Objectives:
- Modify your Arrow class one final time to include static methods of the form public static Arrow CreatEliteArrow(){...} for each of the above arrow types.

- Modify the program to allow users to choose one of these pre-defined types or a custom arrow. If they select one the predefined styles, produce an arrow instance
  using one of the new static methods. If they choose to make a custom arrow, use your earlier code to get their custom data about the desired arrow. 

*/
int userArrowTypeChoice;
string userArrowheadChoice = "";
string userFletchingChoice = "";
float userLengthChoice = 0;


// Do you want a premade or custom arrow today? 
CollectArrowTypeChoice();
if (userArrowTypeChoice == 1)
{
    // 1 == premade -> go through new methods to use static methods 
    CreatePremadeArrow();
    
}
// 2 == custom - go through old methods
if ( userArrowTypeChoice == 2 ) 
{ 
    CollectArrowheadChoice();
    CollectFletchingChoice();
    CollectArrowLength();
    CreateCustomArrow();
}


// local methods

void CollectArrowTypeChoice()
{
    int arrowTypeChoice;
    Console.Write("What type of arrows are you looking for? ( 1 - premade, 2 custom ):  ");
    arrowTypeChoice = Convert.ToInt16(Console.ReadLine());

    if ( arrowTypeChoice != 1 && arrowTypeChoice != 2)
    {
        CollectArrowTypeChoice();
    }
    else 
    {
        userArrowTypeChoice = arrowTypeChoice;
    }
}

// make custom arrow methods 

void CollectArrowheadChoice()
{
    string? arrowheadChoice;

    Console.Write("What type of arrowhead do you want? (steel, wood, obsidian): ");
    arrowheadChoice = Console.ReadLine();

    if (string.IsNullOrEmpty(arrowheadChoice))
    {

        CollectArrowheadChoice();

    }
    if (arrowheadChoice?.ToLower() != Arrowhead.steel.ToString().ToLower() &&
         arrowheadChoice?.ToLower() != Arrowhead.obsidian.ToString().ToLower() &&
         arrowheadChoice?.ToLower() != Arrowhead.wood.ToString().ToLower())
    {
        CollectArrowheadChoice();
    }

    if (!string.IsNullOrEmpty(arrowheadChoice)) userArrowheadChoice = arrowheadChoice.ToLower();


}

void CollectFletchingChoice()
{
    string? fletchingChoice;

    Console.Write("What type of fletching do you want? (plastic, turkey, goose): ");
    fletchingChoice = Console.ReadLine();

    if (string.IsNullOrEmpty(fletchingChoice))
    {
        CollectFletchingChoice();
    }

    if (fletchingChoice != Fletching.plastic.ToString().ToLower() &&
         fletchingChoice != Fletching.turkey.ToString().ToLower() &&
         fletchingChoice != Fletching.goose.ToString().ToLower())
    {
        CollectFletchingChoice();
    }

    if (!string.IsNullOrEmpty(fletchingChoice)) userFletchingChoice = fletchingChoice;
}

void CollectArrowLength()
{
    float lengthChoice = 0;

    Console.Write("Enter the desired length of your arrows? (60 - 100 cm): ");
    string? input = Console.ReadLine();

    if (string.IsNullOrEmpty(input) || !float.TryParse(input, out lengthChoice) || lengthChoice < 60 || lengthChoice > 100)
    {
        Console.WriteLine("Invalid input.");
        CollectArrowLength();
    }
    else
    {
        userLengthChoice = lengthChoice;
    }
}

void CreateCustomArrow()
{
    // create an arrow object
    Arrow yourArrow = new Arrow(userArrowheadChoice, userFletchingChoice, userLengthChoice);

    Console.WriteLine($"Your arrow will cost {yourArrow.CalculateCost()}");
}

void CreatePremadeArrow()
{
    int premadeChoice;
    Arrow arrow;

    Console.Write("Whic of our great premdae arrow would you like? ( 1 = elite, 2 = pro, 3 = marksman ):  ");
    premadeChoice = Convert.ToInt16(Console.ReadLine());

    if (premadeChoice != 1 && premadeChoice != 2 && premadeChoice != 3)
    {
        CreatePremadeArrow();
    }

    if (premadeChoice == 1)
    {
        arrow = Arrow.CreateEliteArrow();
        Console.WriteLine($"Your arrow will cost {arrow?.CalculateCost()}");
    }
    if (premadeChoice == 2)
    {
        arrow = Arrow.CreateProArrow();
        Console.WriteLine($"Your arrow will cost {arrow?.CalculateCost()}");
    }
    if (premadeChoice == 3)
    {
        arrow = Arrow.CreateMarksmanArrow();
        Console.WriteLine($"Your arrow will cost {arrow?.CalculateCost()}");
    }



}

// TYpes && Classes
enum Arrowhead
{
    steel,
    wood,
    obsidian
}



enum Fletching
{
    plastic,
    turkey,
    goose
}



internal class Arrow
{
    // Fields + Properties
    private string Arrowhead { get; }
    private string Fletching { get; }
    private float Length { get; }


    // Cconstructor
    public Arrow(string arrowhead, string fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;

    }

    // Methods

    public static Arrow CreateEliteArrow()
    {
        string Arrowhead = "steel";
        string Fletching = "plastic";
        float Length = 95;

        Arrow eliteArrow = new Arrow(Arrowhead, Fletching,Length);

        return eliteArrow;

    }
    public static Arrow CreateProArrow()
    {
        string Arrowhead = "wood";
        string Fletching = "goose";
        float Length = 75;

        Arrow proArrow = new Arrow(Arrowhead, Fletching, Length);

        return proArrow;
    }

    public static Arrow CreateMarksmanArrow()
    {
        string Arrowhead = "steel";
        string Fletching = "goose";
        float Length = 65;

        Arrow marksmanArrow = new Arrow(Arrowhead, Fletching, Length);

        return marksmanArrow;

    }

    public float CalculateCost()
    {

        float arrowCost = 0, fletchingCost = 0, shaftCost;

        switch (Arrowhead)
        {
            case "steel":
                arrowCost = 10;
                break;
            case "obsidian":
                arrowCost = 5;
                break;
            case "wood":
                arrowCost = 3;
                break;
        }

        switch (Fletching)
        {
            case "plastic":
                fletchingCost = 10;
                break;
            case "turkey":
                fletchingCost = 5;
                break;
            case "goose":
                fletchingCost = 5;
                break;
        }

        shaftCost = Length * 2;

        var totalCost = arrowCost + fletchingCost + shaftCost;

        return totalCost;

    }



}