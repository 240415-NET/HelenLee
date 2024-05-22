using System.Data.SqlClient;
using TripManager.Models;

namespace TripManager.Data;

public class SqlUserStorage : IUserStorageRepo
{
    public static string connectionString = File.ReadAllText(
        @"C:\.NET Bootcamp\240415 .NET\connstring.txt"
    );

    public void StoreUser(User user)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText =
            @"INSERT INTO dbo.Users (userId, userName)
                            VALUES (@userId, @userName);";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        cmd.Parameters.AddWithValue("@userId", user.userId);
        cmd.Parameters.AddWithValue("@userName", user.userName);

        cmd.ExecuteNonQuery();

        connection.Close();
    }

    public User FindUser(string usernameToFind)
    {
        User foundUser = new User();

        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            string cmdText =
                @"SELECT userId, userName
                                FROM dbo.Users
                                WHERE userName = @userToFind;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@userToFind", usernameToFind);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                foundUser.userId = reader.GetGuid(0);
                foundUser.userName = reader.GetString(1);
            }

            connection.Close();

            // if (String.IsNullOrEmpty(foundUser.userName))
            if (foundUser.userId == Guid.Empty)
            {
                return null;
            }

            return foundUser;
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
}


