using CrimeVault.Domain.Primitives;

namespace CrimeVault.Domain.Entities;

public class User : AggregateRoot<UserId>
{
    public User(UserId id) : base(id)
    {
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public record UserId(Guid Value);

