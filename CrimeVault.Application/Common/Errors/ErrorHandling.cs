using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
namespace CrimeVault.Application.Common.Errors;

public class ErrorHandling
{
}

// Base class for HTTP status code related errors
public class HttpStatusCodeError : Error
{
    public HttpStatusCodeError(HttpStatusCode statusCode, string message)
        : base(message)
    {
        // Add status code metadata to the error
        Metadata.Add("StatusCode", (int)statusCode); // Store the HTTP status code as metadata
    }
}

// Specific error class for authentication failure (401 Unauthorized)
public class AuthenticationError : HttpStatusCodeError
{
    public AuthenticationError(string message = "Authentication failed.")
        : base(HttpStatusCode.Unauthorized, message)
    {
    }
}

// Specific error class for resource not found (404 Not Found)
public class NotFoundError : HttpStatusCodeError
{
    public NotFoundError(string message = "Resource not found.")
        : base(HttpStatusCode.NotFound, message)
    {
    }
}

// Specific error class for forbidden access (403 Forbidden)
public class ForbiddenError : HttpStatusCodeError
{
    public ForbiddenError(string message = "Forbidden access.")
        : base(HttpStatusCode.Forbidden, message)
    {
    }
}

public class BadRequestError : HttpStatusCodeError
{
    public BadRequestError(string message = "Bad request.")
        : base(HttpStatusCode.BadRequest, message)
    {
    }
}


