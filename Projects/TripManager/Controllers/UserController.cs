using TripManager.Data;
using TripManager.Models;

namespace TripManager.Controllers;

public class UserController
{
    private static IUserStorageRepo _userData = new SqlUserStorage(); //JsonUserStorage();
                                                    

    public static void CreateUser(string userName)
    {
        User newUser = new User(userName);

        _userData.StoreUser(newUser);
    }

    public static bool UserExists(string userName)
    {
        if (_userData.FindUser(userName) != null)
        {
            return true;
        }

        return false;
    }

    public static User ReturnUser(string userName)
    {
        User existingUser = _userData.FindUser(userName);
        return existingUser;
    }
}
