namespace SundayPractice;

class Program
{
    /*
    static void Main(string[] args)
    {
        
        List<string> storeList = new List <string>{"Kroger", "Publix", "Whole Foods"};
        string selectedStore;

        Console.WriteLine("Pick a store: ");

        for (int i=0; i < storeList.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {storeList[i]}");
        }

        string storeLocation = Console.ReadLine();
        int storeNumber = Convert.ToInt32(storeLocation);  

        selectedStore = storeList[storeNumber - 1];
        Console.WriteLine ($"Your selected store is: {selectedStore}");

        bool exitLoop = false;
        do
        {

        } while ()
    }



    static void Main(string[] args)
    {
        //int X = int.Parse(Console.ReadLine());
        //int y = int.Parse(Console.ReadLine());

        // Write an answer using Console.eLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        int[] treesPlanted = new int[3];

        Console.WriteLine("Enter number of tree planted: ");

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Class {i + 1}: ");
            treesPlanted[i] = int.Parse(Console.ReadLine());
        }
Writ
        int totalTrees = 0;
        foreach (int tree in treesPlanted)2
        {
            totalTrees+=tree;
        }

        Console.WriteLine($"The total trees planted by all the classes are {totalTrees}");
    }

      //Practice 

      static void Main(string[] args)
    {

        List <int> newList = new List<int>();
        double sum = 0;
        int size;
        

        Console.WriteLine("Enter size of list: ");
        size = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Enter #{i+1}: ");
            newList.Add(int.Parse(Console.ReadLine()));
        }


        //foreach (int number in newList)
        //{
        //    sum = sum + number;
        //}

        for (int c = 0; c < newList.Count; c++)
        {
            sum = sum + newList[c];
        }

        double avg = sum/size;

        Console.WriteLine($"Here's your avg: {avg}");
    }

*/
    static void Main(string[] args)
    {
        List <int> gradesList = new List<int>();
        double sum = 0;
        int numOfStudents;
        int passed = 0;
        int failed = 0;

        Console.WriteLine("Enter number of students in class: ");
        numOfStudents = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfStudents; i++)
        {
            Console.WriteLine($"Enter grade #{i+1}: ");
            gradesList.Add(int.Parse(Console.ReadLine()));
        }


        //foreach (int number in newList)
        //{
        //    sum = sum + number;
        //}

        for (int c = 0; c < gradesList.Count; c++)
        {
            sum = sum + gradesList[c];
        }

        double avg = sum/numOfStudents;

        for (int i = 0; i < gradesList.Count; i++)
        {
            if (gradesList[i] >= 60)
            {
                passed += 1;
            }
            else
            {
                failed +=1;
            }
        }

        Console.WriteLine($"Here's the average of your class: {avg}");
        Console.WriteLine($"Failed:{failed}/ Passed:{passed}");

    }

}
