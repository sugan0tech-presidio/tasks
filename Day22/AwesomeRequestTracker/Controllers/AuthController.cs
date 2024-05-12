using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker.Controllers;

public class AuthController
{
    private readonly AuthService _authService;
    private const Role AdminRole = Role.Admin;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    public bool Auth()
    {
        if (AuthService.IsLogged)
        {
            Console.WriteLine($"Logged as\t: {AuthService.LoggedUser.Name} {AuthService.LoggedUser.Role}\n");
            return true;
        }

        try
        {
            Console.WriteLine("\nPlease log in to continue:");
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            var authenticatedStaff = _authService.Authenticate(email, password);

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

        AuthService.Logout();
        Console.WriteLine("Logging out...");
    }

    public bool HasAuthority(string level)
    {
        Enum.TryParse(level, out Role value);
        return AuthService.Authorize(value);
    }
}