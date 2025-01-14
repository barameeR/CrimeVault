

using System.Net;

namespace CrimeVault.Application.Common.Errors;

public interface IExceptionService
{
    public HttpStatusCode StatusCode { get; }
    public string Message { get; }

}

