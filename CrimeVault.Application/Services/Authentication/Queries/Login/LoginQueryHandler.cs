﻿

using CrimeVault.Application.Common.Errors;
using CrimeVault.Application.Common.Interfaces.Persistence;
using CrimeVault.Application.Services.Authentication.Common;
using CrimeVault.Domain.Abstractions;
using MediatR;

namespace CrimeVault.Application.Services.Authentication.Queries.Login;

internal class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<Result<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetByEmail(query.Email);
        if (user == null || user.Password != query.Password)
        {
            return Result<AuthenticationResult>.Failure(ErrorExtensions.BadRequestResult("Invalid email or password"));
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Result<AuthenticationResult>.Success(new AuthenticationResult(user, token));
    }
}

