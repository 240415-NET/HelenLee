namespace IntroClassPD;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Dog pancake = new Dog ();

        //We are calling an instance method - this method needs an object of type dog to be called.
        pancake.Bark();
        
        Dog.DefineDog();
    }
}