/*
 
Title: The Card 

Story: 

The digital Relams of C# has playing vards like ours but with some differences. 
Each card has a color (red, green, blue, yellow) and a rank ( the numbers 1 - 10, follwed by the symbols $ = jack/dollar sign, % = queen/modulo , ^ = king/caret, & = ace/ampersand).
Create a class to repsent a card of this nature. 




Objectives: 

- Define Enumerations for card colors and card ranks. 

- Define a Card class to represent a card with a color and a rank, as described above. 

- Add properties or methods, that tell you if the card is number or a symbol card ( the equivalent of a face card).

- Create a main method that will create a card instance for the whole deck (every color with every rank) and display each
  ( for example "The Red Ampersand" and "The Blue Seven")

- Answer this question: Why do you think we used a color enumeration here but made a color class in the previous challenge? 

*/

// I need to create a method that creates a a card of every color for every rank

for (int i = 1; i <= 4; i++)
{

    for (int j = 1; j < 14; j++)
    {
        CardColor color = (CardColor)i;
        CardRank rank = (CardRank)j;

        Card card = new Card(rank, color);

        card.RankAndColor();
    }

}


public enum CardRank
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    DollarSign = 11,
    Modulo = 12,
    Caret = 13,
    Ampersand = 14
}

public enum CardColor
{
    Red = 1,
    Green = 2,
    Blue = 3,
    Yellow = 4
}

public class Card
{
    private CardRank _rank;
    private CardColor _color;

    public Card(CardRank rank, CardColor color)
    {
        _rank = rank;
        _color = color;
    }

    public void FaceOrNumber()
    {
        string type = _rank <= CardRank.Ten ? "Number" : "Face";
        Console.WriteLine($"This is a {type} card");
    }

    public void RankAndColor()
    {
        Console.WriteLine($"The {_color} {_rank}");
    }
}
