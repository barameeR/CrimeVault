using CrimeVault.Domain.Entities;

namespace CrimeVault.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetByEmail(string email);
    void Add(User user);
}

