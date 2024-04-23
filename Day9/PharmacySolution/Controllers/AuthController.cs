using PharmacyManagement.Repositories;
using PharmacyManagement.Services;

namespace PharmacyManagement.Controllers;

public class AuthController
{
    private readonly StaffService _staffService = new(new StaffRepo());
    private const string AdminRole = "Administrator";

    public bool Auth(string role = "Administrator")
    {
        if (StaffService.IsLogged)
        {
            if (!StaffService.LoggedStaff!.Role.Equals(role))
                Console.WriteLine($"you don't have authority here, please login as {role}");
            else
            {
                Console.WriteLine($"Logged as\t: {StaffService.LoggedStaff.Name} {StaffService.LoggedStaff.Role}\n");
                return true;
            }
        }

        try
        {
            Console.WriteLine("\nPlease log in to continue:");
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            var authenticatedStaff = _staffService.Authenticate(email, password);
            if (!(authenticatedStaff.Role.Equals(role) || authenticatedStaff.Role.Equals(AdminRole)))
            {
                Console.WriteLine($"You as {authenticatedStaff.Role} do not have permission to access this system.");
                return false;
            }

            Console.WriteLine($"\nLogged in successfully as {authenticatedStaff.Role}.");
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

    public bool HasAuthority(string level)
    {
        return _staffService.getRole().Equals(level);
    }
}