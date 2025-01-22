using System.Net;

namespace CrimeVault.Domain.Abstractions;

public class Error
{
    public Error(string message)
    {
        Message = message;
    }

    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }

    public string Message { get; }
    public string Code { get; } = HttpStatusCode.InternalServerError.ToString();
}

