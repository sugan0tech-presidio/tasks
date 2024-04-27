namespace ECommerceApp.Helpers;

public class ConsoleErrorNotifier: IErrorNotifier
{
    public async Task NotifyAsync(Exception ex)
    {
        Console.WriteLine($"An Error occured {ex.Message}");
        await Task.CompletedTask;
    }
}