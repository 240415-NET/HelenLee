using System.Data.SqlClient;
using TripManager.Models;

namespace TripManager.Data;

public class SqlTripStorage : ITripStorageRepo
{
    public static string connectionString = File.ReadAllText(
        @"C:\.NET Bootcamp\240415 .NET\connstring.txt"
    );

    public void StoreTrip(Trip newTrip)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText =
            @"INSERT INTO dbo.Trips (tripId, userId, destination, description, tripType,
                                    startDate, endDate, cost)
                            VALUES (@tripId, @userId, @destination, @description, @tripType,
                                    @startDate, @endDate, @cost);";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        cmd.Parameters.AddWithValue("@tripId", newTrip.tripId);
        cmd.Parameters.AddWithValue("@userId", newTrip.userId);
        cmd.Parameters.AddWithValue("@destination", newTrip.destination);
        cmd.Parameters.AddWithValue("@description", newTrip.description);
        cmd.Parameters.AddWithValue("@tripType", newTrip.tripType);
        cmd.Parameters.AddWithValue("@startDate", newTrip.startDate);
        cmd.Parameters.AddWithValue("@endDate", newTrip.endDate);
        cmd.Parameters.AddWithValue("@cost", newTrip.cost);

        cmd.ExecuteNonQuery();

        connection.Close();
    }

    public List<Trip> GetTripsByUserId(User user)
    {
        List<Trip> returnedTripsList = new();

        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            string cmdText =
                @"SELECT tripId, userId, destination, description, tripType,
                                    startDate, endDate, cost
                                FROM dbo.Trips
                                WHERE userId = @userToFind;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@userToFind", user.userId);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Trip returnedTrip = new();

                returnedTrip.tripId = reader.GetGuid(0);
                returnedTrip.userId = reader.GetGuid(1);
                returnedTrip.destination = reader.GetString(2);
                returnedTrip.description = reader.GetString(3);
                returnedTrip.tripType = reader.GetString(4);
                returnedTrip.startDate = reader.GetDateTime(5);
                returnedTrip.endDate = reader.GetDateTime(6);
                returnedTrip.cost = reader.GetDecimal(7);

                returnedTripsList.Add(returnedTrip);
            }

            connection.Close();

            if (returnedTripsList.Count == 0)
            {
                return null;
            }

            return returnedTripsList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
        return null;
    }

    public void UpdateTrip(Trip updatedTrip)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            string cmdText =
                            @"UPDATE dbo.Trips 
                                SET 
                                     destination = @newdestination,
                                     description = @description,
                                     tripType = @tripType,
                                     startDate = @startDate,
                                     endDate = @endDate,
                                     cost = @cost
                                WHERE tripId = @tripId;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@tripId", updatedTrip.tripId);
            cmd.Parameters.AddWithValue("@newdestination", updatedTrip.destination);
            cmd.Parameters.AddWithValue("@description", updatedTrip.description);
            cmd.Parameters.AddWithValue("@tripType", updatedTrip.tripType);
            cmd.Parameters.AddWithValue("@startDate", updatedTrip.startDate);
            cmd.Parameters.AddWithValue("@endDate", updatedTrip.endDate);
            cmd.Parameters.AddWithValue("@cost", updatedTrip.cost);

            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace.ToString());
        }
        finally
        {
            connection.Close();
        }
    }

    public void DeleteTrip(Trip deleteTrip)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            string cmdText = @"DELETE FROM dbo.Trips WHERE tripId = @deleteTripId";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            {
                cmd.Parameters.AddWithValue("@deleteTripId", deleteTrip.tripId);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    
}
