﻿namespace PharmacyManagement.Exceptions;

public class UserNotFound : Exception
{
    public UserNotFound()
    {
    }

    public UserNotFound(string? message) : base(message)
    {
    }
}