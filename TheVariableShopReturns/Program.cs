/*
 
 Objectives: 
    - Assing all VariableShop variables a new type
    - Do NOT declare new variables 
    - Use Console.Writelines to display the updated content of each variable. 
 
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


// reassign all variable to new literrals 
aChar = '\u0078';
sString = "A different string";
aByte = 12;
aShort = 25_000;
aInt = -1_324_777;
aLong = 2_786_000_111_456;
aSByte = 78;
aUShort = 5_535;
aUint = 1_999_999; 
aULong = 744_073_709_551_615;
aFloat = -24e8F;
aDouble = 12387e23;
aDecimal = 498e12m;
aBoolean = false;


// Update the array with the new values
typesArray = new object[] { aChar, sString, aByte, aShort, aInt, aLong, aSByte, aUShort, aUint, aULong, aFloat, aDouble, aDecimal, aBoolean };


// Iterate through array after reassignments  
foreach (var element in typesArray)
{
    // log value at each index
    Console.WriteLine(element);

}


