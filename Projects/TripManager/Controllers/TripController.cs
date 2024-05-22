using System.Diagnostics.Contracts;
using TripManager.Data;
using TripManager.Models;

namespace TripManager.Controllers;

public class TripController
{
    private static ITripStorageRepo _tripData = new JsonTripStorage(); //SqlTripStorage();
                                                

    public static void CreateTrip(
        User user,
        string destination,
        string description,
        string tripType,
        DateTime startDate,
        DateTime endDate,
        decimal cost
    )
    {
        Trip newTrip = new Trip(
            user.userId,
            destination,
            description,
            tripType,
            startDate,
            endDate,
            cost
        );

        _tripData.StoreTrip(newTrip);
    }

    public static List<Trip> ViewExistingTrip(User user)
    {
        return _tripData.GetTripsByUserId(user);
    }

    
    public static bool DeleteTrips(User user, string destination)
    {
        try
        {
        var userTrips = _tripData.GetTripsByUserId(user);

        Trip tripToDelete = userTrips.FirstOrDefault (trip => trip.destination == destination);
        Console.WriteLine (tripToDelete.description);

 /*
        if (tripToDelete != null)
        {
            List<Trip> allTrips = _tripData.LoadTrips();
            if (allTrips.Contains(tripToDelete))
            {
                Console.WriteLine("contains it");
            }
            else 
                Console.WriteLine("Nope");

            allTrips.Remove(tripToDelete);
            _tripData.SaveTrips(allTrips);

            return true;
        }

*/
         
        List<Trip> allTrips = _tripData.LoadTrips();
        for (int i = 0; i < allTrips.Count - 1; i++)
        {
            if (allTrips[i].destination == destination)
            {
                allTrips.RemoveAt(i);
                break;
            }
        }

        /*foreach (Trip trip in allTrips)
        {
            Console.WriteLine(trip);
        }
        */
        _tripData.SaveTrips(allTrips);
        return true;
        
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace.ToString());
        }
        return false;
    }
    
    
   
}
