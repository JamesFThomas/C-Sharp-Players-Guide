

/*
 
 Objectives: 
    - Build a program with a variable of all fourteen fundamental types in C#.
    - Assing each of them a value using a literal of the the correct type.
    - Use Console.Writelines to display the content of each variable. 
 
 */

/* 1 */
char aChar = '\u0061';

/* 2 */
string sString = "a";

/* 3 */
byte aByte = 0;

/* 4 */
short aShort = 12_897;

/* 5 */
int aInt = 2_123_456;

/* 6 */
long aLong = -1_232_321_879_145;

/* 7 */
sbyte aSByte = -78;

/* 8 */
ushort aUShort = 65_535;

/* 9 */
uint aUint = 4_294_967_295;

/* 10 */
ulong aULong = 18_446_744_073_709_551_615;

/* 11 */
float aFloat = 24e12F;

/* 12 */
double aDouble = 24578e32;

/* 13 */
decimal aDecimal = 894e22m;

/* 14 */
bool aBoolean = true;

// created an array to hold all values 
object[] typesArray = { aChar, sString, aByte, aShort, aInt, aLong, aSByte, aUShort, aUint, aULong, aFloat, aDouble, aDecimal, aBoolean };

// Iterate through array 
foreach (var element in typesArray)
{
    // log value at each index
    Console.WriteLine(element);

}

