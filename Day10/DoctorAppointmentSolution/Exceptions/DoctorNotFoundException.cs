﻿namespace DoctorAppointmentManager.Exceptions;

public class DoctorNotFoundException: Exception
{
    public DoctorNotFoundException()
    {
    }

    public DoctorNotFoundException(string? message) : base(message)
    {
    }
}