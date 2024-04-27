namespace ECommerceApp.Helpers;

public interface IErrorNotifier
{
    Task NotifyAsync(Exception ex);
}