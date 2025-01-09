using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
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
        var response = new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest reqest)
    {
        var result = _authenticationService.Login(reqest.Email, reqest.Password);
        var response = new AuthenticationResponse(result.Id, result.FirstName, result.LastName, result.Email, result.Token);
        return Ok(response);
    }
}

