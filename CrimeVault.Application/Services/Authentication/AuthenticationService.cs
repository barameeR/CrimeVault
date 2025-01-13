
using CrimeVault.Application.Common.Interfaces.Persistence;
using CrimeVault.Domain.Entities;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;

    }
    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetByEmail(email);
        if (user == null || user.Password != password)
        {
            throw new Exception("Invalid email or password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetByEmail(email) != null)
        {
            throw new Exception("User already exists");
        }

        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(newUser);
        var token = _jwtTokenGenerator.GenerateToken(newUser);
        return new AuthenticationResult(newUser, token);
    }
}
