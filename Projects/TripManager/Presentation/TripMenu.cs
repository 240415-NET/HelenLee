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
                        Console.Clear();
                        TripMenu.NewTrip(user);
                        break;

                    case "2":
                       Console.Clear();
                        TripMenu.DisplayTrips(user);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine($"Select the trip number you would like to update, {user.userName}");
                        TripMenu.UpdateTripMenu(user);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine($"Select the trip number you would like to delete, {user.userName}");
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

    //DisplayTrips for UPDATE and DELETE
    public static Trip DisplayTripsToModify(User user)
    {
        bool validInput = false;

        do
        {
            try
            {
               
                List<Trip> trips = TripController.ViewExistingTrip(user);

                if (trips.Count == 0)
                {
                    Console.WriteLine("No trips found for this user");
                }

                int counter = 1;

                foreach (Trip trip in trips)
                {
                    Console.WriteLine( $"{counter}. {trip.description} to {trip.destination} from {trip.startDate} to {trip.endDate}");
                    counter++;
                }
                
                int userInput = Convert.ToInt32(Console.ReadLine());

                //Returns the index of the list depending on what user selects
            
                int index = userInput - 1;

                return trips[index];

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
        
        return null;
    }
    
    //Method for displaying all trips
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

                foreach (Trip trip in trips)
                {
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

     public static void DeleteTripView(User user)
    {
       
        List<Trip> allTripsByUser= TripController.ViewExistingTrip(user);
        List<Trip> updateTripList = new();

        Trip deleteTrip = DisplayTripsToModify(user);
        TripController.DeleteTrip(deleteTrip);

        Console.WriteLine("Trip successfully deleted");
        Console.ReadKey();
        TripMenu.MainTripMenu(user);

    }


    public static void UpdateTripMenu(User user)
    {
        Trip tripToUpdate = DisplayTripsToModify(user);
        UpdateEachTripDisplay(tripToUpdate, user);
    }

     public static void UpdateEachTripDisplay(Trip tripToUpdate, User user)
    {
        bool keepModifying = true;
        bool isValid = false;

        Trip updatedTrip = new Trip();

        updatedTrip.tripId = tripToUpdate.tripId;
        updatedTrip.destination = tripToUpdate.destination;
        updatedTrip.description = tripToUpdate.description;
        updatedTrip.tripType = tripToUpdate.tripType;
        updatedTrip.startDate = tripToUpdate.startDate;
        updatedTrip.endDate = tripToUpdate.endDate;
        updatedTrip.cost = tripToUpdate.cost;


        do
        {
            Console.Clear();
            Console.WriteLine("Which would you like to update? \n");
            Console.WriteLine($"Destination: {updatedTrip.destination}");
            Console.WriteLine($"Description: {updatedTrip.description}");
            Console.WriteLine($"Trip Type: {updatedTrip.tripType}");
            Console.WriteLine($"Start Date: {updatedTrip.startDate}");
            Console.WriteLine($"End Date: {updatedTrip.endDate}");
            Console.WriteLine($"Cost: {updatedTrip.cost}");
            Console.WriteLine("\nWhen you're done updating your trip, enter 'bye'!");
            
            try
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "destination":
                        {
                            Console.WriteLine("Enter the new destination: ");
                            string updatedValue = Console.ReadLine() ?? "";
                            updatedTrip.destination = updatedValue;
                            isValid = true;
                            break;
                        }
                    case "description":
                        {
                            Console.WriteLine("Enter the new description: ");
                            string updatedValue = Console.ReadLine() ?? "";
                            updatedTrip.description = updatedValue;
                            isValid = true;
                            break;
                        }
                    case "trip type":
                        {
                            Console.WriteLine("Enter the new trip type:  ");
                            string updatedValue = Console.ReadLine() ?? "";
                            updatedTrip.tripType = updatedValue;
                            isValid = true;
                            break;
                        }
                    case "start date":
                        {
                            Console.WriteLine("Enter the new start date of the trip: ");
                            DateTime updatedValue = DateTime.Parse(Console.ReadLine().Trim());
                            updatedTrip.startDate = updatedValue;
                            isValid = true;
                            break;
                        }
                    case "end date":
                        {
                            Console.WriteLine("Enter the new end date of the trip: ");
                            DateTime updatedValue = DateTime.Parse(Console.ReadLine().Trim());
                            updatedTrip.endDate = updatedValue;
                            isValid = true;
                            break;
                        }

                    case "cost":
                        {
                            Console.WriteLine("Enter the new cost (without $): ");
                            decimal updatedValue = decimal.Parse(Console.ReadLine() ?? "");
                            updatedTrip.cost = updatedValue;
                            isValid = true;
                            break;
                        }
            
                    case "bye":
                        {
                            keepModifying = false;
                            isValid = true;
                            break;
                        }
                    default:
                        {
                            isValid = false;
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please input a valid value \n");
            }
        }
        while (keepModifying || !isValid);

        TripController.UpdateTrip(updatedTrip);
        
    }



}
 

