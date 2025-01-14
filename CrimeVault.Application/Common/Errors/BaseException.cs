

using System.Net;

namespace CrimeVault.Application.Common.Errors;

public class BaseException : Exception, IExceptionService
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }

    public BaseException(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        ErrorMessage = message;
    }

    // Implement IExceptionService interface
    HttpStatusCode IExceptionService.StatusCode => StatusCode;
    string IExceptionService.Message => ErrorMessage;
}

public class NotFoundException : BaseException
{
    public NotFoundException(string message)
        : base(HttpStatusCode.NotFound, message)
    {
    }
}

public class UnauthorizedAccessException : BaseException
{
    public UnauthorizedAccessException()
        : base(HttpStatusCode.Unauthorized, "Authentication is required to access this resource.")
    {
    }
}

public class ForbiddenException : BaseException
{
    public ForbiddenException()
        : base(HttpStatusCode.Forbidden, "You do not have permission to access this resource.")
    {
    }
}

public class MethodNotAllowedException : BaseException
{
    public MethodNotAllowedException()
        : base(HttpStatusCode.MethodNotAllowed, "The HTTP method used is not allowed for this resource.")
    {
    }
}

public class ConflictException : BaseException
{
    public ConflictException(string message)
        : base(HttpStatusCode.Conflict, message)
    {
    }
}

public class UnprocessableEntityException : BaseException
{
    public UnprocessableEntityException(string message)
        : base(HttpStatusCode.UnprocessableEntity, message)
    {
    }
}

public class InternalServerErrorException : BaseException
{
    public InternalServerErrorException()
        : base(HttpStatusCode.InternalServerError, "An unexpected error occurred on the server.")
    {
    }
}

public class ServiceUnavailableException : BaseException
{
    public ServiceUnavailableException()
        : base(HttpStatusCode.ServiceUnavailable, "The service is temporarily unavailable.")
    {
    }
}

public class ValidationException : BaseException
{
    public ValidationException(string message)
        : base(HttpStatusCode.BadRequest, message)
    {
    }
}

public class EmailExistException : BaseException
{
    public EmailExistException()
        : base(HttpStatusCode.BadRequest, "Email already exists.")
    {
    }
}

