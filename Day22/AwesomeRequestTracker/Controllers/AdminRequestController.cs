using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker.Controllers;

public class AdminRequestController : BaseController<Request>
{
    private readonly UserRequestController _userRequestController;
    private readonly RequestService _requestService;
    private readonly RequestSolutionService _requestSolution;
    private readonly SolutionFeedbackService _solutionFeedbackService;

    public AdminRequestController(UserRequestController userRequestController, RequestService requestService,
        RequestSolutionService requestSolution, SolutionFeedbackService solutionFeedbackService) : base(requestService)
    {
        _userRequestController = userRequestController;
        _requestService = requestService;
        _requestSolution = requestSolution;
        _solutionFeedbackService = solutionFeedbackService;
    }

    public override void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Base Controls");
            Console.WriteLine("2. Admin Controls");
            Console.WriteLine("3. exit to Main Menu");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        _userRequestController.Run();
                        break;
                    case "2":
                        ShowSubMenu();
                        break;
                    case "3":
                        AuthService.Logout();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (InvalidConsoleInputException e)
            {
                Console.WriteLine(e);
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    public void ShowSubMenu()
    {
        while (true)
        {
            Console.WriteLine("1. View All Request Status");
            Console.WriteLine("2. View All Solutions");
            Console.WriteLine("3. Provide Solution");
            Console.WriteLine("4. Closing a Request");
            Console.WriteLine("5. View your Feedback");
            Console.WriteLine("6. exit to Main Menu");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ViewAllRequest();
                        break;
                    case "2":
                        ViewSolutions();
                        break;
                    case "3":
                        ProvideSolution();
                        break;
                    case "4":
                        CloseRequest();
                        break;
                    case "5":
                        ViewFeedback();
                        break;
                    case "6":
                        AuthService.Logout();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (InvalidConsoleInputException e)
            {
                Console.WriteLine(e);
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }
        }
    }

    private void ViewAllRequest()
    {
        var requests = _requestService.GetAll().Result;
        foreach (var request in requests)
        {
            var val = $"Id: {request.Id}\tMsg: {request.RequestMessage}" +
                      $"\nRaisedBy: {request.RequestRaisedById}" +
                      $"\nSolutions: {request.RequestSolutions?.Count}" +
                      $"\nClosed By: {request.RequestClosedByEmployee?.Name}";
            Console.WriteLine(val);
        }
        // requests.ForEach(Console.WriteLine);
    }

    private void ViewSolutions()
    {
        var id = GetFromConsole<int>("Request Id");
        var solutions = _requestService.GetById(id).Result.RequestSolutions;
        if (solutions == null || solutions.Count.Equals(0))
        {
            Console.WriteLine("No solutions found!!!");
            return;
        }

        foreach (var requestSolution in solutions)
        {
            Console.WriteLine(requestSolution);
        }
    }

    private void ProvideSolution()
    {
        var id = GetFromConsole<int>("Request Id");
        var request = _requestService.GetById(id).Result;
        var solution = new RequestSolution();
        solution.SolutionDescription = GetFromConsole<string>("Solution Descritpion");
        solution.RequestRaised = request;
        solution.SolvedBy = AuthService.LoggedUser.Id;
        solution.SolvedByEmployee = AuthService.LoggedUser as Employee;
        solution.SolvedDate = DateTime.Now;

        _requestSolution.Add(solution);
        if (request.RequestSolutions == null)
            request.RequestSolutions = new List<RequestSolution>();
        request.RequestSolutions.Add(solution);
        _requestService.Update(request);
    }

    private void CloseRequest()
    {
        var id = GetFromConsole<int>("Request Id");
        var request = _requestService.GetById(id).Result;
        request.RequestClosedBy = AuthService.LoggedUser.Id;
        request.ClosedDate = DateTime.Now;
        request.RequestClosedByEmployee = AuthService.LoggedUser as Employee;
        _requestService.Update(request);
    }

    private void ViewFeedback()
    {
        Employee usr = (Employee)AuthService.LoggedUser;
        var feedbacks = _solutionFeedbackService.GetAll().Result.FindAll(sf => sf.Solution.SolvedBy.Equals(usr.Id));
        foreach (var feedback in feedbacks)
        {
            Console.WriteLine(feedback);
        }
    }
}