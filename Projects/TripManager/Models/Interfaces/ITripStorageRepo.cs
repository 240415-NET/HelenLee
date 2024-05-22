namespace TripManager.Models;


public interface ITripStorageRepo
{
    public void StoreTrip(Trip newTrip);

    public List<Trip> GetTripsByUserId (User user);
  
    public void DeleteTrip(Trip deleteTrip);

    public void UpdateTrip(Trip updatedTrip);
    
    
}