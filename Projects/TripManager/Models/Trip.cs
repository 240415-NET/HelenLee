namespace TripManager.Models;

public class Trip
{
    public Guid tripId { get; set; }
    public Guid userId {get; set;}
    public string destination { get; set; }
    public string description { get; set; }
    public string tripType { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public decimal cost { get; set; }

    //Constructor
    public Trip() { }

    public Trip(
        Guid _userId,
        string _destination,
        string _description,
        string _tripType,
        DateTime _startDate,
        DateTime _endDate,
        decimal _cost
    )
    {
        userId = _userId;
        tripId = Guid.NewGuid();
        destination = _destination;
        description = _description;
        tripType = _tripType;
        startDate = _startDate;
        endDate = _endDate;
        cost = _cost;
    }
}
