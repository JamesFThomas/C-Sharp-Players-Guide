/*

Title: Vin Fletcher's Arrows  && Vin's Trouble


Story: 
Each arrow has three parts: the arrowhead (steel, wood, obsidian ), the shaft (a length 60 - 100 cm ), and the fletching ( plastic, turkey feathers, goose feathers  ).

Vin's costs are as follows: arrowheads (steel == 10 gold, wood == 3 gold, obsidian == 5 gold), flecthing ( plastic == 10 gold, turkey feathers == 5 gold , goose feathers == 5 gold ), the shaft ( .05 cm x 1 gold)


Objectives: Vin Fletcher's Arrows
- Define a n Arrow class with fields for the arrowhead, shaft, and fletching.
    --> HINT: arrowhead and fletching types might be good candidates for enums

- Allow a usuer to pick the arrowhead, shaft, and fletching type then create an Arrow object/instance.

- Add a GetCost method that returns its cost as a float based on the numbers above, and use this to display the arrows' cost.



Story: 
After creating the program for Vin to create arrows for users he has a problem in which a customer updated the length of the arrow to be incorrect for that bow and he injured himself.
So to avoid anyone else form being able to do the same thing Vin wants you to stop this from happening in the future when customers order their arrows. 



Objectives: Vin Trouble
- Modify your Arrow class to have private instead of public fields. 

- Add getter methods for each of the fields that you have.
 
*/

string userArrowheadChoice = "";
string userFletchingChoice = "";
float userLengthChoice = 0;



CollectArrowChoice();
CollectFletchingChoice();
CollectArrowLength();
CreateAnArrow(); 


// break methods to get user choices in there own methods 
void CollectArrowChoice()
{
    string? arrowheadChoice; 

    Console.Write("What type of arrowhead do you want? (steel, wood, obsidian): ");
    arrowheadChoice = Console.ReadLine();

    if (string.IsNullOrEmpty(arrowheadChoice))
    {

        CollectArrowChoice();

    }
    if ( arrowheadChoice.ToLower() != Arrowhead.steel.ToString().ToLower() &&
         arrowheadChoice.ToLower() != Arrowhead.obsidian.ToString().ToLower() &&
         arrowheadChoice.ToLower() != Arrowhead.wood.ToString().ToLower())
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

    if(!string.IsNullOrEmpty(fletchingChoice)) userFletchingChoice = fletchingChoice; 
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

    Console.WriteLine($"Your arrow will cost {yourArrow.GetCost()}");
}

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
    // fields
    private string _arrowhead;
    private string _fletching;
    private float _length;


    //constructor
    public Arrow(string arrowhead, string fletching, float length  )
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;

    }


    //methods 
    public string GetArrowhead() =>_arrowhead;

    public string GetFletching() => _fletching;

    public float GetLength() =>  _length;
 

    public float GetCost()
    {
        // arrowheads (steel == 10 gold, wood == 3 gold, obsidian == 5 gold)
        // flecthing ( plastic == 10 gold, turkey feathers == 5 gold , goose feathers == 5 gold )
        // shaft ( .05 cm x 1 gold)
        
        float arrowCost = 0, fletchingCost = 0, shaftCost;

        switch (_arrowhead)
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

        switch (_fletching)
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

        shaftCost = _length * 2;

        var totalCost = arrowCost + fletchingCost + shaftCost;

        return totalCost;

    }



}