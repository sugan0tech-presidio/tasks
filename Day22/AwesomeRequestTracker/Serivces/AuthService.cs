using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Serivces;

public class AuthService
{
    private readonly EmployeeService _employeeService;
    private readonly UserService _userService;
    public static bool IsLogged { get; private set; }
    public static Person? LoggedUser { get; private set; }

    public AuthService(EmployeeService employeeService, UserService userService)
    {
        _employeeService = employeeService;
        _userService = userService;
    }

    /// <summary>
    /// Authenticates a Person member with the provided credentials.
    /// </summary>
    /// <param name="email">The email of the Person.</param>
    /// <param name="password">The password of the Person member.</param>
    /// <returns>The authenticated staff member.</returns>
    /// <exception cref="ArgumentException">Thrown if the email or password is empty or null.</exception>
    /// <exception cref="AuthenticationException">Thrown if authentication fails.</exception>
    public Person Authenticate(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email cannot be empty or null.", nameof(email));

        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be empty or null.", nameof(password));

        Person authenticatedPerson;
        authenticatedPerson = _employeeService.GetAll().Result
            .Find(emp => emp.Email.Equals(email) && emp.password.Equals(password))!;

        if (authenticatedPerson == null)
            authenticatedPerson = _userService.GetAll().Result
                                      .Find(emp => emp.Email.Equals(email) && emp.password.Equals(password)) ??
                                  throw new AuthenticationException("No one found!!!");

        IsLogged = true;
        LoggedUser = authenticatedPerson;

        return authenticatedPerson;
    }

    /// <summary>
    /// To logout
    /// sets logged flag as flase
    /// </summary>
    public static void Logout()
    {
        IsLogged = false;
    }

    /// <summary>
    /// Authorise given Role with current logged user
    /// </summary>
    /// <param name="role"></param>
    /// <returns>Boolean represents authroization statsu</returns>
    /// <exception cref="AuthenticationException">if not logged in</exception>
    public static bool Authorize(Role role)
    {
        if (IsLogged == false)
        {
            throw new AuthenticationException("No logged person found!!!");
        }

        return LoggedUser.Role.Equals(role);
    }
}