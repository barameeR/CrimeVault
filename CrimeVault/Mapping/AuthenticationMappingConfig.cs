using CrimeVault.Application.Services.Authentication.Common;
using CrimeVault.Presentation.Authentication;
using Mapster;

namespace CrimeVault.WebAPI.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(d => d.Token, s => s.Token)
            .Map(d => d, s => s.User);
    }
}