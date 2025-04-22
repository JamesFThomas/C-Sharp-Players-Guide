/*

Title: War Preparations 

Story: 

As you pass through the city of Roccard, two blacksmiths approach you. A confrontation with the Uncoded-One is coming soon, and we will need an army on our side.
The blacksmiths will forge enchanted swords to help villagers fight in the coming battle but need to power of a programmer to help them.
The blacksmiths begin to describe the type of program that they need form you to create all the swords for the army.



Objectives: 

- Swords can be made out of any of the following materials: 
  - wood
  - bronze
  - iron
  - steel
  - binarium - rare
    
    --> create an enumeration to represent the material types  

- Gemstones can be attached to a sword, which give them strange powers. 
  - Gemstone types include:
    - emerald
    - amber
    - sapphire
    - diamond
    - bitstone - rare
 
- Create a Sword record with a material, gemstone, length, and cross guard width.

- In your main program, create a basic Sword instance made out of iron and with no gemstone.    
    - Then create two variations on the basic sword using with expressions.

Display all three sword instances with code like Console.WriteLine(original).

*/

Sword originalSword = new Sword(Material.iron, Gemstone.none, 30, 6);

Sword swordWithGemstone = originalSword with {material = Material.binarium, gemstone = Gemstone.bitstone, length = 22};

Sword swordWithMaterial = originalSword with { material = Material.steel, gemstone = Gemstone.diamond, length = 40 };

Console.WriteLine(originalSword);
Console.WriteLine(swordWithGemstone);
Console.WriteLine(swordWithMaterial);


public record Sword( Material material, Gemstone gemstone, int length, int guardWidth)
{
    public Material Material { get; } = material;
    public Gemstone Gemstone { get; } = gemstone;
    public int Length { get; } = length;
    public int GuardWidth { get; } = guardWidth;

}


public enum Material
{
    wood,
    bronze,
    iron,
    steel,
    binarium
}

public enum Gemstone
{
    emerald,
    amber,
    sapphire,
    diamond,
    bitstone,
    none
}