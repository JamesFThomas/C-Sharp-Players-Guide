/*

Title: The Proprrties Of Arrows 
 
Story: 
- Vin's cousin Flynn Vetcher, is the only other arrow maker in the city. He doesn't care for his craft as much and makes wildly overpriced arrows.
But people keep buying them becuse they thing that Vin's GetLength() methods are harder to work with than Fylnns public _length fields.
Vins dosen't want to give up the protections you just aded to the Arrow class, but he remembeers you talking about Properties and wants you to help imporve the Arrow class with them. 

Objectives:
- Modify your Arrow class to use the properties instead of GetX and SetX methods.
- Ensure the whoe program still runs, and Vin can keep creating arrows with it.

*/

// Local variables
string userArrowheadChoice = "";
string userFletchingChoice = "";
float userLengthChoice = 0;



// Application 
CollectArrowChoice();
CollectFletchingChoice();
CollectArrowLength();
CreateAnArrow();



// Local methods
void CollectArrowChoice()
{
    string? arrowheadChoice;

    Console.Write("What type of arrowhead do you want? (steel, wood, obsidian): ");
    arrowheadChoice = Console.ReadLine();

    if (string.IsNullOrEmpty(arrowheadChoice))
    {

        CollectArrowChoice();

    }
    if (arrowheadChoice?.ToLower() != Arrowhead.steel.ToString().ToLower() &&
         arrowheadChoice?.ToLower() != Arrowhead.obsidian.ToString().ToLower() &&
         arrowheadChoice?.ToLower() != Arrowhead.wood.ToString().ToLower())
    {
        CollectArrowChoice();
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

void CreateAnArrow()
{
    // create an arrow object
    Arrow yourArrow = new Arrow(userArrowheadChoice, userFletchingChoice, userLengthChoice);

    Console.WriteLine($"Your arrow will cost {yourArrow.CalculateCost()}");
}

// Types && Classes
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
    private float  Length { get; }


    // Constructor
    public Arrow(string arrowhead, string fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;

    }

    // Methods
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