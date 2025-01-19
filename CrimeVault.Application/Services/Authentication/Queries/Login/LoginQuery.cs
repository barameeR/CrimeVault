

using CrimeVault.Application.Services.Authentication.Common;
using CrimeVault.Domain.Abstractions;
using MediatR;

namespace CrimeVault.Application.Services.Authentication.Queries.Login;
public record LoginQuery(string Email,
                          string Password) : IRequest<Result<AuthenticationResult>>;

