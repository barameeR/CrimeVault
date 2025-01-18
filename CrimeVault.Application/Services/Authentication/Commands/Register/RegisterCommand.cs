﻿using CrimeVault.Application.Services.Authentication.Common;
using FluentResults;
using MediatR;


namespace CrimeVault.Application.Services.Authentication.Commands.Register;

public record RegisterCommand(string FirstName,
                               string LastName,
                               string Email,
                               string Password) : IRequest<Result<AuthenticationResult>>;

