
using CrimeVault.Domain.Abstractions;
using System.Net;
namespace CrimeVault.Application.Common.Errors;

public static class ErrorExtensions
{
    // This method converts HttpStatusCode to an Error object with numeric status code.
    public static Error ToError(this HttpStatusCode statusCode, string message = "An error occurred.")
    {
        // Get the numeric code for the status code
        var code = (int)statusCode;
        return new Error(message, code.ToString()); // Return Error with numeric code and message
    }

    // BadRequestResult for HTTP 400
    public static Error BadRequestResult(string message = "Bad Request.")
    {
        var code = (int)HttpStatusCode.BadRequest;
        return new Error(message, code.ToString()); // Return Error with 400 code and message
    }

    // UnauthorizedResult for HTTP 401
    public static Error UnauthorizedResult(string message = "Unauthorized access.")
    {
        var code = (int)HttpStatusCode.Unauthorized;
        return new Error(message, code.ToString()); // Return Error with 401 code and message
    }

    // ForbiddenResult for HTTP 403
    public static Error ForbiddenResult(string message = "Forbidden access.")
    {
        var code = (int)HttpStatusCode.Forbidden;
        return new Error(message, code.ToString()); // Return Error with 403 code and message
    }

    // NotFoundResult for HTTP 404
    public static Error NotFoundResult(string message = "Resource not found.")
    {
        var code = (int)HttpStatusCode.NotFound;
        return new Error(message, code.ToString()); // Return Error with 404 code and message
    }

    // MethodNotAllowedResult for HTTP 405
    public static Error MethodNotAllowedResult(string message = "Method not allowed.")
    {
        var code = (int)HttpStatusCode.MethodNotAllowed;
        return new Error(message, code.ToString()); // Return Error with 405 code and message
    }

    // InternalServerErrorResult for HTTP 500
    public static Error InternalServerErrorResult(string message = "Internal server error.")
    {
        var code = (int)HttpStatusCode.InternalServerError;
        return new Error(message, code.ToString()); // Return Error with 500 code and message
    }

    // NotImplementedResult for HTTP 501
    public static Error NotImplementedResult(string message = "Not Implemented.")
    {
        var code = (int)HttpStatusCode.NotImplemented;
        return new Error(message, code.ToString()); // Return Error with 501 code and message
    }

    // BadGatewayResult for HTTP 502
    public static Error BadGatewayResult(string message = "Bad Gateway.")
    {
        var code = (int)HttpStatusCode.BadGateway;
        return new Error(message, code.ToString()); // Return Error with 502 code and message
    }

    // ServiceUnavailableResult for HTTP 503
    public static Error ServiceUnavailableResult(string message = "Service Unavailable.")
    {
        var code = (int)HttpStatusCode.ServiceUnavailable;
        return new Error(message, code.ToString()); // Return Error with 503 code and message
    }

    // GatewayTimeoutResult for HTTP 504
    public static Error GatewayTimeoutResult(string message = "Gateway Timeout.")
    {
        var code = (int)HttpStatusCode.GatewayTimeout;
        return new Error(message, code.ToString()); // Return Error with 504 code and message
    }

    // ConflictResult for HTTP 409
    public static Error ConflictResult(string message = "Conflict.")
    {
        var code = (int)HttpStatusCode.Conflict;
        return new Error(message, code.ToString()); // Return Error with 409 code and message
    }

    // RequestTimeoutResult for HTTP 408
    public static Error RequestTimeoutResult(string message = "Request Timeout.")
    {
        var code = (int)HttpStatusCode.RequestTimeout;
        return new Error(message, code.ToString()); // Return Error with 408 code and message
    }

    // UnprocessableEntityResult for HTTP 422
    public static Error UnprocessableEntityResult(string message = "Unprocessable Entity.")
    {
        var code = (int)HttpStatusCode.UnprocessableEntity;
        return new Error(message, code.ToString()); // Return Error with 422 code and message
    }

    // TooManyRequestsResult for HTTP 429
    public static Error TooManyRequestsResult(string message = "Too Many Requests.")
    {
        var code = (int)HttpStatusCode.TooManyRequests;
        return new Error(message, code.ToString()); // Return Error with 429 code and message
    }

}


