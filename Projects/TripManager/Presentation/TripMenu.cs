using TripManager.Controllers;
using TripManager.Models;

namespace TripManager.Presentation;

public class TripMenu
{
    public static void MainTripMenu(User user)
    {
        string userInput;
        bool validInput = false;

        Console.Clear();

        Console.WriteLine("Please enter the number option you would like to select: ");
        Console.WriteLine("1. Create new trip");
        Console.WriteLine("2. View existing trip");
        Console.WriteLine("3. Update existing trip");
        Console.WriteLine("4. Delete trip");
        Console.WriteLine("5. Exit");

        try
        {
            do
            {
                userInput = Console.ReadLine().Trim();
                switch (userInput)
                {
                    case "1":
                        //Console.WriteLine("You've selected to create a new trip!");
                        Console.Clear();
                        TripMenu.NewTrip(user);
                        break;

                    case "2":
                       Console.Clear();
                        TripMenu.DisplayTrips(user);
                        break;

                    case "3":
                        Console.WriteLine("You've selected to update an existing trip");
                        break;

                    case "4":
                        Console.WriteLine("You've selected to delete a trip");
                        
                        TripMenu.DeleteTripView(user);
                        break;

                    case "5":
                        Console.WriteLine("Bye!");
                        validInput = true;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            } while (validInput == false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void NewTrip(User user)
    {
        string destination;
        string description;
        string tripType;
        DateTime startDate;
        DateTime endDate;
        decimal cost;

        bool validInput = false;

        do
        {
            try
            {
                Console.WriteLine("Let's create your new trip!");
                Console.WriteLine("Where is the destination?");
                destination = Console.ReadLine().Trim();
                Console.WriteLine("Can you provide a description?");
                description = Console.ReadLine().Trim();
                Console.WriteLine("Is it an individual or group trip?");
                tripType = Console.ReadLine().Trim();
                Console.WriteLine("When's the trip starting? ex. 10/14/2024");
                startDate = DateTime.Parse(Console.ReadLine().Trim());
                Console.WriteLine("When will the trip end? ex. 10/24/2024");
                endDate = DateTime.Parse(Console.ReadLine().Trim());
                Console.WriteLine("How much will it cost? Just the number without $");
                cost = decimal.Parse(Console.ReadLine().Trim());

                validInput = true;
                TripController.CreateTrip(
                    user,
                    destination,
                    description,
                    tripType,
                    startDate,
                    endDate,
                    cost
                );

                TripMenu.MainTripMenu(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again with a valid input");
            }
        } while (validInput = false);
    }

    public static void DisplayTrips(User user)
    {
        bool validInput = false;

        do
        {
            try
            {
                Console.WriteLine($"Here are your existing trips, {user.userName}");

                List<Trip> trips = TripController.ViewExistingTrip(user);

                if (trips.Count == 0)
                {
                    Console.WriteLine("No trips found for this user");
                }

                int counter = 1;

                foreach (var trip in trips)
                {
                    //Console.WriteLine($"Trip ID: {trip.tripId}");
                    Console.WriteLine( $"{counter}. {trip.description} to {trip.destination} from {trip.startDate} to {trip.endDate}");
                    counter++;
                }
                
                 validInput = true;
                 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again with a valid input");
                validInput = false;
            }
        } while (validInput = false);

        Console.ReadKey();
        TripMenu.MainTripMenu(user);
    }
    
    
    
    public static User DeleteTripView(User user)
    {
        Console.WriteLine("Enter the Trip destination you want to delete: ");
        string destination = Console.ReadLine();

        bool isDeleted = TripController.DeleteTrips(user, destination);
       
        if (isDeleted)
        {
            Console.WriteLine($"{destination} was deleted successfully");
        }
        else
        {
            Console.WriteLine("Trip was not found");
        }
        
        return user;
        
    } 

 
}
