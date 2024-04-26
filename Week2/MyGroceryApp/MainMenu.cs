using System;
using System.Collections.Generic;

namespace MyGroceryApp
{
    class Program
    {

        public static void Main(string[] args)
        {
                GroceryApp app = new GroceryApp();

                int choice = 0;
                while( choice != 4 )
                {
                    
                    Console.WriteLine("\nMain Menu");
                    Console.WriteLine("1. Create your Grocery List!");
                    Console.WriteLine("2. Add to the List ");
                    Console.WriteLine("3. Categorize Items");
                    Console.WriteLine("4. Exit ");
                    Console.WriteLine("\nEnter your choice: ");

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid input. Please enter a number." );
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            app.CreateGroceryList();
                            break;
                        case 2:
                            app.AddToList();
                            break;
                        case 3:
                            app.CategorizeItem();
                            break;
                        case 4:
                            Console.WriteLine("Bye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please select another option");
                            break;
                    }

                }
        
            }
    
    }
}