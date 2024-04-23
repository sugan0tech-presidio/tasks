namespace DoctorsAppointmentManager.Exceptions;

public class DuplicateAppointmentException: Exception
{
    public DuplicateAppointmentException()
    {
    }

    public DuplicateAppointmentException(string? message) : base(message)
    {
    }
}