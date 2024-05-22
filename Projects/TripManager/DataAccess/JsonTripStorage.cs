

using System.Text.Json;
using TripManager.Models;

namespace TripManager.Data;

public class JsonTripStorage : ITripStorageRepo
{
    public static string filePath = "Trip.json";

    public void StoreTrip(Trip newTrip)
    {
        if (File.Exists(filePath))
        {
            string existingTripsJson = File.ReadAllText(filePath);
            List<Trip> existingTripsList = JsonSerializer.Deserialize<List<Trip>>(existingTripsJson);
            existingTripsList.Add(newTrip);
            string jsonExistingTripsListString = JsonSerializer.Serialize(existingTripsList);
            File.WriteAllText(filePath, jsonExistingTripsListString);
        }
        else if (!File.Exists(filePath))
        {
            List<Trip> initialTripsList = new List<Trip>();
            initialTripsList.Add(newTrip);
            string jsonTripsListString = JsonSerializer.Serialize(initialTripsList);
            File.WriteAllText(filePath, jsonTripsListString);
        }
    }

    public List<Trip> GetTripsByUserId(User user)
    {
        List<Trip> trips = new();

        string existingTripsJson = File.ReadAllText(filePath);

        //Deserialize JSON and save to allTripsList
        List<Trip> allTripsList = JsonSerializer.Deserialize<List<Trip>>(existingTripsJson);

        //Filters the 'allTripsList' to include trips where userId matches the userId of user object
        //Then converts filtered results into a list via To.List()
        trips = allTripsList.Where(trip => trip.userId == user.userId).ToList();

        return trips;
    }

    
    public List<Trip> LoadTrips()
    {
        if (!File.Exists(filePath))
        {
            return new List<Trip>();
        }

        string allTrips = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Trip>>(allTrips);
    }

    public void SaveTrips (List<Trip> trips)
    {
        string saveTripList = JsonSerializer.Serialize(trips);
        File.WriteAllText(filePath, saveTripList);
    }

    
}
