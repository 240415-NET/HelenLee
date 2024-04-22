namespace StringArray;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine ("Hello");
        
        string[] groceryList = new string[5];

        Console.WriteLine("Lets make a grocery list");  

        for (int i = 0; i < groceryList.Length; i++)
        {
            Console.WriteLine($"Enter item {i + 1}: ");
            groceryList[i] = Console.ReadLine();
        }
       
       //Console.WriteLine ("This is your grocery list so far:");

    
    }
}