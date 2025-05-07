/*

Title: The Repeating Stream 

Story: 

In Threadia, there is a stream that generates numbers once a second.
The numbers are randomly generated between numbers 0-9.
Occasionally the stream generates the same number in a row. 
A repeat number like this is signifcant, an omen of good things to come. 
Unfortunately since the Uncoded one has arrived Threadians haven't been able to monitor the stream while numbers are generated.
Either the stream generates numbers while no one watches, or they watch while the stream generates no new numbers.
The Threadians offer you the Medallion of threads willingly if you can make both possible at the same time. 
Build a program to randomly generate numbers while also allowing some to flag a repeated number. 


Objectives:

- Make a RecentNumbers class that holds at least the two most recent numbers

- Make a method that loops forever generating random numbers from 0-9 once a second. 
    => Hint: Thread.Sleep can help you 

- Write the numbers to the console window, put the generated numbers in a RecentNumbers object, and update it as new numbers are generated.

- Make a thread that runs the above method. 

- Wait for a user to push a key in a second loop ( on the main thread or another new thread ).
    => When the user presses a key, check if the last two numbers are the same. 
        ==> If they match, tell the user that they correctly identified the repeat.
        ==> If they don't, indicate that they got it wrong  

- Use lock statements to ensure that they only thread accesses the shared data at a time.  
 
*/