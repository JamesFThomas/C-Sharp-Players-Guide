/*

Title: The Feud

Story:

On the Island of Namespaces two families are caretakers of the medallion of namespaces. 
They families are feuding, The iFields and the McDroids. 
The iFields ranch sheep and pigs while the McDroids ranch pigs and cows.
Since both families have pigs they are having conflicts. 
The two families will give the medallion of namespaces if you resolve their dispute and help them track their animals. 

Objectives:

- Create a Sheep class in the iField namespace ( fully qualified name of IField.Sheep )

- Create a Pig class in the iField namespace ( fully qualified name of IField.Pig )

- Create a Cow class in the McDroid namespace  ( fully qualified name of McDroid.Cow )

- Create a Pig class in the McDroid namespace ( fully qualified name of McDroid.Pig )

- For your main method, add using directives for both IField and McDroid namespaces. Make new instances of all four classes.
--> There are no conflicts with Sheep and Cow, so make sure you can create new instances of those with new Sheep() and new Cow() constructors.
--> Resolve the conflict with Pig by using the fully qualified name of the class or aliasing the class name.
 
*/

using TheFeud.IField;
using TheFeud.McDroid;
using MPig = TheFeud.McDroid.Pig;
using IPig = TheFeud.IField.Pig;

var sheep = new Sheep();
var cow = new Cow();
var pig1 = new IPig();
var pig2 = new MPig();

sheep.Sound();
cow.Sound();
pig1.Sound();
pig2.Sound();





namespace TheFeud.IField
{
 
    public class Sheep
    { 
        public void Sound()
        {
            Console.WriteLine("Baa");
        }
    }

    public class Pig
    {
        public void Sound()
        {
            Console.WriteLine("Oink");
        }
    }

}

namespace TheFeud.McDroid
{

    public class Cow
    {
        public void Sound()
        {
            Console.WriteLine("Moo");
        }
    }

    public class Pig
    {
        public void Sound()
        {
            Console.WriteLine("Oink");
        }
    }

    namespace TheFued.McDroid
    {
        public class Cow
        {
            public void Sound()
            {
                Console.WriteLine("Moo");
            }
        }

        public class Pig
        {
            public void Sound()
            {
                Console.WriteLine("Oink");
            }
        }
    }
    
}

