namespace IntroClassPD;

public class Dog
{
    //Fields
    public string name { get; set; } 

    public string breed { get; set; } 

    public int age  
    { 
        get{return age;}
        set{ age = value;} 

    }

    public string gender { get; set; } 

    public double weight { get; set; } 


    //Methods
    //Instance Method - called via dot notation from an instance of the class
    public void Bark()
    {
        Console.WriteLine($"{name}: bark bark!");
    }

    //Static method- we call it by referencing the class itself, not an object of that class
    public static void DefineDog()
    {
        Console.WriteLine(@"Definition of 
        Dog");
    }
}