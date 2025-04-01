/* Ask user for name of thing */
Console.WriteLine("What kind of thing are we talking about?");

string a = Console.ReadLine(); // collect name of thing form user

/* Ask user for decription of named thing */
Console.WriteLine("How would you describe it? Big? Azure? Tattered"); 

string b = Console.ReadLine(); // collect description of thing from user

string c, d; // declare variables for later use

c = " of Doom";

d = " 3000"; 

Console.WriteLine("The " + a + " " + b + c + d + "!"); // print out the name, description, and variables


