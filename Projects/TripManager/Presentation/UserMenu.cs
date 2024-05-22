using TripManager.Controllers;
using TripManager.Models;

namespace TripManager.Presentation;

public class UserMenu
{
    public static void StartMenu() {

        int userChoice = 0;
        bool validInput = true;

        Console.Clear();
        Console.WriteLine("Welcome to the Trip Manager");
        Console.WriteLine("1. New user");
        Console.WriteLine("2. Returning user");
        Console.WriteLine("3. Exit program");
      
        do
        {
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1:
                        UserCreationMenu();
                        break;
                    case 2:
                        UserLoginMenu();
                        break;
                    case 3: 
                        return; 
                    default: 
                        Console.WriteLine("Please enter a valid choice (from the default)!");
                        validInput = false;
                        break;
                }

            }
            catch (Exception ex) 
            {   
                validInput = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter a valid choice! (from the catch)");
            }

        } while (!validInput);

    }

    
    public static void UserCreationMenu() 
    {
        bool validInput = true;
        string userInput = "";

        do
        {  
            Console.WriteLine("Please enter a username: ");
            userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }else if(UserController.UserExists(userInput))
            {
                Console.WriteLine("Username already exists, please choose another.");
                validInput = false;
            }else{ 
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created! Press any key to return to User Menu");
                validInput = true;
                Console.ReadKey();
                UserMenu.StartMenu();
            }

        } while (!validInput); 

    }


public static void UserLoginMenu() 
    {
        bool validInput = true;
        string userInput = "";

        do
        {   
            Console.WriteLine("Please enter a username: ");
            userInput = Console.ReadLine() ?? "";
            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }
            
            else if(!UserController.UserExists(userInput)) 
            {
                Console.WriteLine("Username doesn't exist, please choose another.");
                validInput = false;
            }

            else
            { 
                User existingUser = UserController.ReturnUser(userInput);
                Console.WriteLine("You're logged in!");
                Console.WriteLine($"Username: {existingUser.userName}");
                Console.WriteLine($"User Id: {existingUser.userId}");
                validInput = true;
                TripMenu.MainTripMenu(existingUser);
                
            }

        } while (!validInput); 

    }


    
    
}