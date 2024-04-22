namespace PharmacyManagement.Exceptions;

public class DangerousDrugCombinationException: Exception
{
    public DangerousDrugCombinationException()
    {
    }

    public DangerousDrugCombinationException(string? message) : base(message)
    {
    }
}