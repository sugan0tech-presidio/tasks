using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker.Controllers;

public class UserRequestController : BaseController<Request>
{
    private readonly RequestService _requestService;
    private readonly RequestSolutionService _requestSolution;
    private readonly SolutionFeedbackService _solutionFeedbackService;

    public UserRequestController(RequestService requestService, RequestSolutionService requestSolution,
        SolutionFeedbackService solutionFeedbackService) : base(requestService)
    {
        _requestService = requestService;
        _requestSolution = requestSolution;
        _solutionFeedbackService = solutionFeedbackService;
    }

    public override void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request Status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to Solution");
            Console.WriteLine("6. exit to Main Menu");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        RaiseRequest();
                        break;
                    case "2":
                        ViewRequestStatus();
                        break;
                    case "3":
                        ViewSolutions();
                        break;
                    case "4":
                        GiveFeedback();
                        break;
                    case "5":
                        RespondToSolution();
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
            catch (AuthenticationException aue)
            {
                Console.WriteLine(aue);
            }
        }
    }

    /// <summary>
    ///  To raise a request
    /// </summary>
    public void RaiseRequest()
    {
        Request request = new Request();
        request.RequestMessage = GetFromConsole<string>("Request Message");
        request.RequestRaisedById = AuthService.LoggedUser.Id;
        request.RaisedBy = AuthService.LoggedUser;
        Console.WriteLine(_requestService.Add(request).Result);
    }

    /// <summary>
    ///  To view status of a request
    /// </summary>
    public void ViewRequestStatus()
    {
        DisplayAccessibleRequestsId();
        var id = GetFromConsole<int>("Request Id");
        var request = _requestService.GetById(id).Result;
        if (AuthService.LoggedUser.Role.Equals(Role.Admin))
            Console.WriteLine(request);
        else
        {
            if (request.RaisedBy.Id.Equals(AuthService.LoggedUser.Id))
                Console.WriteLine(request);
            else
                throw new AuthenticationException("You don't have permission to access this request");
        }

    }

    /// <summary>
    ///  View solutions provided for the given request Id
    /// </summary>
    /// <exception cref="AuthenticationException"></exception>
    public void ViewSolutions()
    {
        DisplayAccessibleRequestsId();
        var id = GetFromConsole<int>("Request Id");
        var requests = _requestService.GetById(id).Result;

        if (!AuthService.LoggedUser.RequestsRaised.Contains(requests))
        {
            throw new AuthenticationException("You can't access this Request");
        }

        var solutions = requests.RequestSolutions;
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

    /// <summary>
    /// To give feedback for the given solution
    /// </summary>
    public void GiveFeedback()
    {
        var id = GetFromConsole<int>("Solution Id");
        var solution = _requestSolution.GetById(id).Result;
        if (solution.RequestRaised.RaisedBy.Id != AuthService.LoggedUser.Id)
            throw new System.Security.Authentication.AuthenticationException("you don't have access to this solution");
        
        SolutionFeedback solutionFeedback = new SolutionFeedback();
        solutionFeedback.FeedbackBy = AuthService.LoggedUser.Id;
        solutionFeedback.FeedbackByPerson = AuthService.LoggedUser;
        solutionFeedback.Solution = _requestSolution.GetById(id).Result;
        solutionFeedback.SolutionId = id;
        solutionFeedback.Remarks = GetFromConsole<string>("Remarks");
        solutionFeedback.Rating = GetFromConsole<float>("Rating out of 10");
        _solutionFeedbackService.Add(solutionFeedback);
        _requestSolution.AddFeedback(solutionFeedback);
    }

    /// <summary>
    /// To respond to a solution ( accepting it )
    /// </summary>
    public void RespondToSolution()
    {
        var id = GetFromConsole<int>("Solution Id");
        var sln = _requestSolution.GetById(id).Result;
        sln.RequestRaiserComment = GetFromConsole<string>("Solution Comment");
        sln.IsSolved = true;
        _requestSolution.Update(sln);
    }

    public void DisplayAccessibleRequestsId()
    {
        Console.Write("\nAccessible Requests :");
        var usrId = AuthService.LoggedUser.Id;
        _requestService.GetAll().Result.AsEnumerable().ToList().ForEach(request =>
        {
            if (request.RaisedBy.Id.Equals(usrId))
                Console.Write(request.Id + " ");
        } );
        Console.WriteLine("");
    }
}