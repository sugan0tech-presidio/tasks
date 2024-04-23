namespace DoctorAppointmentManager.Exceptions;

public class DuplicateAppointmentException: Exception
{
    public DuplicateAppointmentException()
    {
    }

    public DuplicateAppointmentException(string? message) : base(message)
    {
    }
}