/*
 
Title: The Color 

Story: 

The Color consists of three parts or channels: red, green, and blue, which indicate how much those channels are lit up. Each channel has a range form 0 - 255. 
0 means the channel is completely off, while 255 means it is compleetly on. 

The pedestal  also includes some comon color names with their values:
White   => (255, 255, 255)
Black   => (0, 0, 0)
Red     => (255, 0, 0)
Orange  => (255, 165, 0)
Yellow  => (255, 255, 0)
Green   => (0, 128, 0)
Blue    => (0, 0, 255)
Purole  => (128, 0, 128)


Objectives: 

- Define a new Color class with properties for its red, green, and blue channels.

- Add appropriate constructores that you feel make sense for creating new Color objects.

- Create static properties to define the eigth commonly used colors for easy access. 

- In your main method, make two Color-typed variables. Use a constructor to create a color instance and use static property for the other.

- Display each of their red, green, and blue channel values.

*/

Color colorStatic = Color.Green();

Color colorCustom = new Color(165, 33, 121);

colorCustom.DisplayChannelSettings();

colorStatic.DisplayChannelSettings();



public class Color
{

    // fields
    private int _red { get; }
    private int _green { get; }
    private int _blue { get; }


    // constructor 
    public Color( int red, int green, int blue)
    { 
        _red = red;
        _green = green;
        _blue = blue;
   
    }



    // Static properties

    public static Color White()
    {
        int red = 255;
        int green = 255;
        int blue = 255;

        Color color = new Color(red, green, blue);

        return color;

    }

    public static Color Black()
    {
        int red = 0;
        int green = 0;
        int blue = 0;

        Color color = new Color(red, green, blue);

        return color;
    }

    public static Color Red()
    {
        int red = 255;
        int green = 0;
        int blue = 0;

        Color color = new Color(red, green, blue);

        return color;
    }
    public static Color Orange()
    {
        int red = 255;
        int green = 165;
        int blue = 0;

        Color color = new Color(red, green, blue);

        return color;

    }

    public static Color Yellow()
    {

        int red = 255;
        int green = 255;
        int blue = 0;

        Color color = new Color(red, green, blue);

        return color;

    }

    public static Color Green()
    {

        int red = 0;
        int green = 128;
        int blue = 0;

        Color color = new Color(red, green, blue);

        return color;
    }

    public static Color Blue()
    {
        int red = 0;
        int green = 0;
        int blue = 255;

        Color color = new Color(red, green, blue);

        return color;

    }

    public static Color Purple()
    {

        int red = 128;
        int green = 0;
        int blue = 128;

        Color purple = new Color(red, green, blue);

        return purple;
    }


    public void DisplayChannelSettings()
    { 
        Console.WriteLine($"({_red}, {_green}, {_blue})");
    }

}

