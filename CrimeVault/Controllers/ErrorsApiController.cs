using CrimeVault.Application.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CrimeVault.WebAPI.Controllers;

public class ErrorsApiController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IExceptionService ex => ((int)ex.StatusCode, ex.Message),
            _ => (500, "An unexpected error occurred."),
        };

        return Problem(statusCode: statusCode, detail: exception?.StackTrace, title: message);
    }
}