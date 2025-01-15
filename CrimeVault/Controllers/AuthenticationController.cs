using CrimeVault.Application.Services.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CrimeVault.WebAPI.Controllers;

    [Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]

    public IActionResult Register(RegisterRequest reqest)
    {
        var result = _authenticationService.Register(reqest.FirstName, reqest.LastName, reqest.Email, reqest.Password);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return Problem(result.Errors);

        //var response = new AuthenticationResponse(result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
    }



    [HttpPost("login")]
    public IActionResult Login(LoginRequest reqest)
    {
        var result = _authenticationService.Login(reqest.Email, reqest.Password);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return Problem(result.Errors);
        //var response = new AuthenticationResponse(result.User.Id, result.User.FirstName, result.User.LastName, result.User.Email, result.Token);
        //return Ok(response);
    }
}
