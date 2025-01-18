using CrimeVault.Domain.Entities;

namespace CrimeVault.Application.Services.Authentication.Common;

public record AuthenticationResult(User User,
                                   string Token);
