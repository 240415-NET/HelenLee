using System;

class Car
{
    public string Make { get; set; }
    public string Model { get; set; }

    public Car(string make, string model)
    {
        Make = make;
        Model = model;
    }

    public virtual void StartEngine()
    {
        Console.WriteLine("Engine started normally.");
    }

    public void Accelerate()
    {
        Console.WriteLine("Accelerating at normal speed.");
    }

    public void Accelerate(int speed)
    {
        Console.WriteLine($"Accelerating at {speed} mph.");
    }
}

class ElectricCar : Car
{
    public int BatteryCapacity { get; set; }
    public int RangePerCharge { get; set; }

    public ElectricCar(string make, string model, int batteryCapacity, int rangePerCharge)
        : base(make, model)
    {
        BatteryCapacity = batteryCapacity;
        RangePerCharge = rangePerCharge;
    }

    public override void StartEngine()
    {
        Console.WriteLine("Electric motor started silently.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of ElectricCar with additional parameters
        ElectricCar myElectricCar = new ElectricCar("Tesla", "Model 3", 75, 300);

        // Access properties of ElectricCar
        Console.WriteLine($"Battery Capacity: {myElectricCar.BatteryCapacity} kWh");
        Console.WriteLine($"Range Per Charge: {myElectricCar.RangePerCharge} miles");

        // Invoke methods of ElectricCar
        myElectricCar.StartEngine(); // Outputs: "Electric motor started silently."
        myElectricCar.Accelerate(); // Outputs: "Accelerating at normal speed."
        myElectricCar.Accelerate(70); // Outputs: "Accelerating at 70 mph."
    }
}
