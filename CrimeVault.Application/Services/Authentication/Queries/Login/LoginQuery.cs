

using CrimeVault.Application.Services.Authentication.Common;
using FluentResults;
using MediatR;

namespace CrimeVault.Application.Services.Authentication.Queries.Login;
public record LoginQuery(string Email,
                          string Password) : IRequest<Result<AuthenticationResult>>;

