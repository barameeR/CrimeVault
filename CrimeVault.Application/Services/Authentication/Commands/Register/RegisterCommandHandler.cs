using CrimeVault.Application.Common.Errors;
using CrimeVault.Application.Common.Interfaces.Persistence;
using CrimeVault.Application.Services.Authentication.Common;
using CrimeVault.Domain.Abstractions;
using CrimeVault.Domain.Entities;
using MediatR;

namespace CrimeVault.Application.Services.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;

    }
    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByEmail(command.Email) != null)
        {
            return Result<AuthenticationResult>.Failure(ErrorExtensions.BadRequestResult("Email already in use"));
        }

        var newUser = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
        _userRepository.Add(newUser);
        var token = _jwtTokenGenerator.GenerateToken(newUser);
        return Result<AuthenticationResult>.Success(new AuthenticationResult(newUser, token));
    }
}

