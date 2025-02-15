﻿using CrimeVault.Application.Services.Authentication.Commands.Register;
using CrimeVault.Application.Services.Authentication.Queries.Login;
using CrimeVault.Presentation.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrimeVault.WebAPI.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result =
            await _sender.Send(_mapper.Map<RegisterCommand>(request));
        return result.Map(onSuccess: result => Ok(_mapper.Map<AuthenticationResponse>(result)), onFailure: Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _sender.Send(_mapper.Map<LoginQuery>(request));
        return result.Map(onSuccess: result => Ok(_mapper.Map<AuthenticationResponse>(result)), onFailure: Problem);
    }
}
