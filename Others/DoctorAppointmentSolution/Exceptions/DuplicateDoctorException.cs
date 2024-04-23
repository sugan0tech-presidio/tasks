namespace DoctorsAppointmentManager.Exceptions;

public class DuplicateDoctorException: Exception
{
    public DuplicateDoctorException()
    {
    }

    public DuplicateDoctorException(string? message) : base(message)
    {
    }
}