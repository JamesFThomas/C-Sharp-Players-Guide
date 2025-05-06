/*

Title: The three Lenses

Story: 

The Guardian of the Medallion of Queries, Lennik has long awaited when he can return the medallion to a worthy programmer.    
But he only wants to give to someone who truly understands the value of queries. 
He requires you to build a solution to a simple problem three times over. 
Lennik gives you the following array of positive numbers [1,9,2,8,3,7,4,6,5].
He asks you to make a new collection form this data where: 

- All the odd numbers are filtered out and only the even numbers should be considered

- The numbers are in order

- The numbers are doubled

For example, with the array above:

- filtered for evens should in [2,8,4,6]

- The ordering step would result in [2,4,6,8]

- The doubling step should result in [4,8,12,16]



Objectives:

- Write a method that will take int[] as an input and produce an IEnumerable<int> (it could be a list or array if you want) that meets all three of the conditions above using only procedural code - if statements, switches and loops.
    --> Hint: the static Array.Sort method might be a useful tool here. 

- Write a method that will take int[] as an input and produce an IEnumerable<int> that meets all three of the conditions above using keyword-based query expressions ( from x, where x, select x etc. ) 

- Write a method that will take int[] as an input and produce an IEnumerable<int> that meets all three of the conditions above using method-call-based query expression ( x.Select(n => n + 1 ), x.where( n => n < 0), etc )

- Run all three methods and display the results to ensure the produce the correct answers

- Answer this question: Compare the size and understandability of these three approaches. Do any stand out as being particularly good or good to you? 
    =>

- Answer this question: Of these three approaches which is you personal favorite and why? 
    => I think that I like the query method syntax the most because it is the cleanest and it compartmentalizes everything in each method 

 
*/



int[] nums = [15, 1, 12, 9, 2, 8, 13, 3, 7, 6, 4, 14, 5, 11, 0];

IEnumerable<int> pro = DoneWithProceduralCode(nums);

IEnumerable<int> keyword = DoneWithKeywordExpressions(nums);

IEnumerable<int> meth = DoneWithMethodExpressions(nums);

var proList = pro.ToList();

var keyList = keyword.ToList();

var methList = meth.ToList();

for (int i = 0; i < pro.Count(); i++)
{

    Console.WriteLine(proList[i]);

    Console.WriteLine(keyList[i]);

    Console.WriteLine(methList[i]);;
}




static IEnumerable<int> DoneWithProceduralCode(int[] numbers)
{
    
    List<int> result = new List<int>(); 

    
    foreach (int number in numbers) 
    {
        if (number % 2 == 0) 
            result.Add(number);
    }

    
    result.Sort(); 

    
    for (int i = 0; i < result.Count; i++)
    {
        result[i] *= 2; 
    }

    return result;
}

static IEnumerable<int> DoneWithKeywordExpressions(int[] numbers)
{


    IEnumerable<int> result = from num in numbers
                              where num % 2 == 0 
                              orderby num ascending 
                              select num * 2; 

    return result;
}

static IEnumerable<int> DoneWithMethodExpressions(int[] numbers)
{ 
    IEnumerable<int> result = numbers
                                .Where(num => num % 2 == 0)
                                .OrderBy(num => num)
                               .Select(num => num * 2);

    return result;
}