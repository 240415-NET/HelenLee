using TripManager.Models;
using TripManager.Presentation;

namespace TripManager;

class Program
{
    static void Main(string[] args)
    {
        UserMenu.StartMenu();

        User myUser = new ("Jon");
        //SqlRepository.StoreUser(myUser);
    }
}
