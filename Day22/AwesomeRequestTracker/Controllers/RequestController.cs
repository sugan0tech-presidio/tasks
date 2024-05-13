using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Serivces;

namespace AwesomeRequestTracker.Controllers;

public class RequestController : BaseController<Request>
{
    private readonly RequestService _requestService;
    private readonly RequestSolutionService _requestSolution;
    private readonly SolutionFeedbackService _solutionFeedbackService;

    public RequestController(RequestService requestService, RequestSolutionService requestSolution, SolutionFeedbackService solutionFeedbackService) : base(requestService)
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
            Console.WriteLine("4. View Feedback");
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
        }
    }

    public void RaiseRequest()
    {
        Request request = new Request();
        request.RequestMessage = GetFromConsole<string>("Request Message");
        request.RequestRaisedById = AuthService.LoggedUser.Id;
        request.RaisedBy = AuthService.LoggedUser;
        Console.WriteLine(_requestService.Add(request).Result);
    }
    
    public void ViewRequestStatus()
    {
        var id = GetFromConsole<int>("Request Id");
        Console.WriteLine(_requestService.GetById(id).Result);
    }

    public void ViewSolutions()
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

    public void GiveFeedback()
    {
        var id = GetFromConsole<int>("Solution Id");
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

    public void RespondToSolution()
    {
        var id = GetFromConsole<int>("Solution Id");
        var sln = _requestSolution.GetById(id).Result;
        sln.RequestRaiserComment = GetFromConsole<string>("Solution Comment");
        _requestSolution.Update(sln);

    }
}