using AwesomeRequestTracker.Controllers;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker;

class Program
{
    private readonly RequestService _requestService;
    private readonly SolutionFeedbackService _solutionFeedbackService;
    private readonly RequestSolutionService _requestSolutionService;
    private readonly EmployeeService _employeeService;
    private readonly UserService _userService;
    private readonly AuthService _authService;
    private readonly AwesomeRequestTrackerContext _context;
    private readonly UserRequestController _userRequestController;
    private readonly AdminRequestController _adminRequestController;
    private readonly AuthController _authController;

    public Program()
    {
        _context = new AwesomeRequestTrackerContext();
        _requestService = new RequestService(new RequestRepo(_context));
        _solutionFeedbackService = new SolutionFeedbackService(new SolutionFeedbackRepo(_context));
        _requestSolutionService = new RequestSolutionService(new RequestSolutionRepo(_context));
        _employeeService = new EmployeeService(new EmployeeRepo(_context));
        _userService = new UserService(new UserRepo(_context));
        _authService = new AuthService(_employeeService, _userService);
        _userRequestController = new UserRequestController(_requestService, _requestSolutionService, _solutionFeedbackService);
        _adminRequestController = new AdminRequestController(_userRequestController, _requestService,
            _requestSolutionService, _solutionFeedbackService);
        _authController = new AuthController(_authService);
    }

    static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    private void Run()
    {
        Console.WriteLine("Welcome to Awesome Request Tracker!");

        while (true)
        {
            if (AuthService.IsLogged)
            {
                switch (AuthService.LoggedUser!.Role)
                {
                    case Role.BaseUser :
                        _userRequestController.Run();
                        break;
                    case Role.Admin :
                        _adminRequestController.Run();
                        break;
                    default:
                        return;
                }
            }
            else
            {
                Console.WriteLine("Please Login");
                _authController.Auth();
            }
        }
    }
}