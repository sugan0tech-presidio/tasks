using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker.Controllers;

public class AuthController
{
    private readonly AuthService _staffService;
    private const Role AdminRole = Role.Admin;

    public AuthController(AuthService staffService)
    {
        _staffService = staffService;
    }

    public bool Auth(Role role = Role.Admin)
    {
        if (AuthService.IsLogged)
        {
            if (!AuthService.LoggedUser!.Role.Equals(role))
                Console.WriteLine($"you don't have authority here, please login as {role}");
            else
            {
                Console.WriteLine($"Logged as\t: {AuthService.LoggedUser.Name} {AuthService.LoggedUser.Role}\n");
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
        if (!AuthService.IsLogged)
        {
            Console.WriteLine("Please Login first!!!");
            return;
        }

        _staffService.Logout();
        Console.WriteLine("Logging out...");
    }

    public bool HasAuthority(string level)
    {
        Enum.TryParse(level, out Role value);
        return AuthService.Authorize(value);
    }
}