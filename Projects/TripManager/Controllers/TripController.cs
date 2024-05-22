using System.Diagnostics.Contracts;
using TripManager.Data;
using TripManager.Models;

namespace TripManager.Controllers;

public class TripController
{
    private static ITripStorageRepo _tripData = new SqlTripStorage(); // JsonTripStorage();
                                                

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

    public static void UpdateTrip(Trip updatedTrip)
    {
        _tripData.UpdateTrip(updatedTrip);
    }

    public static void DeleteTrip(Trip deleteTrip)
    {
        _tripData.DeleteTrip(deleteTrip);
    }


}
