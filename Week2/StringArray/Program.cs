﻿/*
In this Hackathon we want to create a C# console application with the following requirments.

1 - Prompts the user for multiple values
2 - Save the values to an Array
3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
4 - Manage and update the values for the array using inputs from the User
5 - Continues to run until the user quits the application, from within the application (no ctrl+c)

The goal of this application is to create, manipulate and modify an array of a consistent data types.

An potential example you can use is a grocery list, that a user can add items to, and then update if they have bought it or not.

*/
using System.Collections.Generic;

namespace StringArray;

class Program
{
    static void Main(string[] args)
    { 
        bool caught = false;
        string[] groceryList= new string[4];
        string [] addedList = new string [4];
        List <string> checkedList = new List<string>();

       try
       {
                bool done = false;
                while (done==false)
                {
                    Console.WriteLine("Welcome to the Main Menu!");
                    Console.WriteLine("Enter 1 to create a grocery list.");
                    Console.WriteLine("Enter 2 to update the grocery list.");
                    Console.WriteLine("Enter 3 to exit the program.");

                    int optionResponse = Convert.ToInt32(Console.ReadLine());

                    if (optionResponse == 1)
                    {

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

                            Console.WriteLine("---------------------------------");
                    }
                    
                    else if (optionResponse == 2)
                    {
                        
                        Console.WriteLine("You've opted to update the list. Enter 'add' to add to the list and 'check off' to cross off items bought");
                        string userResponse2 = Console.ReadLine().Trim().ToLower();

                        if (userResponse2 == "add")
                        {
                            
                            for (int i = 0; i < addedList.Length; i++)
                            {
                                Console.WriteLine($"Enter new item #{i + 1}");
                                addedList[i] = Console.ReadLine();
                            }

                            Console.Clear();

                            for (int a = 0; a < groceryList.Length ; a++)
                            {
                                //groceryList[a] += addedList[a];
                                groceryList[a] = groceryList[a] + " " + addedList[a];
                            }
                            
                            Console.Clear();
                            Console.WriteLine("Here is your new combined list:");
                            
                            foreach (string str in groceryList)
                            {
                                Console.WriteLine(str);
                            }

                           Console.WriteLine("---------------------------------");
                        }
                        
                        else if ( userResponse2 == "check off")
                        {

                            /*
                            string [] checkedArray = new string[groceryList.Length];
                            
                            for (int i = 0; i < groceryList.Length; i++)
                            {
                                Console.WriteLine($"Enter item #{i + 1} to check off");
                                string itemToRemove = Console.ReadLine();

                                if (string.TryParse(itemToRemove, out string validItem))
                                {
                                    checkedList.Add(validItem);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid string");
                                    i++;
                                }
                            }

                            Console.Clear();

                            for (int a = 3; a < groceryList.Length ; a--)
                            {
                                //groceryList[a] += addedList[a];
                                groceryList[a] = groceryList[a] - addedList[a];
                            }
                            
                            Console.Clear();
                            Console.WriteLine("Here is your new checked off list:");
                            
                            foreach (string str in groceryList)
                            {
                                Console.WriteLine(str);
                            }

                            */
                           Console.WriteLine("---------------------------------");
                        }
                        
                        else
                        {
                            Console.WriteLine("Try again");
                        }

                    }

                    else if (optionResponse == 3)
                    {
                        Console.WriteLine("Bye!");
                        Environment.Exit(0);
                        done = true;
                    
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

