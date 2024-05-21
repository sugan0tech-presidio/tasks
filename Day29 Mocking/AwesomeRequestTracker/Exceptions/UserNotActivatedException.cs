﻿namespace AwesomeRequestTracker.Exceptions;

public class UserNotActivatedException: Exception
{
    public UserNotActivatedException()
    {
    }

    public UserNotActivatedException(string? message) : base(message)
    {
    }
}