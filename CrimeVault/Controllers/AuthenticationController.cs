using CrimeVault.Application.Services.Authentication.Commands.Register;
using CrimeVault.Application.Services.Authentication.Common;
using CrimeVault.Application.Services.Authentication.Queries.Login;
using CrimeVault.Presentation.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrimeVault.WebAPI.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;

    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest reqest)
    {
        var result = await _mediator.Send(new RegisterCommand(reqest.FirstName, reqest.LastName, reqest.Email, reqest.Password));
        if (result.IsSuccess)
        {
            return Ok(MapToResponse(result.Value));
        }
        return Problem(result.Errors);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest reqest)
    {
        var result = await _mediator.Send(new LoginQuery(reqest.Email, reqest.Password));
        if (result.IsSuccess)
        {
            return Ok(MapToResponse(result.Value));
        }
        return Problem(result.Errors);
    }
    private AuthenticationResponse MapToResponse(AuthenticationResult result)
    {
        return new(result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
    }
}
