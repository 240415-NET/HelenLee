/*
In this Hackathon we want to create a C# console application with the following requirments.

1 - Prompts the user for multiple values
2 - Save the values to an Array
3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
4 - Manage and update the values for the array using inputs from the User
5 - Continues to run until the user quits the application, from within the application (no ctrl+c)

The goal of this application is to create, manipulate and modify an array of a consistent data types.

An potential example you can use is a grocery list, that a user can add items to, and then update if they have bought it or not.

*/
using System;
using System.Collections.Generic;

namespace StringArray;

class Program
{
    static void Main(string[] args)
    { 
       bool caught = false;

       try
       {
                bool done = false;
                while (done==false)
                {
                Console.WriteLine("Enter 1 to create a grocery list.");
                Console.WriteLine("Enter 2 to update the grocery list.");
                Console.WriteLine("Enter 3 to exit the program.");

                int optionResponse = Convert.ToInt32(Console.ReadLine());

                if (optionResponse == 1)
                {
                   // bool done = false;
                    string[] groceryList= new string[4];

                    Console.WriteLine("Lets make a grocery list!");  

                   

                        for (int i = 0; i < groceryList.Length; i++)
                        {
                            Console.WriteLine($"Enter item {i + 1}: ");
                            groceryList[i] = Console.ReadLine();
                        }

                        Console.Clear();
                        Console.WriteLine ("This is your grocery list so far: ");

                        foreach (string i in groceryList)
                        {
                            Console.WriteLine(i);
                        }

                    
                }
                else if (optionResponse == 2)
                {
                    Console.WriteLine("You've opted to update the list.");

                }
                else if (optionResponse == 3)
                {
                    Environment.Exit(0);
                    done = true;
                    //Console.WriteLine("Bye!");
                   
                }
                else 
                {
                    Console.WriteLine("Please enter a valid response!");
                }
            }
        }


        catch (Exception MyException)
        {
            Console.WriteLine($"{MyException.Message}");
            Console.WriteLine($"{MyException.StackTrace}");
            Console.WriteLine("Please enter a valid input");

            caught = true;
        }
     }
}