/*
    Title: The Four Sisters and the Duckbear

    Objectives:
    
    - Create a program that lets the user enter the number of choclate eggs gathered that day. 

    - using the "/" division and "%" remainder oporators, compute how any eggs each sister should get and how many are left over for the duckbear.

    - Question?
        => What are the three total egg counts where the duckbear gets more than each sister does? 
            -- use the prgram you created to help you find the answer.
 
 */


// create a variable that represents the number of sisters 
int sisters = 4;

// create a variable to hold the total--ount of eggs for the day
int eggCount;

Console.WriteLine("How many chocolate eggs did the chickens lay today");

eggCount = Convert.ToInt32(Console.ReadLine());


// create a variable that will hold the computation result 

int eggsForSisters, eggsForDuckbear;


eggsForSisters = eggCount / sisters;

eggsForDuckbear = eggCount % sisters;

Console.WriteLine($"Today each sister get {eggsForSisters} eggs while the duckbear gets {eggsForSisters} eggs.");


// What are the three total egg counts where the duckbear gets more than each sister does? 
    // answer => 