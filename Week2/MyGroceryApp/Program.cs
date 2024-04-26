
using System;
using System.Collections.Generic;

namespace MyGroceryApp
{
        public class Food
        {
            public string Name { get; set; }
            
            public Food (string name, string category)
            {
                Name = name;
              
            }
        }

        public class Snack : Food
        {
           
            public Snack (string name) : base (name, "Snack")
            {

            }            
        }

        public class Ingredient : Food
        {

            public Ingredient(string name) : base (name, "Ingredient")
            {

            }
        }

        public class GroceryApp
        {
            
            List<string> groceryList = new List<string>();
            List<string> newItemsList = new List<string>();
    

            public void CreateGroceryList()
            {
                Console.WriteLine("\nEnter an item to add to the grocery list (type 'done' to finish): ");
               
                string item;
                int itemNumber = 1;

                do
                {
                    Console.Write($"Enter item # {itemNumber}: ");
                    item = Console.ReadLine();

                    if (item.ToLower() != "done")
                    {
                        groceryList.Add(item);
                        itemNumber++;
                    }
                    else if (item.ToLower() == "done")
                    {   
                        Console.Clear();
                        Console.WriteLine("Here is the grocery list you've created:");
                        DisplayGroceryList();
                    }

                } while (item.ToLower() != "done");

                
            }


            public void DisplayGroceryList()
            {
                
                foreach (var item in groceryList)
                {
                    Console.WriteLine(item);
                }
            }

            public void AddToList ()
            {
                Console.WriteLine("\nEnter items to add to the existing grocery list (type 'done' to finish): ");
                
                string newItem;
                int itemNumber = 1;

                do
                {
                    Console.Write($"Enter item # {itemNumber}: ");
                    newItem = Console.ReadLine();

                    if (newItem.ToLower() != "done")
                    {
                        groceryList.Add(newItem);
                        itemNumber++;
                    }
                 
                } while (newItem.ToLower() != "done");

                groceryList.AddRange(newItemsList);
                Console.WriteLine("\nHere is your newly updated list!");
                DisplayGroceryList();
            }

    
            public class CategorizedFood
            {
                public string Name {get; set;}
                public string Category {get; set;}

                public CategorizedFood(string name, string category)
                {
                    Name= name;
                    Category = category;
                }

                public override string ToString()
                {
                    return $"{Name} - {Category}";
                }

            }

        
            public void CategorizeItem()
            {
                    //Initializes a new list "categorizedItems" to store instances of "CategorizedFood"
                    List<CategorizedFood> categorizedItems = new List<CategorizedFood>();

                    foreach (string item in groceryList)
                    {
                        if (IsSnack(item))
                        {
                            categorizedItems.Add(new CategorizedFood(item, "Snack"));
                        }
                        else if (IsIngredient(item))
                        {
                            categorizedItems.Add(new CategorizedFood(item, "Ingredient"));

                        }
                        else
                        {
                            categorizedItems.Add(new CategorizedFood(item, "Other"));
                        }


                    }

                    Console.WriteLine("\nCategorized Items: ");
                    foreach (var item in categorizedItems)
                    {
                        Console.WriteLine(item);
                    }
            }

            //Helper methods 
            private bool IsSnack(string item)
            {
                string[] snackKeyWords = {"candy", "cookies", "yogurt", "string cheese", "donuts"};
                foreach (string keyword in snackKeyWords)
                {
                    if (item.ToLower().Contains(keyword))
                    {
                        return true;
                    }
                    
                }
                return false;
            }

            private bool IsIngredient(string item)
            {
                string[] IngredientKeyWords = {"pasta", "rice", "flour", "chicken", "tomato sauce"};
                foreach (string keyword in IngredientKeyWords)
                {
                    if (item.ToLower().Contains(keyword))
                    {
                        return true;
                    }
                   
                }
            return false;

            }


} 

}