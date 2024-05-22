namespace TripManager.Models;


public interface ITripStorageRepo
{
    public void StoreTrip(Trip newTrip);

    public List<Trip> GetTripsByUserId (User user);

    public List<Trip> LoadTrips();

    public void SaveTrips (List<Trip> trips);
  

}