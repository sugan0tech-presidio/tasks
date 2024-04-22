using PharmacyManagement.Repositories;
using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers;

public class AuthController
{
    private readonly StaffService _staffService = new StaffService(new StaffRepo());

    public bool Auth()
    {
        if (StaffService.IsLogged)
        {
            Console.WriteLine($"Logged as\t: {StaffService.LoggedUser}\n");
            return true;
        }
            try
            {
                Console.WriteLine("\nPlease log in to continue:");
                Console.Write("Email: ");
                var email = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                var AdminRole = "administrator";

                var authenticatedStaff = _staffService.Authenticate(email, password);
                if (authenticatedStaff.Role != AdminRole)
                {
                    Console.WriteLine("You do not have permission to access this system.");
                    return false;
                }

                Console.WriteLine("\nLogged in successfully as Administrator.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        return false;
    }

    public void Logout()
    {
        if (!StaffService.IsLogged)
        {
            Console.WriteLine("Please Login first!!!");
            return;
        }
        _staffService.Logout();
        Console.WriteLine("Logging out...");
    }

}